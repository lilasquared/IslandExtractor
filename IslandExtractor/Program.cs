using System;
using System.Collections.Generic;
using System.Drawing;

namespace IslandExtractor
{
    static class Program
    {
        const Int32 Height = 96;
        const Int32 Width = 112;

        static void Main(String[] args)
        {
            var image = Image.FromFile(".\\_island.png");

            var crop = Crop(image, new Rectangle(266, 89, 448, 384));

            crop.Save(".\\_crop.png");

            var shrink = crop.Resize(Width, Height, System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear);

            shrink.Save(".\\_shrink.png");

            var cells = new List<Cell>();

            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    var cell = shrink.GetCell(x, y);
                    cells.Add(cell);
                    if (cell.Feature != null)
                    {
                        shrink.SetPixel(x, y, cell.Feature.Debug);
                    }
                    else
                    {
                        shrink.SetPixel(x, y, Color.White);
                    }
                }
            }

            var grow = shrink.Resize(Width * 8, Height * 8);
            grow.Save(".\\_grow.png");
        }

        private static Bitmap Crop(Image image, Rectangle area)
        {
            var bmp = new Bitmap(image);
            return bmp.Clone(area, bmp.PixelFormat);
        }

        private static Bitmap Resize(this Bitmap source, Int32 width, Int32 height, System.Drawing.Drawing2D.InterpolationMode mode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor)
        {
            var result = new Bitmap(width, height);
            using (var g = Graphics.FromImage(result))
            {
                g.InterpolationMode = mode;
                g.DrawImage(source, 0, 0, width, height);
            }
            return result;
        }

        private static Cell GetCell(this Bitmap image, Int32 x, Int32 y)
        {
            var color = image.GetPixel(x, y);

            var cell = new Cell
            {
                Color = color,
                X = x,
                Y = y,
            };
            
            if (Feature.Sand.IsCloseEnough(color))
            {
                cell.Feature = Feature.Sand;
            }

            if (Feature.Water.IsCloseEnough(color))
            {
                cell.Feature = Feature.Water;
            }

            if (Feature.Level1.IsCloseEnough(color))
            {
                cell.Feature = Feature.Level1;
            }

            if (Feature.Level2.IsCloseEnough(color))
            {
                cell.Feature = Feature.Level2;
            }

            if (Feature.Level3.IsCloseEnough(color))
            {
                cell.Feature = Feature.Level3;
            }

            if (Feature.Rock.IsCloseEnough(color))
            {
                cell.Feature = Feature.Rock;
            }

            return cell;
        }
    }
}
