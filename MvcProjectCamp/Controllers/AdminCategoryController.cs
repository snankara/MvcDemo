using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public AdminCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //[Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _categoryService.Add(category);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);
            if (category != null)
            {
                _categoryService.Delete(category);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var category = _categoryService.GetById(id);
            if (category != null)
            {
                return View(category);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Update(Category category)
        {
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }

    }
}