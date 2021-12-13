using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ActionResult GetAll(string key)
        {
            var contents = _contentService.GetAll();
            if (!string.IsNullOrEmpty(key))
            {
                contents = _contentService.GetFilteredContent(key);
            }

            return View(contents);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contents = _contentService.GetContentByHeadingId(id);
            return View(contents);
        }

    }
}