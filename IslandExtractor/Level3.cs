using System;
using System.Drawing;

namespace IslandExtractor
{
    class Level3 : Feature
    {
        public Level3() : base(Color.FromArgb(105, 205, 79), Color.LightGreen, 5, "Level3")
        {
        }

        protected override Int32 Tolerance => 30;

        public override Boolean IsCloseEnough(Color color)
        {
            var brightness = color.GetBrightness();

            return base.IsCloseEnough(color) && brightness > 0.5;
        }
    }
}
