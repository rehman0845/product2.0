using Crud_Core.dbModels;
using Crud_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_Core.Services
{
    public static class MappingExtensions
    {
        //category
        public static ProductVM ToModel(this Product entity)
        {
            if (entity == null)
                return null;

            var model = new ProductVM()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                SKU = entity.SKU,
                Price = entity.Price
            };
            return model;
        }

        public static Product ToEntity(this ProductVM model, Product destination)
        {
            if (model == null)
                return destination;

            destination.Id = model.Id;
            destination.Name = model.Name;
            destination.Description = model.Description;
            destination.SKU = model.SKU;
            destination.Price = model.Price;

            return destination;
        }
    }
}
