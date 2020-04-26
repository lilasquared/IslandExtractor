using System;
using System.Drawing;

namespace IslandExtractor
{
    class Level2 : Feature
    {
        public Level2() : base(Color.FromArgb(66, 159, 62), Color.Green, 4, "Level2")
        {
        }

        protected override Int32 Tolerance => 30;

        public override Boolean IsCloseEnough(Color color)
        {
            var brightness = color.GetBrightness();

            if (base.IsCloseEnough(color))
            {
                if (brightness > 0.42 && brightness < 0.5)
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
