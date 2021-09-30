using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Timepass.Models;

namespace Timepass.Controllers
{
    public class TimepassController:Controller
    {
        private readonly IRepository repo;

        public TimepassController(IRepository myrepo)
        {
            repo = myrepo;
        }

        public IActionResult GetUsers()
        {
            var data = repo.GetUsers();
            var single = new List<Timepass.Models.User>();
            List<string> names = repo.GetCountryNames().ToList();
            int i = 0;

            foreach(var d in data)
            {
                single.Add(Mapper.Map1(d, names[i]));
                i++;
            }

            return View(single);
          
        }


        public IActionResult GetMyCountries()
        {
            var data = repo.GetMyCountries();
            var single = new List<Timepass.Models.MyCountry>();
            List<List<string>> usernames = new List<List<string>>();
            int i = 0;
            foreach (var d in data)
            {
                usernames.Add(new List<string>(repo.GetUserNames(d.CountryId)));
            }

            foreach(var d in data)
            {
                single.Add(Mapper.Map2(d, usernames[i]));
                i++;
            }

            return View(single);
        }

    }
}
