using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entites
{
    public class CarPricing
    {
        public int CarPricingID { get; set; }
        public int CarID { get; set; }
        public Car Cars { get; set; }
        public int PricingID { get; set; }
        public Pricing Pricings { get; set; }
        public decimal Amount { get; set; }
    }
}
