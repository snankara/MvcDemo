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
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public ActionResult Index()
        {
            var writers = _writerService.GetAll();
            return View(writers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Writer writer)
        {
            _writerService.Add(writer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var writer = _writerService.GetById(id);
            return View(writer);
        }

        [HttpPost]
        public ActionResult Update(Writer writer)
        {
            _writerService.Update(writer);
            return RedirectToAction("Index");
        }
    }
}