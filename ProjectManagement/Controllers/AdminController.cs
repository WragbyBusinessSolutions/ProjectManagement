using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManagement.Data;

namespace ProjectManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Docs()
        {
            return View();
        }

        public IActionResult Projects()
        {
            return View();
        } public IActionResult ProjectDetails()
        {
            return View();
        }
         public IActionResult AddInternalProject()
        {
            var methods = _context.Methodologies.ToList();
            var selectList = new List<SelectListItem>
            {
                new SelectListItem { Text = "Custom ", Value = "0" }
            };
            foreach (var item in methods)
            {
                selectList.Add(new SelectListItem { Text = item.Name, Value = item.Id });

            }
            ViewBag.methods = selectList;

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
        public IActionResult Methodology()
        {
            return View();
        }

    public IActionResult UpstreamRepo()
    {
      return View();
    }

    public IActionResult DownstreamRepo()
    {
      return View();
    }

    public IActionResult SheRepo()
    {
      return View();
    }

    public IActionResult ProcurementRepo()
    {
      return View();
    }

  }
}