namespace SierpinskiFractal.Data
{
    public struct Size
    {
        public float Width;
        public float Height;

        public Size(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }

        public static Size operator +(Size left, Size right)
        {
            return new Size(width:left.Width + right.Width,height:left.Height + right.Height);
        }

        public static Size operator -(Size left, Size right)
        {
            return new Size(width: left.Width - right.Width, height: left.Height - right.Height);
        }

        public static bool operator ==(Size left, Size right)
        {
            return left.Width == right.Width && left.Height == right.Height;
        }
        public static bool operator !=(Size left, Size right)
        {
            return left.Width != right.Width || left.Height != right.Height;
        }
        public override string ToString()
        {
            return $"{Width}x{Height}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
