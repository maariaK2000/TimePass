using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Entities;
using AdaaBeauuty.Models;

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

    }
}