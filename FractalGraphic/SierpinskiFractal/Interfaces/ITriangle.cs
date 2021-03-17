using System.Collections.Generic;
using SierpinskiFractal.Data;

namespace SierpinskiFractal
{
    public interface ITriangle
    {
        public void CreateAttractors(Size size);
        public void CreateAttractors(float width, float height);
        public Point[] GetPoints(int count);
        
    }
}
