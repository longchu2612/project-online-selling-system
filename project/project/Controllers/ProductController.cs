using Microsoft.AspNetCore.Mvc;
using project.Models;

namespace project.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View("Item");
        }

        public IActionResult Item()
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                var list = context.TblMatHangs.ToList();
                return View("Item", list);
            }
        }

        public IActionResult UpdateItem(string name)
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                var product = context.TblMatHangs.Find(name);
                return View("UpdateItem", product);
            }
        }

        [HttpPost]
        public IActionResult UpdateItem(TblMatHang product)
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                if (ModelState.IsValid)
                {
                    context.TblMatHangs.Update(product);
                    context.SaveChanges();
                    var list = context.TblMatHangs.ToList();
                    return View("Item", list);
                }
                else
                {
                    var list = context.TblMatHangs.ToList();
                    return View("Item", list);
                }
            }
        }

        public IActionResult AddItem()
        {
            return View("AddItem");
        }
        [HttpPost]
        public IActionResult AddItem(TblMatHang product)
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                if (ModelState.IsValid)
                {
                    context.TblMatHangs.Add(product);
                    context.SaveChanges();
                    var list = context.TblMatHangs.ToList();
                    return View("Item", list);
                }
                else
                {
                    var list_2 = context.TblMatHangs.ToList();
                    return View("Item", list_2);
                }

            }
        }
        public IActionResult DeleteItem(string name)
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                TblMatHang p = context.TblMatHangs.Find(name);
                context.TblMatHangs.Remove(p);
                context.SaveChanges();
                var list = context.TblMatHangs.ToList();
                return View("Item", list);
            }
        }


    }
}
