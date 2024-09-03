using CarBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository
    {
        public List<Blog> GetLast3BlogWithAuthors();
        public List<Blog> GetAllBlogWithAuthors();
        public List<Blog> GetBlogByAuthorId(int id);
    }
}
