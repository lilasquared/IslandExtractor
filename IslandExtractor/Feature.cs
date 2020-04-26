using System;
using System.Drawing;

namespace IslandExtractor
{
    abstract class Feature : Enumeration
    {
        protected abstract Int32 Tolerance { get; }
        public static readonly Feature Water = new Water();
        public static readonly Feature Sand = new Sand();
        public static readonly Feature Level1 = new Level1();
        public static readonly Feature Level2 = new Level2();
        public static readonly Feature Level3 = new Level3();
        public static readonly Feature Rock = new Rock();

        public Color Color { get; }
        public Color Debug { get; }

        public Feature(Color color, Color debug, Int32 value, String name) : base(value, name)
        {
            Color = color;
            Debug = debug;
        }

        public virtual Boolean IsCloseEnough(Color color)
        {
            var r = Color.R - color.R;
            var g = Color.G - color.G;
            var b = Color.B - color.B;
            return (r * r + g * g + b * b) <= Tolerance * Tolerance;
        }
    }
}
