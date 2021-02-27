using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SierpinskiFractal;
using System.Net;

namespace HostAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SierpinskiFractalController : Controller
    {

        private readonly ILogger<SierpinskiFractalController> _logger;
        private readonly ITriangle _triangleFractal;

        public SierpinskiFractalController(ILogger<SierpinskiFractalController> logger, ITriangle triangleFractal)
        {
            _logger = logger;
            _triangleFractal = triangleFractal;
        }

        [HttpGet]
        public IActionResult CreateFractal(int pointCount, float width, float height)
        {
            try
            {
                _triangleFractal.CreateAttractors(width,height);
                return Json(_triangleFractal.GetPointsClass(pointCount));
            }
            catch(Exception ex)
            {
                _logger.LogError($"Triangle fractal created error: {ex.Message}");
                return BadRequest();
            }
        }

    }
}
