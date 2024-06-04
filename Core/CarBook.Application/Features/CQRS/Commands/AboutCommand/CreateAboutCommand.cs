using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommand
{
    //Silme Güncelleme Ekleme crud işlemleri commandda olur.
    public class CreateAboutCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
