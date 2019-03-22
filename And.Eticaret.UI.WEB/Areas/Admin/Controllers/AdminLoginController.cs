using And.Eticaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace And.Eticaret.UI.WEB.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        AndDB db = new AndDB();
        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email,string Password)
        {
            //asagida tum verilerimi attim
            var data = db.Users.Where(x => x.Email == Email && x.Password == Password && x.IsAdmin==true && x.IsActive==true).ToList();
                if(data.Count==1)
            {
                //dogru giris yapildi
                Session["AdminLoginUser"] = data.FirstOrDefault();//admin olarak giris yapmis mi yapmamis mi
                return Redirect("/admin");
            }
                else
            {
                return View();

            }
           
        }
    }
}