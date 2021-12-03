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
    public class ContentManager : IContentService
    {
        private readonly IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Add(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        public Content GetById(int id)
        {
            return _contentDal.GetById(c => c.ContentId == id);
        }

        public List<Content> GetContentByHeadingId(int id)
        {
            return _contentDal.GetAll(c => c.HeadingId == id);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
