using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        ICategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
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
            _categoryService.Add(category);
            return RedirectToAction("GetAll");
        }

    }
}