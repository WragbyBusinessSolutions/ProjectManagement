using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
  public class AsstDirectorController : Controller
    {
        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult Reports()
        {
          return View();
        }
  }
} 