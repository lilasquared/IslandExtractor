using System;
using System.Drawing;

namespace IslandExtractor
{
    class Level1 : Feature
    {
        public Level1() : base(Color.FromArgb(66, 120, 63), Color.DarkGreen, 3, "Level1")
        {
        }

        protected override Int32 Tolerance => 35;

        public override Boolean IsCloseEnough(Color color)
        {
            var brightness = color.GetBrightness();

            if (base.IsCloseEnough(color))
            {
                if (brightness <= 0.42)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine(brightness);
                    return false;
                }
            }

            return false;
        }
    }
}
