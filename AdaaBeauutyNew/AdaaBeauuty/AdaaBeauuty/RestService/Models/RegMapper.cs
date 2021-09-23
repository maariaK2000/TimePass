using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestService.Models
{
    public class RegMapper
    {
        public static RestService.Models.Register MapReg(Data.Entities.myregister myreg)
        {
            return new RestService.Models.Register()
            {
                RegisterId = myreg.RegisterId,
                UserName = myreg.UserName,
                RegisterPwd = myreg.RegisterPwd,
                RegisterContact = myreg.RegisterContact
            };
        }
    }
}