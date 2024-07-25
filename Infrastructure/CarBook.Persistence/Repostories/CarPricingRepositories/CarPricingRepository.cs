using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entites;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repostories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            //Include(x => x.Brand).Include(y => y.CarPricings).ThenInclude(z => z.Pricings).ToList();
            var values = _context.CarPricings.Include(x => x.Cars).ThenInclude(y => y.Brand).Include(x => x.Pricings).Where(z => z.PricingID == 2).ToList();
            return values;
        }
    }
}
