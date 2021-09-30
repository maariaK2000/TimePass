using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Timepass.Models
{
    public class MyCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<string> UserNames { get; set; } 
    }
}
