using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timepass.Models
{
    public class Mapper
    {
        public static Timepass.Models.User Map1(Data.Entities.User user,string name)
        {
            return new Timepass.Models.User()
            {
                Id = user.Id,
                Name = user.Name,
                Age = user.Age,
                CountryName = name
            };

        }


        public static Timepass.Models.MyCountry Map2(Data.Entities.MyCountry country,IEnumerable<string> usernames)
        {
            return new Timepass.Models.MyCountry()
            {
                Id = country.CountryId,
                Name = country.Name,
                UserNames = usernames
            };
        }

    }
}
