using System;
using System.Collections.Generic;
using System.Text;
using SierpinskiFractal.Structures;

namespace SierpinskiFractal
{
    public interface ITriangle
    {
        public void CreateAttractors(Classes.Size size);
        public void CreateAttractors(Size size);
        public void CreateAttractors(float width, float height);
        public List<Classes.Point> GetPointsClass(int count);
        public List<Point> GetPointsStruct(int count);
        
    }
}
