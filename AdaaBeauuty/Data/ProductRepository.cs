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
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
