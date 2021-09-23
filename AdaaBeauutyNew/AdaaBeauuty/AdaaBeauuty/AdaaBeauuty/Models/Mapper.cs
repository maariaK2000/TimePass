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

        public static Data.Entities.customercart MapCart(AdaaBeauuty.Models.Cart cart)
        {
            return new Data.Entities.customercart()
            {
                CartId = cart.CartId,
                RegisterId = cart.RegisterId,
                PrdId = cart.PrdId,
                PrdQuantity=cart.PrdQuantity,
            };
        }
        public static AdaaBeauuty.Models.CartView MapCart1(Data.Entities.customercart cart,string prdname,decimal? prdprice)
        {
            return new AdaaBeauuty.Models.CartView()
            {
                PrdName = prdname,
                PrdPrice = prdprice,
                PrdQuantity = cart.PrdQuantity,
            };
        }

        public static AdaaBeauuty.Models.CartDetails MapCartDetails(Data.Entities.product prd)
        {
            return new AdaaBeauuty.Models.CartDetails()
            {
                PrdId = prd.PrdId,
                CategoryId = prd.CategoryId,
                PrdName = prd.PrdName,
                PrdQuantity = prd.PrdQuantity,
                PrdPrice = prd.PrdPrice,

            };
        }

        //Add product in database
        public static Data.Entities.product MapProduct(AdaaBeauuty.Models.ProductForm prd)
        {
            return new Data.Entities.product()
            {
                PrdId = prd.PrdId,
                CategoryId = prd.CategoryId,
                PrdName = prd.PrdName,
                PrdQuantity = prd.PrdQuantity,
                PrdPrice = prd.PrdPrice,

            };

        }

        //historycart
        public static Data.Entities.historycart MapHistoryCart(AdaaBeauuty.Models.HistoryCart hs)
        {
            return new Data.Entities.historycart()
            {
                RegisterId = hs.RegisterId,
                PrdId = hs.PrdId,
                PrdQuantity = hs.PrdQuantity,

            };

        }

        public static AdaaBeauuty.Models.HistoryCartView MapHistoryCartView(Data.Entities.product prd)
        {
            return new AdaaBeauuty.Models.HistoryCartView()
            {
                PrdName = prd.PrdName,
                PrdPrice=prd.PrdPrice,
            };
        }



    }
}