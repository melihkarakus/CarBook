using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _comment;

        public CommentsController(IGenericRepository<Comment> comment)
        {
            _comment = comment;
        }
        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _comment.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            
            _comment.Create(comment);
            return Ok("Ekleme işlemi başarılı.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var values = _comment.GetById(id);
            _comment.Remove(values);
            return Ok("Silme işlemi başarılı");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _comment.Update(comment);
            return Ok("Güncelleme işlemi başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _comment.GetById(id);
            return Ok(values);
        }
    }
}
