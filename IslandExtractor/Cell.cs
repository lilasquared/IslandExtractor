using System;
using System.Drawing;

namespace IslandExtractor
{
    struct Cell
    {
        public Color Color { get; set; }
        public Feature Feature { get; set; }
        public Int32 X { get; set; }
        public Int32 Y { get; set; }
    }
}
