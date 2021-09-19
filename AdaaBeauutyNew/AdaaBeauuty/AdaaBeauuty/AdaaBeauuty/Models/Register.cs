using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdaaBeauuty.Models
{
    public class Register
    {
        [DisplayName("Registration Id")]
        public int RegisterId{ get; set; }

        [DisplayName("Username")]
        public string UserName { get; set; }

        [DisplayName("Registration Password")]
        public string RegisterPwd { get; set; }

        [DisplayName("Registration Contact Number")]
        public string RegisterContact { get; set; }

    }
}