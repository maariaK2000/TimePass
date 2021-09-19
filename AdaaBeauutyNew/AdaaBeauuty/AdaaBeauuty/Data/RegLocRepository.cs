using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RegLocRepository
    {
        private Adaa db;
        public RegLocRepository(Adaa db)
        {
            this.db = db;
        }
        public void AddRegLoc(registerlocation regloc)
        {
            db.registerlocations.Add(regloc);
            Save();
        }

        public void DeleteRegLoc(int id)
        {
            var regloc = db.registerlocations.Find(id);
            if (regloc != null)
            {
                db.registerlocations.Remove(regloc);
                Save();
            }
            /*else
                throw new ArgumentException("User is not found");*/
        }

        public registerlocation GetRegLocById(int id)
        {
            if (id > 0)
            {
                var regloc = db.registerlocations
                    .Include("myregister")
                    .Where(p => p.LocationId == id)
                    .FirstOrDefault();
                if (regloc != null)
                    return regloc;
                else
                    return null;
            }
            else
            {
                throw new ArgumentException("Id cannot be less than 0");
            }
        }

        public IEnumerable<registerlocation> GetRegLoc()
        {
            return db.registerlocations
                    .Include("myregister")
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
