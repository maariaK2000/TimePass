using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestService.Models
{
    public class Register
    {
        public int RegisterId { get; set; }
        public string UserName { get; set; }
        public string RegisterPwd { get; set; }
        public string RegisterContact { get; set; }

    }
}