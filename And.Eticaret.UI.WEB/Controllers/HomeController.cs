using And.Eticaret.Core.Model;
using And.Eticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace And.Eticaret.UI.WEB.Controllers
{
    public class HomeController : AndControllerBase
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Products.OrderByDescending(x => x.CreateDate).Take(5).ToList();
            return View(data);
        }
        AndDB db = new AndDB();
        public PartialViewResult GetMenu()
        {
           
            var menus = db.Categories.Where(x => x.ParentID == 0).ToList();//parentid giris ekrani demek
            return PartialView(menus);

        }
        [Route("Uye-Giris")]
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        [Route("Uye-Giris")]
        public ActionResult Login(string Email,string Password)
        {
            
            var users = db.Users.Where(x => x.Email == Email && x.Password == Password && x.IsActive == true && x.IsAdmin == false).ToList();
            if(users.Count==1)
            {
                //giris yapildi
                Session["LoginUserID"] = users.FirstOrDefault().ID;
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/");//anasayfaya yonlendirdim
            }
            else
            {
                ViewBag.Error = "Hatali Kullanici veya Sifre !!!";
                return View();

            }
             //return View();

        }
        [Route("Uye-Kayit")]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [Route("Uye-Kayit")]
        public ActionResult CreateUser(User entity )
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateUserID = 1;
                entity.IsActive = true;
                entity.IsAdmin = false;

                db.Users.Add(entity);
                db.SaveChanges();
                return Redirect("/");
            }
            catch (Exception ex)
            {

                return View();
            }
            

            
           
        }
    }
}