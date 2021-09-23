using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductRepository
    {
        private Adaa db;
        public ProductRepository(Adaa db)
        {
            this.db = db;
        }
        public void AddProduct(product prd)
        {
            db.products.Add(prd);
            Save();
        }

        public void DeleteProduct(int id)
        {
            var prd = db.products.Find(id);
            if (prd != null)
            {
                db.products.Remove(prd);
                Save();
            }
            else
                throw new ArgumentException("Product is not found");
        }
        //deletfromcart

        public void DeleteCart(int id,int pid)
        {
            var cart = db.customercarts.Where(c => c.RegisterId == id && c.PrdId==pid).FirstOrDefault();
            db.customercarts.Remove(cart);

            Save();
        }

        public product GetProductById(int id)
        {
            if (id > 0)
            {
                var prd = db.products
                    .Include("category")
                    .Where(p => p.PrdId == id)
                    .FirstOrDefault();
                if (prd != null)
                    return prd;
                else
                    return null;
            }
            else
            {
                throw new ArgumentException("Id cannot be less than 0");
            }
        }

        public IEnumerable<product> GetProduct()
        {
            return db.products
                    .Include("category")
                    .ToList();
        }

        //GetToners
        public product GetToners()
        {
            return db.products
                     .Include("category")
                     .Where(p => p.PrdId==26)
                     .FirstOrDefault();
        }

        /*public void UpdateProduct(int id)
        {
            var prd = db.products.Find(id);
            if (prd != null)
            {
                db.products.Update;
                Save();
            }
            else
                throw new ArgumentException("Product is not found");

        }*/

        public void UpdateQuantity(int id,int nqnty)
        {
            var prd = db.products.Where(p=>p.PrdId==id).FirstOrDefault();
            prd.PrdQuantity = nqnty;
            Save();

        }
        
        public void AddToCart(customercart cart)
        {
            db.customercarts.Add(cart);
            Save();
        }
        public void AddToHistoryCart(historycart cart)
        {
            db.historycarts.Add(cart);
            Save();
        }
        public IEnumerable<customercart> GetCart()
        {
            return db.customercarts
                .Include("myregister")
                .Include("product")
                .ToList();

        }

        public IEnumerable<product> GetCartDetails(int regid)
        {
            var li = new List<product>();
            var product = db.customercarts
                .Where(c => c.RegisterId == regid)
                .ToList();
            foreach(var p in product)
            {
                li.Add(db.products.Where(m => m.PrdId == p.PrdId).FirstOrDefault());
            }
            return li;
        }

        public IEnumerable<product> GetHistoryCartDetails(int regid)
        {
            var li = new List<product>();
            var product = db.historycarts
                .Where(c => c.RegisterId == regid)
                .ToList();
            foreach (var p in product)
            {
                li.Add(db.products.Where(m => m.PrdId == p.PrdId).FirstOrDefault());
            }
            return li;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
