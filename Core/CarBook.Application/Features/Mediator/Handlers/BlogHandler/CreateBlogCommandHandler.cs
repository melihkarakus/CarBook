using CarBook.Application.Features.Mediator.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandler
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Blog
            {
                CategoryID = request.CategoryID,
                AuthorID = request.AuthorID,
                CoverImageUrl = request.CoverImageUrl,
                CreatedDate = request.CreatedDate,
                Title = request.Title,
            });
        }
    }
}
