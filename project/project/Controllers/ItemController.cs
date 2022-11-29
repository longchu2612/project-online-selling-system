using Microsoft.AspNetCore.Mvc;
using project.Models;

namespace project.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
