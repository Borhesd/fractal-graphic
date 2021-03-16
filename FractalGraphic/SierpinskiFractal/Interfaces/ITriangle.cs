using System.Collections.Generic;
using SierpinskiFractal.Data;

namespace SierpinskiFractal
{
    public interface ITriangle
    {
        public void CreateAttractors(Size size);
        public void CreateAttractors(float width, float height);
        public List<Point> GetPoints(int count);
        
    }
}
