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
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;

        public LoginController(IAdminService adminService)
        {
            _adminService = adminService;
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

    }
}