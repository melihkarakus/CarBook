using CarBook.Application.Features.CQRS.Commands.BannerCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandler
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand updateBanner)
        {
            var values = await _repository.GetByIdAsync(updateBanner.BannerID);
            values.BannerID = updateBanner.BannerID;
            values.Title = updateBanner.Title;
            values.Description = updateBanner.Description;
            values.VideoUrl = updateBanner.VideoUrl;
            values.VideoDescription = updateBanner.VideoDescription;
            await _repository.UpdateAsync(values);
        } 
    }
}
