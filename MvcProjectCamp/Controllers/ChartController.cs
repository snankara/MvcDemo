using Business.Abstract;
using MvcProjectCamp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
        private readonly ICategoryService _categoryService;

        public ChartController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<Category> BlogList()
        {
            var categories = _categoryService.GetAll();
            List<Category> categoriesForChart = new List<Category>();
            foreach (var category in categories)
            {
                categoriesForChart.Add(new Category {CategoryName = category.Name, CategoryCount = category.Headings.Count });
            }

            return categoriesForChart;
        }
    }
}