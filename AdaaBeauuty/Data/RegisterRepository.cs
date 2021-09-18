using System;
using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using System.Data.Entity.Migrations;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RegisterRepository
    {
        private Adaa db;
        public RegisterRepository(Adaa db)
        {
            this.db = db;
        }
        public void AddRegistered(myregister myreg)
        {
            db.myregisters.Add(myreg);
            Save();
        }

        public void DeleteRegistered(int id)
        {
            var myreg = db.myregisters.Find(id);
            if (myreg != null)
            {
                db.myregisters.Remove(myreg);
                Save();
            }
            else
                throw new ArgumentException("Product is not found");
        }

        public myregister GetRegisteredById(int id)
        {
            if (id > 0)
            {
                var myreg = db.myregisters
                    .Where(p => p.RegisterId == id)
                    .FirstOrDefault();
                if (myreg != null)
                    return myreg;
                else
                    return null;
            }
            else
            {
                throw new ArgumentException("Id cannot be less than 0");
            }
        }

        public IEnumerable<myregister> GetRegistered()
        {
            return db.myregisters
                    .ToList();
        }

        public void UpdateProduct(int id)
        {
            var myreg = db.myregisters.Find(id);
            if (myreg != null)
            {
                db.myregisters.AddOrUpdate(myreg);
                Save();
            }
            else
                throw new ArgumentException("Product is not found");

        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
