using And.Eticaret.Core.Model;
using And.Eticaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace And.Eticaret.UI.WEB.Controllers
{
    public class OrderController : AndControllerBase
    {
        // GET: Order
        [Route("Siparisver")]
        public ActionResult AddressList()
        {
            var db = new AndDB();
            var data = db.UserAdresses.Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }
        public ActionResult CreateUserAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUserAddress(UserAddress entity)
        {

            entity.CreateUserID = LoginUserID;
            entity.CreateDate = DateTime.Now;
            entity.IsActive = true;
            entity.UserID = LoginUserID;

            var db = new AndDB();
            db.UserAdresses.Add(entity);
            db.SaveChanges();
            return RedirectToAction("AddressList");
            
        }
        public ActionResult CreateOrder(int id)
        {
            var db = new AndDB();
            var sepet = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserID).ToList();
            Order order = new Order();
            order.CreateUserID = LoginUserID;
            order.CreateDate = DateTime.Now;
            order.StatusID = 1;
            order.TotalProductPrice = sepet.Sum(x => x.Product.Price);
            order.TotalTaxPrice = sepet.Sum(x => x.Product.Tax);
            order.TotalDiscount = sepet.Sum(x => x.Product.Discount);
            order.TotalPrice = order.TotalProductPrice + order.TotalTaxPrice;
            order.UserAddressID = id;
            order.UserID = LoginUserID;
            order.OrderProducts = new List<OrderProduct>();
            foreach (var item in sepet)
            {
                order.OrderProducts.Add(new OrderProduct//urunleri siparise eklemeis olduk
                {
                    CreateDate = DateTime.Now,
                    CreateUserID=LoginUserID,
                     ProductID=item.ProductID,
                     Quantity=item.Quantity

                });
                db.Baskets.Remove(item);//savechangesten sonra baskete bosalticak


            }
            db.Order.Add(order);
            db.SaveChanges();
           
            return RedirectToAction("Detail", new { id = order.ID });
          
            
        }
        public ActionResult Detail(int id)
        {
            var db = new AndDB();
            var data = db.Order.Include("OrderProducts").Include("OrderProducts.Product")
                .Include("OrderPayments").Include("Status")
                .Include("UserAddress").Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }
        [Route("Siparislerim")]
        public ActionResult Index()
        {
            var db = new AndDB();
            var data = db.Order.Include("Status").Where(x => x.UserID == LoginUserID).ToList();
            return View(data);
        }
        public ActionResult Pay(int id)
        {
            var db = new AndDB();
            var order = db.Order.Where(x => x.ID == id).FirstOrDefault();
            order.StatusID = 5;
            db.SaveChanges();

            return RedirectToAction("Detail", new {id=order.ID});
        }

    }
}