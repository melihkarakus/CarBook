using CarBook.Application.Features.CQRS.Commands.CategoryCommand;
using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandler;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandler
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateContactCommand createContact)
        {
            await _repository.CreateAsync(new Contact
            {
                Email = createContact.Email,
                Name = createContact.Name,
                Message = createContact.Message,
                SendDate = createContact.SendDate,
                Subject = createContact.Subject,
            });
        }
    }
}
