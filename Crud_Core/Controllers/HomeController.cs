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

        public JsonResult List()
        {
            try
            {
                var _prodList = crudFactory.GetList();
                return Json(_prodList);
            }
            catch(Exception ex)
            {
                return Json(ex.Message);
            }
            
        }

        // POST: Product/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([FromBody]ProductVM prod)
        {
            try
            {
                // TODO: Add insert logic here
                if (prod != null)
                {
                    crudFactory.CreateProduct(prod);
                    return Json(prod);
                }
                else
                {
                    return Json(new ProductVM());

                }
                //return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        // GET: Product/Edit/5
        public JsonResult GetbyId(int id)
        {
            try
            {
                if (id > 0)
                {
                    var _prod = crudFactory.GetProductById(id);
                    return Json(_prod);
                }
                else
                {
                    return Json(new ProductVM());
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }


        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit([FromBody]ProductVM prod)
        {

            try
            {
                if (prod != null)
                {
                    crudFactory.UpdateProduct(prod);
                    return Json(prod);
                }
                else
                {
                    return Json(new ProductVM());
                }
                // TODO: Add update logic here

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        // GET: Product/Delete/5
        public JsonResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here

                if (id > 0)
                {
                    crudFactory.DeleteProduct(id);
                    return Json(id);
                }
                else
                {
                    return Json(0);
                }

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
    }
}