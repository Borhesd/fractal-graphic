using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace UIApp.Data
{
    public class SierpinskiFractalsAPI:ClientAPI
    {
        public SierpinskiFractalsAPI(HttpClient http) : base("https://localhost:5001/SierpinskiFractal", http) { }

        public async Task<List<Point>> GetPointsAsync(int pointCount, float width, float height)
        {
            return await GetAsync<List<Point>>($"GetTriangle?pointCount={pointCount}&width={width}&height={height}");
        }
    } 
}
