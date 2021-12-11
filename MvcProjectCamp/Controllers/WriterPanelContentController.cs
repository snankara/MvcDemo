using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IWriterService _writerService;
        public WriterPanelContentController(IContentService contentService, IWriterService writerService)
        {
            _contentService = contentService;
            _writerService = writerService;
        }

        public ActionResult GetAllContent()
        {
            var currentWriter = _writerService.GetByEmail((string)Session["Email"]);
            var contents = _contentService.GetContentByWriterId(currentWriter.WriterId);
            return View(contents);
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            ViewBag.headingId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Content content)
        {
            content.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = _writerService.GetByEmail((string)Session["Email"]).WriterId;
            content.Status = true;
            _contentService.Add(content);
            return RedirectToAction("GetAllContent");
        }
    }
}