using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdaaBeauuty.Models
{
    public class CartDetails
    {
        public int PrdId { get; set; }

        public int RegisterId { get; set; }

        public int CategoryId { get; set; }

        public string PrdName { get; set; }

        public int PrdQuantity { get; set; }

        public decimal? PrdPrice { get; set; }
    }
}