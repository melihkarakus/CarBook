using CarBook.Application.Features.CQRS.Commands.AboutCommand;
using CarBook.Application.Features.CQRS.Commands.ContactCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandler
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand updateContact)
        {
            var values = await _repository.GetByIdAsync(updateContact.ContactID);
            values.Email = updateContact.Email;
            values.SendDate = updateContact.SendDate;
            values.Subject = updateContact.Subject;
            values.Message = updateContact.Message;
            values.ContactID = updateContact.ContactID;
            values.Name = updateContact.Name;   
            await _repository.UpdateAsync(values);
        }
    }
}
