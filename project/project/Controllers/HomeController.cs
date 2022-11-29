using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using project.Models;
using System.Security.Claims;
using System.Security.Principal;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        public static int dem = 0;
        public IActionResult Index()
        {

            return View("Index");


        }
        
        [HttpPost]
     
        public IActionResult Login(string user_name, string password)
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                
               
                var check = context.TblUsers.FirstOrDefault(item => item.Username.Equals(user_name) &&
                item.Pass.ToString().Equals(password));
                if (check != null)
                {
                    var list = context.TblKhachHangs.ToList();
                    return View("~/Views/Admin/Dashboard.cshtml");
                }
                else
                {
                    dem++;

                    if (dem == 3)
                    {
                        return View("~/Views/Home/Register.cshtml");
                    }

                }
                return View("Index");
               

            }



        }

        public IActionResult Product(List<TblKhachHang> customers)
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                var list = context.TblKhachHangs.ToList();
                return View("Product", list);
            }
        }

        public IActionResult Detail(String name)
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                TblKhachHang p = context.TblKhachHangs
                    .FirstOrDefault(p => p.MaKh.Equals(name));

                return View("Detail", p);
            }

        }

        public IActionResult Delete(string name)
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                TblKhachHang p = context.TblKhachHangs.Find(name);
                context.TblKhachHangs.Remove(p);
                context.SaveChanges();
                var list = context.TblKhachHangs.ToList();
                return View("Product", list);
            }
        }

        public IActionResult Update(string name)
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                var customer = context.TblKhachHangs.Find(name);
                return View("Update", customer);
            }
        }
        [HttpPost]
        public IActionResult Update(TblKhachHang customer)
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                if (ModelState.IsValid)
                {
                    context.TblKhachHangs.Update(customer);
                    context.SaveChanges();
                    var list = context.TblKhachHangs.ToList();
                    return View("Product", list);
                }
                else
                {
                    var list = context.TblKhachHangs.ToList();
                    return View("Product", list);
                }
            }
        }

        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        public IActionResult Add(TblKhachHang customer)
        {
            using (PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                if (ModelState.IsValid)
                {
                    context.TblKhachHangs.Add(customer);
                    context.SaveChanges();
                    var list = context.TblKhachHangs.ToList();
                    return View("Product", list);
                }
                else
                {
                    return View("Add");
                }

            }
        }
        [HttpPost]
        public IActionResult Register(TblUser user)
        {
            using(PRN211_ProjectContext context = new PRN211_ProjectContext())
            {
                if (ModelState.IsValid)
                {
                   
                    context.TblUsers.Add(user);
                    context.SaveChanges();
                    return View("Index");
                }
                else
                {
                    return View("~/Views/Home/Register.cshtml");
                }
            }
        }
    }
}

