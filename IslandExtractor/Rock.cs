using System;
using System.Drawing;

namespace IslandExtractor
{
    class Rock : Feature
    {
        public Rock() : base(Color.FromArgb(111, 121, 138), Color.Black, 6, "Rock")
        {
        }

        protected override Int32 Tolerance => 30;
    }
}
