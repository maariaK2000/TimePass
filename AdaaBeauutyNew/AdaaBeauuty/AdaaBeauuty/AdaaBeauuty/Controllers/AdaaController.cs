using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Entities;
using AdaaBeauuty.Models;
using System.Data.Entity;

namespace AdaaBeauuty.Controllers
{
    public class AdaaController : Controller
    {
        ProductRepository repo;

        public AdaaController()
        {
            repo = new ProductRepository(new Adaa());
            
        }

        // GET: Adaa
        public ActionResult Index()
        {
            //string str = "";
            var prd = repo.GetProduct();
            var data = new List<AdaaBeauuty.Models.Product>();
            foreach (var p in prd)
            {
                //str += p.PrdName + " ";
                data.Add(Mapper.Map(p));
            }
            return View(data);
        }

        public ActionResult GetProductById(int id)
        {
            //string s = "";
            var prd = repo.GetProductById(id);
            //s = prd.PrdName;
            return View(Mapper.Map(prd));
        }

        //Addin product
        [HttpGet]
        public ActionResult MyProductForm()
        {
            return View();
        }
        [HttpPost]

        public ActionResult MyProductForm(ProductForm product)
        {
            if (ModelState.IsValid)
            {
                repo.AddProduct(Mapper.MapProduct(product));
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditForm(int id)
        {
            return View(repo.GetProductById(id));
        }
        [HttpPost]
        public ActionResult EditForm(int id,product prd)
        {
            try
            {
                using(Adaa db=new Adaa())
                {
                    db.Entry(prd).State = EntityState.Modified;
                    db.SaveChanges();
                 
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();

            }
        }
        //deleteproductbyid
        public string DeleteProductById(int id)
        {
            repo.DeleteProduct(id);
            return "1 product deleted successfully";
        }

        

        //SkinCare
        [Authorize]
        public ActionResult SkinCare()
        {
            return View();
        }
        [Authorize]
        //Toners
        public ActionResult GetToners()
        {
            var prd = repo.GetProduct();
            var data = new List<AdaaBeauuty.Models.Product>();
            foreach (var p in prd)
            {
                if (p.PrdId >= 26 && p.PrdId <= 31)
                {
                    
                    //str += p.PrdName + " ";
                    data.Add(Mapper.Map(p));
                }

            }
            ViewBag.regid = Session["regid"];
            return View(data);
        }

        public JsonResult AddToCart(Cart addcart)
        {
            repo.AddToCart(Mapper.MapCart(addcart));
            HistoryCart hc = new HistoryCart();
            hc.RegisterId = (int)Session["regid"];
            hc.PrdId = addcart.PrdId;
            hc.PrdQuantity = addcart.PrdQuantity;
            repo.AddToHistoryCart(Mapper.MapHistoryCart(hc));
            quantityUpdate(addcart);
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        public void quantityUpdate(Cart addcart)
        {
            int prdid1 = addcart.PrdId;
            var prd = repo.GetProductById(prdid1);
            var currentqnty = prd.PrdQuantity;
            var userqnty = addcart.PrdQuantity;
            var nqnty = currentqnty - userqnty;
            repo.UpdateQuantity(prdid1, nqnty);

        }

       

        //getcartdetails
        public ActionResult GetCart()
        {
            int regid=(int)Session["regid"];
            var mycart = repo.GetCartDetails(regid);
            var cartqnty = repo.GetCart();
            var qnty = new List<int>();
            var actualqnty = new List<int>();
            var data = new List<AdaaBeauuty.Models.CartDetails>();
            var prdname = new List<string>();
            var prdprice = new List<decimal>();
            int i = 0;
            int j = 0;
            decimal total = 0;

            /*foreach(var c in mycart)
            {
                var prd = repo.GetProductById(c.PrdId);
                prdname.Add(prd.PrdName.ToString());
                prdprice.Add(Convert.ToDecimal(prd.PrdPrice));

            }*/
            foreach (var c in cartqnty)
            {
                if (c.RegisterId == 1)
                {
                    actualqnty.Add(c.PrdQuantity);
                }
            }
            foreach (var c in mycart)
            {
                if (actualqnty[j] > 1)
                {
                    for (int k = 0; k < actualqnty[j]; k++)
                    {
                        total += c.PrdPrice;
                    }
                }
                else
                {
                    total += c.PrdPrice;

                }
                j++;
            }
            ViewBag.totalprice = total;

            

            foreach (var c in mycart)
            {
                data.Add(Mapper.MapCartDetails(c));
                var qnty1 = actualqnty[i];
                qnty.Add(qnty1);
                i++;
            }

            /*foreach (var c in mycart)
            {
                data.Add(Mapper.MapCartDetails(c));
                
                var qnty1 = c.PrdQuantity;
                qnty.Add(qnty1);
            }*/
            ViewBag.quantity = qnty;
            return View(data);
            
        }


        //gethistorycartdetails
        public ActionResult GetHistoryCart()
        {
            int regid = (int)Session["regid"];
            var prd = repo.GetHistoryCartDetails(regid);
            var cartqnty = repo.GetCart();
            var qnty = new List<int>();
            var actualqnty = new List<int>();
            var data = new List<AdaaBeauuty.Models.CartDetails>();
            var prdname = new List<string>();
            var prdprice = new List<decimal>();
            int i = 0;
            int j = 0;
            decimal total = 0;

            /*foreach(var c in mycart)
            {
                var prd = repo.GetProductById(c.PrdId);
                prdname.Add(prd.PrdName.ToString());
                prdprice.Add(Convert.ToDecimal(prd.PrdPrice));

            }*/
            foreach (var c in cartqnty)
            {
                if (c.RegisterId == 1)
                {
                    actualqnty.Add(c.PrdQuantity);
                }
            }
            foreach (var c in prd)
            {
                data.Add(Mapper.MapCartDetails(c));
                var qnty1 = actualqnty[i];
                qnty.Add(qnty1);
                i++;
            }

            ViewBag.quantity = qnty;
            return View(data);


        }






        //RemoveItemFromCart
        public JsonResult DeleteCart(int id,int pid)
        {
            repo.DeleteCart(id,pid);
            //return Json("Success");
            return Json("true", JsonRequestBehavior.AllowGet);
        }





    }
}