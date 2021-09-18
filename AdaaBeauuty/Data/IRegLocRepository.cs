using System;
using System.Collections.Generic;
using Data.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    interface IRegLocRepository
    {
        IEnumerable<registerlocation> GetRegLoc();
        registerlocation GetRegLocById(int id);
        void AddRegLoc(product prd);
        //void UpdateRegLoc(int id);
        void DeleteRegLoc(int id);
        void Save();
    }
}
