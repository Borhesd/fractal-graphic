using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostAPI.Services
{
    interface ITriangleFractalService
    {
        public void CreateAttractors(float width, float height);
        public List<SierpinskiFractal.Classes.Point> CreateFractal(int count);

    }
}
