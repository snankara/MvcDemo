using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAdminService _adminService;

        public AuthorizationController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public ActionResult Index()
        {
            var admins = _adminService.GetAll();
            return View(admins);
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            _adminService.Add(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var admin = _adminService.GetById(id);
            if (admin != null)
            {
                return View(admin);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Update(Admin admin)
        {
            _adminService.Update(admin);
            return RedirectToAction("Index");
        }

    }
}