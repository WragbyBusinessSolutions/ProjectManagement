using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
    public class ManagerController : Controller
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