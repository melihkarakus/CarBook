using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.AboutCommand
{
    //Silme Güncelleme Ekleme crud işlemleri commandda olur.
    public class RemoveAboutCommand
    {
        public RemoveAboutCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
