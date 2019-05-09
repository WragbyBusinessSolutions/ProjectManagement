using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProjectSegmentation()
        {
            return View();
        }

        public IActionResult ProjectRevenue()
        {
            return View();
        }
    }
}