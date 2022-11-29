using Microsoft.AspNetCore.Mvc;
using project.Models;

namespace project.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {

            return View();
        }

        
    }
}
