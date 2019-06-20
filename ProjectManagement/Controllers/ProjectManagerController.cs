using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
  public class ProjectManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AssignedProjects()
        {
          return View();
        }

        public IActionResult Reports()
        {
          return View();
        }

  }
}