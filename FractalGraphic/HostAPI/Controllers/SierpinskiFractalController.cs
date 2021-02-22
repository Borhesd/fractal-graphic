using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SierpinskiFractal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HostAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SierpinskiFractalController : Controller
    {

        private readonly ILogger<SierpinskiFractalController> _logger;

        public SierpinskiFractalController(ILogger<SierpinskiFractalController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public JsonResult GetPoints(int count, float width, float height)
        {
            return Json(new Triangle(width, height).GetPointsClass(count));
        }
    }
}
