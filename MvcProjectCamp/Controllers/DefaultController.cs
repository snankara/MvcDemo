using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHeadingService _headingService;
        private readonly IContentService _contentService;

        public DefaultController(IHeadingService headingService, IContentService contentService)
        {
            _headingService = headingService;
            _contentService = contentService;
        }

        public PartialViewResult Index(int id = 0)
        {
            var contents = _contentService.GetContentByHeadingId(id);
            return PartialView(contents);
        }
        public ActionResult Headings()
        {
            var headings = _headingService.GetAll();
            return View(headings);
        }
    }
}