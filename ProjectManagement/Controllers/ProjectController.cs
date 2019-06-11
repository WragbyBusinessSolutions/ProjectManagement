using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.Models;



namespace ProjectManagement.Controllers
{

    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProject()
        {
            return View();
        }
         public IActionResult AddInternalProject()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInternalProject(Project project)

        {
            project.PublishedDate = DateTime.Now;
            project.DateUpdated = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        public IActionResult ProjectDetails()
        {
            return View();
        }
    }
}
