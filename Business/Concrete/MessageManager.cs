﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetAllInbox()
        {
            return _messageDal.GetAll(m => m.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetAllSendbox()
        {
            return _messageDal.GetAll(m => m.SenderMail == "admin@gmail.com");
        }

        public Message GetById(int id)
        {
            return _messageDal.GetById(m => m.MessageId == id);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
