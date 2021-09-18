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
    public class RegisterController : Controller
    {
        
        RegisterRepository regrepo;
        RegLocRepository reglocrepo;
        public RegisterController()
        {
            
            regrepo = new RegisterRepository(new Adaa());
            reglocrepo = new RegLocRepository(new Adaa());
        }

        // GET: Adaa
        public ActionResult Users()
        {
            //string str = "";
            var myreg = regrepo.GetRegistered();
            var data = new List<AdaaBeauuty.Models.Register>();
            foreach (var r in myreg)
            {
                //str += p.PrdName + " ";
                data.Add(RegMapper.Map(r));
            }
            return View(data);
        }

        public ActionResult GetRegisteredById(int id)
        {
            //string s = "";
            var myreg = regrepo.GetRegisteredById(id);
            //s = prd.PrdName;
            return View(RegMapper.Map(myreg));
        }
        // GET: Register
        [HttpGet]
        public ViewResult MyForm()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        public ActionResult MyForm(RegisterViewModel regview)
        {
            if (ModelState.IsValid)
            {
                regrepo.AddRegistered(RegMapper.MapReg1(regview));
                int Idt = new Adaa().myregisters.Max(u => u.RegisterId);
                reglocrepo.AddRegLoc(RegMapper.MapReg2(regview, Idt));
                return RedirectToAction("Users");
            }
            return View(regview);

        }

        public ActionResult RegLoc()
        {
            var regloc = reglocrepo.GetRegLoc();
            var data = new List<AdaaBeauuty.Models.RegLoc>();
            foreach(var rl in regloc)
            {
                data.Add(RegMapper.MapRegLoc(rl));
            }
            return View(data);
        }


    }
}