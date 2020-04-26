using System;
using System.Drawing;

namespace IslandExtractor
{
    class Sand : Feature
    {
        public Sand() : base(Color.FromArgb(235, 231, 166), Color.Brown, 2, "Sand")
        {
        }

        protected override Int32 Tolerance => 35;
    }
}
