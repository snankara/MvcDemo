using Business.Abstract;
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

        public HeadingController(IHeadingService headingService)
        {
            _headingService = headingService;
        }

        public ActionResult Index()
        {
            var headings = _headingService.GetAll();
            return View(headings);
        }
    }
}