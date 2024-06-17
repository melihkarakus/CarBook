using CarBook.Application.Features.CQRS.Commands.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandler
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand updateCar)
        {
            var values = await _repository.GetByIdAsync(updateCar.CarID);
            values.Fuel = updateCar.Fuel;
            values.Transmission = updateCar.Transmission;
            values.BigImageUrl = updateCar.BigImageUrl;
            values.BrandID = updateCar.BrandID;
            values.CoverImageUrl = updateCar.CoverImageUrl;
            values.Km = updateCar.Km;
            values.Model = updateCar.Model;
            values.Seat = updateCar.Seat;
            await _repository.UpdateAsync(values);
        }
    }
}
