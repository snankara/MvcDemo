using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        private readonly IHeadingService _headingService;
        private readonly ICategoryService _categoryService;
        private readonly IWriterService _writerService;

        public WriterPanelController(IHeadingService headingService, ICategoryService categoryService, IWriterService writerService)
        {
            _headingService = headingService;
            _categoryService = categoryService;
            _writerService = writerService;
        }

        public ActionResult WriterProfile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllHeading()
        {
            var currentWriter = _writerService.GetByEmail((string)Session["Email"]);
            var headings = _headingService.GetAllByWriterId(currentWriter.WriterId);
            return View(headings);
        }

        [HttpGet]
        public ActionResult HeadingAdd()
        {
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult HeadingAdd(Heading heading)
        {
            heading.WriterId = _writerService.GetByEmail((string)Session["Email"]).WriterId;
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.Status = true;
            _headingService.Add(heading);
            return RedirectToAction("GetAllHeading");
        }

        [HttpGet]
        public ActionResult HeadingUpdate(int id)
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
        public ActionResult HeadingUpdate(Heading heading)
        {
            _headingService.Update(heading);
            return RedirectToAction("GetAllHeading");
        }

        public ActionResult HeadingDelete(int id)
        {
            var heading = _headingService.GetById(id);
            heading.Status = false;
            _headingService.Delete(heading);
            return RedirectToAction("GetAllHeading");
        }

    }
}