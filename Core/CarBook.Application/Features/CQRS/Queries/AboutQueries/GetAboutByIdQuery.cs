﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.AboutQueries
{
    //Şartlı işlemler için burası yazılır.
    public class GetAboutByIdQuery
    {
        public GetAboutByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
