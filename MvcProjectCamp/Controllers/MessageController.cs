using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public ActionResult Inbox()
        {
            var messages = _messageService.GetAllInbox();
            return View(messages);
        }
        public ActionResult Sendbox()
        {
            var messages = _messageService.GetAllSendbox();
            return View(messages);
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
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            _messageService.Add(message);
            return RedirectToAction("Sendbox");
        }
    }
}