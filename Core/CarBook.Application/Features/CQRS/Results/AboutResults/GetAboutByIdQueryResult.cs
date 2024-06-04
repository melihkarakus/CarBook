using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.AboutResults
{
    //Propertyler gelecektir. Database yansıtılmış olan sınıflar.
    public class GetAboutByIdQueryResult
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
