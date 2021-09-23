using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using Data.Entities;
using RestService.Models;

namespace RestService.Controllers
{
    public class RegisterController : ApiController
    {
        RegisterRepository repo;
        public RegisterController()
        {
            repo = new RegisterRepository(new Adaa());
        }
        [HttpGet]
        public IHttpActionResult GetRegistered()
        {
            var myreg = repo.GetRegistered();
            var data = new List<Register>();
            foreach(var d in myreg)
            {
                data.Add(RegMapper.MapReg(d));
            }
            if (myreg.Count() > 0)
            {
                return Ok(data);
            }
            else
            {
                return NotFound();
            }

        }



    }
}
