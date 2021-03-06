using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        private readonly IMessageService _messageService;

        public WriterPanelMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public ActionResult Inbox()
        {
            var messages = _messageService.GetAllInbox((string)Session["Email"]);
            return View(messages);
        }

        public ActionResult Sendbox()
        {
            var messages = _messageService.GetAllSendbox((string)Session["Email"]);
            return View(messages);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var message = _messageService.GetById(id);
            return View(message);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var contact = _messageService.GetById(id);
            return View(contact);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Message message)
        {
            message.SenderMail = (string)Session["Email"];
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _messageService.Add(message);
            return RedirectToAction("Sendbox");
        }
    }
}