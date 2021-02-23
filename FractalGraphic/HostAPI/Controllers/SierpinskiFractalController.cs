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
        private readonly Services.TriangleFractalService _triangleFractal;

        public SierpinskiFractalController(ILogger<SierpinskiFractalController> logger, Services.TriangleFractalService triangleFractal)
        {
            _logger = logger;
            _triangleFractal = triangleFractal;
        }

        [HttpGet]
        public JsonResult CreateFractal(int pointCount, float width, float height)
        {
            try
            {
                _triangleFractal.CreateAttractors(width,height);
                Response response = new Response(_triangleFractal.CreateFractal(pointCount));
                _logger.LogInformation("Triangle fractal created.");
                return Json(response);
            }
            catch
            {
                _logger.LogError("Triangle fractal created error.");
                return Json(new Response(HttpStatusCode.InternalServerError, message: "ERROR"));
            }
        }

    }
}
