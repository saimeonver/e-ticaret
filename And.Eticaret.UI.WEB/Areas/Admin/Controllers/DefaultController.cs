using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace And.Eticaret.UI.WEB.Areas.Admin.Controllers
{
    public class DefaultController : AdminControllerBase//bu benimcontrollerimda mvc den turuyor ne yazdigim onemi degil aslinda
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}