using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace And.Eticaret.UI.WEB.Areas.Admin
{
    public class AdminControllerBase:Controller
    {
        protected override void Initialize(RequestContext requestContext)//admin giris yapmis mi yapmamis midiye her seferinde bakiyorum
        {
            var IsLogin = false;
            if(requestContext.HttpContext.Session["AdminLoginUser"]==null)
            {
                //admin girisi yok
                requestContext.HttpContext.Response.Redirect("/Admin/AdminLogin");
              
            }
            else
            { base.Initialize(requestContext);
                //admin giris basarili
            }
           
        }
    }
}