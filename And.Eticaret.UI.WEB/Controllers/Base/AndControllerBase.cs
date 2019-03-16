using And.Eticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace And.Eticaret.UI.WEB
{
    public class AndControllerBase:Controller
    {
        //kullanici login kontrolu
        public bool IsLogin { get; private set; }
        //giris yapmis kisinin ID si
        public int LoginUserID { get;private set; }//private ile disaridan veri girilmesini engelliyorum

        public User LoginUserEntity { get;private set; }//login olmus kisinin butun bilgilerini buraya aticam

        protected override void Initialize(RequestContext requestContext)
        {
            //Session["LoginUserID"] 
            //Session["LoginUser"]
            if (requestContext.HttpContext.Session["LoginUserID"]!=null)//ana objeden cekildigi icin requestContext.HttpContext kullanildi
                //session da cunku bir property
            {//kullanici giris yapmis
                IsLogin = true;
                LoginUserID = (int)requestContext.HttpContext.Session["LoginUserID"];
                LoginUserEntity = (Core.Model.Entity.User)requestContext.HttpContext.Session["LoginUser"];
            }
            base.Initialize(requestContext);
        }
    }
}