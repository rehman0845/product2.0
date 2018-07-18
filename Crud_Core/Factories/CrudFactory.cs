using Crud_Core.dbModels;
using Crud_Core.Models;
using Crud_Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Core.Factories
{
    public class CrudFactory : ICrudFactory
    {
        private readonly EFContext _ctx;

        public CrudFactory(EFContext ctx)
        {
            _ctx = ctx;
        }

        public List<ProductVM> GetList()
        {
            var prods= _ctx.Products.ToList();
            var ProdList = new List<ProductVM>();
            foreach(var prod in prods)
            {
                ProdList.Add(prod.ToModel());
            }
            return ProdList;
        }

        public ProductVM GetProductById(int Id)
        {
            var prod= _ctx.Products.Where(p=>p.Id==Id).FirstOrDefault();
            return prod.ToModel();
        }

        public bool UpdateProduct(ProductVM prod)
        {
            var _prod = _ctx.Products.Where(p => p.Id == prod.Id).FirstOrDefault();
            _prod = prod.ToEntity(_prod);
            _ctx.SaveChanges();
            return true;
        }
        public bool CreateProduct(ProductVM prod)
        {
            var _prod = new Product();
            _ctx.Products.Add(prod.ToEntity(_prod));
            _ctx.SaveChanges();
            return true;
        }
        public bool DeleteProduct(int Id)
        {
            var _prod = _ctx.Products.Where(p => p.Id == Id).FirstOrDefault();
            _ctx.Products.Remove(_prod);
            _ctx.SaveChanges();
            return true;
        }
    }
}
