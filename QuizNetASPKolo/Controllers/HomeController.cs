using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizNetASPKolo.Models;

namespace QuizNetASPKolo.Controllers
{
    public class HomeController : Controller
    {

        public static List<Student> Students = new List<Student>() 
        { 
            new Student()
            {
                Id = 1,
                IndexNumber = 66644,
                FirstName = "Nobody",
                LastName = "Noone"
            },
            new Student()
            {
                Id = 2,
                IndexNumber = 44666,
                FirstName = "Numero",
                LastName = "Duo"
            },
            new Student()
            {
                Id = 0,
                IndexNumber = 0,
                FirstName = "Pustka",
                LastName = "Nisość"
            }
        };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);

            return View(student);
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
