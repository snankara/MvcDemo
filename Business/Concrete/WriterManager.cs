using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WriterManager : IWriterService
    {
        private readonly IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Add(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public Writer Get(string userName, string password)
        {
            return _writerDal.Get(w => w.Email == userName && w.Password == password);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer GetByEmail(string email)
        {
            return _writerDal.Get(w => w.Email == email);
        }

        public Writer GetById(int id)
        {
            return _writerDal.GetById(w => w.WriterId == id);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
