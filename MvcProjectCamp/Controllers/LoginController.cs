using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IWriterService _writerService;

        public LoginController(IAdminService adminService, IWriterService writerService)
        {
            _adminService = adminService;
            _writerService = writerService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var adminInfo = _adminService.Get(admin.UserName, admin.Password);

            if (adminInfo == null)
            {
                return RedirectToAction("Index");
            }

            FormsAuthentication.SetAuthCookie(adminInfo.UserName, false);
            Session["UserName"] = adminInfo.UserName;
            return RedirectToAction("Index", "AdminCategory");
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var writerInfo = _writerService.Get(writer.Email, writer.Password);
            if (writerInfo == null)
            {
                return RedirectToAction("WriterLogin");
            }

            FormsAuthentication.SetAuthCookie(writerInfo.Email, false);
            Session["Email"] = writerInfo.Email;
            return RedirectToAction("GetAllContent", "WriterPanelContent");
        }

    }
}