using Business.Abstract;
using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
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
        [ValidationAspect(typeof(CategoryValidator))]
        public ActionResult Add(Category category)
        {
            //CategoryValidator categoryValidator = new CategoryValidator();
            //ValidationResult validationResults = categoryValidator.Validate(category);
            //if (!validationResults.IsValid)
            //{
            //    foreach (var item in validationResults.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //        return View();
            //    }
            //}

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