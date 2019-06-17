using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectManagement.Controllers
{
    public class InternalProjectsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProject()
        {
            return View();
        }

        public IActionResult ProjectDetails()
        {
            return View();
        }
        public IActionResult InternalProjects()
        {
            return View();
        }
        public IActionResult ExternalProjects()
        {
            return View();
        }
    }
}
