using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_Core.dbModels;
using Crud_Core.Factories;
using Crud_Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Core.Controllers
{
    public class ProductController : Controller
    {
        private readonly EFContext ctx;
        private readonly ICrudFactory crudFactory;
        public ProductController(EFContext eFContext, ICrudFactory _crudFactory)
        {
            ctx = eFContext;
            crudFactory = _crudFactory;
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product/Details/5
        public ActionResult List()
        {
            var _prodList = crudFactory.GetList();
            return View(_prodList);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM prod)
        {
            try
            {
                // TODO: Add insert logic here
                //if (ModelState.IsValid)
                //{
                    crudFactory.CreateProduct(prod);
                //}
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult GetbyId(int id)
        {
            var _prod = crudFactory.GetProductById(id);
            return View(_prod);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductVM prod)
        {
            try
            {
                // TODO: Add update logic here
                crudFactory.UpdateProduct(prod);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            crudFactory.DeleteProduct(id);
            return View();
        }

        //// POST: Product/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}