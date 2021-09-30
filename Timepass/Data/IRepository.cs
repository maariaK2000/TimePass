using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data
{
    public interface IRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<MyCountry> GetMyCountries();

        IEnumerable<string> GetCountryNames();

        List<string> GetUserNames(int id);


    }
}
