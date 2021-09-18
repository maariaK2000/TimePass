using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdaaBeauuty.Models
{
    public class Mapper
    {
        public static AdaaBeauuty.Models.Product Map(Data.Entities.product prd)
        {
            return new AdaaBeauuty.Models.Product()
            {
                PrdId = prd.PrdId,
                CategoryId = prd.CategoryId,
                PrdName = prd.PrdName,
                PrdQuantity = prd.PrdQuantity,
                PrdPrice = prd.PrdPrice,
                
            };
        }
    }
}