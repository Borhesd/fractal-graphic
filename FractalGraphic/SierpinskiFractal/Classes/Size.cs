using System;
using System.Collections.Generic;
using System.Text;

namespace SierpinskiFractal.Classes
{
    public class Size
    {
        public float Width { get; set; }

        public float Height { get; set; }

        public Size(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public Size(Structures.Size size)
        {
            Width = size.Width;
            Height = size.Height;
        }
    }
}
