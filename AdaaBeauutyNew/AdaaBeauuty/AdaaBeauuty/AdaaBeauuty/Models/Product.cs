using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AdaaBeauuty.Models
{
    public class Product
    {
        [DisplayName("Product Id")]
        public int PrdId { get; set; }

        public int RegisterId { get; set; }

        [DisplayName("Category Id")]
        public int CategoryId { get; set; }
        [DisplayName("Product Name")]
        public string PrdName { get; set; }
        [DisplayName("Product Quantity")]
        public int PrdQuantity { get; set; }
        [DisplayName("Product Price")]
        public decimal? PrdPrice { get; set; }

    }
}