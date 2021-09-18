using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdaaBeauuty.Models
{
    public class RegMapper
    {
        public static AdaaBeauuty.Models.Register Map(Data.Entities.myregister myreg)
        {
            return new AdaaBeauuty.Models.Register()
            {
                RegisterId = myreg.RegisterId,
                UserName = myreg.UserName,
                RegisterPwd = myreg.RegisterPwd,
                RegisterContact = myreg.RegisterContact,
            
            };
        }

        public static AdaaBeauuty.Models.RegLoc MapRegLoc(Data.Entities.registerlocation regloc)
        {
            return new AdaaBeauuty.Models.RegLoc()
            {
                LocationId=regloc.LocationId,
                RegisterId=regloc.RegisterId,
                EmailId = regloc.EmailId,
                UserLocation = regloc.UserLocation,
                

            };
        }

        public static Data.Entities.myregister MapReg1(AdaaBeauuty.Models.RegisterViewModel regview)
        {
            return new Data.Entities.myregister()
            {
                RegisterId=regview.RegisterId,
                UserName = regview.UserName,
                RegisterPwd = regview.RegisterPwd,
                RegisterContact=regview.RegisterContact,
            };
        }

        public static Data.Entities.registerlocation MapReg2(AdaaBeauuty.Models.RegisterViewModel regview,int regid)
        {
            return new Data.Entities.registerlocation()
            {
                LocationId=regview.LocationId,
                RegisterId = regid,
                EmailId=regview.EmailId,
                UserLocation=regview.UserLocation,
            };
        }
    }
}