using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Entities;
using System.Data.Entity;
using AdaaBeauuty.Models;
using System.Web.Security;

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

        public ActionResult GetRegLocById(int id)
        {
            var regloc = reglocrepo.GetRegLocById(id);
            return View(RegMapper.MapRegLoc(regloc));
        }


        public string DeleteUser(int id)
        {
            reglocrepo.DeleteRegLoc(id);
            regrepo.DeleteRegistered(id);
            return "1 user deleted successfully";
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
                return RedirectToAction("Login");
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


        //NewLogic

        public ActionResult showall()
        {
            var users = GetUsers();
            var locusers = GetLocUsers();

            RegisterCombined rc = new RegisterCombined();
            rc.Registers = users;
            rc.RegLocs = locusers;

            return View(rc);
        }

        public List<AdaaBeauuty.Models.Register> GetUsers()
        {
            var users = regrepo.GetRegistered();
            var data = new List<AdaaBeauuty.Models.Register>();
            foreach (var u in users)
            {
                data.Add(RegMapper.Map(u));
            }
            return data;
        }

        public List<AdaaBeauuty.Models.RegLoc> GetLocUsers()
        {
            var locusers = reglocrepo.GetRegLoc();
            var data = new List<AdaaBeauuty.Models.RegLoc>();
            foreach (var lu in locusers)
            {
                data.Add(RegMapper.MapRegLoc(lu));
            }
            return data;
        }

        //Edit Users
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(new Adaa().myregisters.Where(r=>r.RegisterId==id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id,myregister myreg)
        {
            try
            {
                using(Adaa db=new Adaa())
                {
                    db.Entry(myreg).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("showall");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditLoc(int id)
        {
            return View(new Adaa().registerlocations.Where(r => r.RegisterId == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult EditLoc(int id,registerlocation regloc)
        {
            try
            {
                using(Adaa db=new Adaa())
                {
                    regloc.RegisterId = id;
                    db.Entry(regloc).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("showall");

            }
            catch
            {
                return View();
            }
        }
        public ActionResult MyAdmin()
        {
            return View();
        }

        //Login form
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login log,myregister myreg)
        {
            var userDetails = new Adaa().myregisters.Where(r => r.UserName == log.UserName && r.RegisterPwd == log.RegisterPwd).FirstOrDefault();
            if (userDetails == null)
            {
                log.LoginErrorMessage = "Sorry! U ain't an authenticated user";
                return View("Login", log);
            }
            else
            {
                
                Session["regid"] = userDetails.RegisterId;
                Session["regname"] = log.UserName;
                //TempData["id"] = Session["regid"];
                FormsAuthentication.SetAuthCookie(log.UserName, false);
                return RedirectToAction("Index","Home");
            }

        }
        //Newpassword
        [HttpGet]
        public ActionResult NewPassword()
        {
            return View();

        }
        [HttpPost]
        public ActionResult NewPassword(NewPassword npwd)
        {
            if (ModelState.IsValid)
            {
                regrepo.NewPassword(npwd.RegisterContact, npwd.RegisterPwd);
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
            
        }

        //Logout
        public ActionResult Logout()
        {
            int regid = (int)Session["regid"];
            if (regid != 0)
            {
                Session.Abandon();
                return RedirectToAction("Home", "Login");

            }
            return View();
        }

    }
}