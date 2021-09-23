using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdaaBeauuty.Models
{
    public class NewPassword
    {
        [DisplayName("Enter your registered contact")]
        public string RegisterContact { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Enter your new Password")]
        public string RegisterPwd { get; set; }

    }
}