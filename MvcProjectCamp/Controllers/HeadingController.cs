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
    public class HeadingController : Controller
    {
        private readonly IHeadingService _headingService;
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;

        public HeadingController(IHeadingService headingService, ICategoryService categoryService, IWriterService writerService)
        {
            _headingService = headingService;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        public ActionResult Index()
        {
            var headings = _headingService.GetAll();
            return View(headings);
        }

        public ActionResult HeadingReport()
        {
            var headings = _headingService.GetAll();
            return View(headings);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            List<SelectListItem> writers = (from x in _writerService.GetAll()
                                            select new SelectListItem
                                            {
                                                Text = x.FirstName + " " + x.LastName,
                                                Value = x.WriterId.ToString()
                                            }).ToList();

            ViewBag.categories = categories;
            ViewBag.writers = writers;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Heading heading)
        {
            _headingService.Add(heading);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            var heading = _headingService.GetById(id);
            ViewBag.categories = categories;
            return View(heading);
        }

        [HttpPost]
        public ActionResult Update(Heading heading)
        {
            _headingService.Update(heading);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var heading = _headingService.GetById(id);
            heading.Status = false;
            _headingService.Delete(heading);
            return RedirectToAction("Index");
        }
    }
}