using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetAll();
        //Writer Get(string userName, string password);
        Writer GetById(int id);
        Writer GetByEmail(string email);
        void Add(Writer writer);
        void Update(Writer writer);
        void Delete(Writer writer);
    }
}
