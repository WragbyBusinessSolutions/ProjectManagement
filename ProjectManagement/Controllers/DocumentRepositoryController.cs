using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
    public class DocumentRepositoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DocumentLibrary()
        {
            return View();
        }
    }
}