using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Docs()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult ExternalProjects()
        {
            return View();
        }
        public IActionResult InternalProjects()
        {
            return View();
        }
    }
}