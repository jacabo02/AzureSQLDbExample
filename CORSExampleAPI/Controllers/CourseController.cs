using CORSExampleAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORSExampleAPI.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;
        private readonly IConfiguration _configuration;
        public CourseController(CourseService courseService, IConfiguration configuration)
        {
            _courseService = courseService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_courseService.GetCourses(_configuration.GetConnectionString("SQLConnection")));
        }
    }
}
