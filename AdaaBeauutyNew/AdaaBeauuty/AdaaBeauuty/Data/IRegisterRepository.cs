using System;
using System.Collections.Generic;
using Data.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    interface IRegisterRepository
    {
        IEnumerable<myregister> GetRegistered();
        myregister GetRegisteredById(int id);
        void AddRegistered(myregister myreg);
        void UpdateRegistered(int id);
        void DeleteRegistered(int id);
        void Save();


    }
}
