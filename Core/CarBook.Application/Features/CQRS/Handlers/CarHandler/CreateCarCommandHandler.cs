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
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand createCar)
        {
            await _repository.CreateAsync(new Car
            {
                BigImageUrl = createCar.BigImageUrl,
                Luggage = createCar.Luggage,
                Km = createCar.Km,
                Model = createCar.Model,
                Seat = createCar.Seat,
                Transmission = createCar.Transmission,
                CoverImageUrl = createCar.CoverImageUrl,
                BrandID = createCar.BrandID,
                Fuel = createCar.Fuel
            });
        }
    }
}
