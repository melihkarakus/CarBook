using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repostories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _Context;

        public BlogRepository(CarBookContext context)
        {
            _Context = context;
        }

        public List<Blog> GetAllBlogWithAuthors()
        {
            var values = _Context.Blogs.Include(x => x.Author).Include(y => y.Category).ToList();
            return values;
        }

        public List<Blog> GetBlogByAuthorId(int id)
        {
            var values = _Context.Blogs.Include(x => x.Author).Where(y => y.BlogID == id).ToList();
            return values;
        }

        public List<Blog> GetLast3BlogWithAuthors()
        {
            var values = _Context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToList();
            return values;
        }
    }
}
