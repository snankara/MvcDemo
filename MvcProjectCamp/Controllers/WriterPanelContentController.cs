using Business.Abstract;
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

        public WriterPanelContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ActionResult GetAllContent()
        {
            var contents = _contentService.GetContentByWriterId();
            return View(contents);
        }
    }
}