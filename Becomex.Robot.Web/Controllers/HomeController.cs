using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Becomex.Robot.Web.Models;
using Microsoft.Extensions.Configuration;

namespace Becomex.Robot.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly string _urlBaseApi;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;

            _urlBaseApi = _config.GetValue<string>("AppConfig:AppURLs:UrlRobotApi");
        }

        public IActionResult Index()
        {
            ViewBag.UrlGetRobot = _urlBaseApi + "/Robots";

            return View();
        }

    }
}
