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
    public class HomeController : Controller
    {
        private readonly EFContext ctx;
        private readonly ICrudFactory crudFactory;
        public HomeController(EFContext eFContext, ICrudFactory _crudFactory)
        {
            ctx = eFContext;
            crudFactory = _crudFactory;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var _prodList = crudFactory.GetList();
            return Json(_prodList);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([FromBody]ProductVM prod)
        {
            try
            {
                // TODO: Add insert logic here
                //if (ModelState.IsValid)
                //{
                crudFactory.CreateProduct(prod);
                //}
                return Json(prod);
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Json(string.Empty);
            }
        }

        // GET: Product/Edit/5
        public ActionResult GetbyId(int id)
        {
            var _prod = crudFactory.GetProductById(id);
            return Json(_prod);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([FromBody]ProductVM prod)
        {

            try
            {
                // TODO: Add update logic here
                crudFactory.UpdateProduct(prod);
                return Json(prod);
            }
            catch
            {
                return Json(string.Empty);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            crudFactory.DeleteProduct(id);
            return Json(id);
        }
    }
}