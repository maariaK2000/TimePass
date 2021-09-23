using System;
using Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    interface IProductRepository
    {
        IEnumerable<product> GetProduct();
        //product GetProductById(int id);
        void AddProduct(product prd);
        //void UpdateProduct(int id);
        void DeleteProduct(int id);
        void Save();

        product GetToners();
    }
}
