using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdaaBeauuty.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public int RegisterId { get; set; }
        public int PrdId { get; set; }
        public int PrdQuantity { get; set; }
    }
}