using Crud_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Core.Factories
{
    public interface ICrudFactory
    {
        List<ProductVM> GetList();
        ProductVM GetProductById(int Id);
        bool UpdateProduct(ProductVM prod);
        bool CreateProduct(ProductVM prod);
        bool DeleteProduct(int Id);
    }
}
