using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using QuizNetDataAccess.Models;

namespace QuizNetASPKolo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cache1()
        {
            if (!_cache.TryGetValue("Current time", out DateTime result))
            {
                result = DateTime.Now;
                _cache.Set("Current time", result, TimeSpan.FromSeconds(5));
            }

            return View("Cache", result);
        }

        public IActionResult Cache2()
        {
            var cacheItem = _cache.GetOrCreate("Current time", entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(7);
                return DateTime.Now;
            });

            return View("Cache", cacheItem);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
