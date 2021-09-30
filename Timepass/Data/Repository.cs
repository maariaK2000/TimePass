using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository:IRepository
    {
        CustomerDbContext db;

        public Repository(CustomerDbContext context)
        {
            db = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public IEnumerable<string> GetCountryNames()
        {
            var data = db.MyCountries.ToList();
            List<string> countrynames = new List<string>();
            foreach(var d in data)
            {
                countrynames.Add(d.Name);
            }
            return countrynames;
        }

        public IEnumerable<MyCountry> GetMyCountries()
        {
            return db.MyCountries.ToList();
        }

        public List<string> GetUserNames(int id)
        {
            var data = db.Users.Where(c => c.CountryId == id).ToList();
            List<string> names = new List<string>();
            foreach(var d in data)
            {
                names.Add(d.Name);
            }
            return names;
        }


    }
}
