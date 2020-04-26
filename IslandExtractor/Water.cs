using System;
using System.Drawing;

namespace IslandExtractor
{
    class Water : Feature
    {
        public Water() : base(Color.FromArgb(123, 215, 195), Color.Navy, 1, "Water")
        {
        }

        protected override Int32 Tolerance => 60;
    }
}
