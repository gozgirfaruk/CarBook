﻿using CarBook.Application.Features.Mediator.Results.CategoryResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CategoryQueries
{
    public class GetByIdCategoryQuery : IRequest<GetByIdCategoryQueryResult>
    {
        public int  Id { get; set; }
        public GetByIdCategoryQuery(int id)
        {
                Id = id;
        }
    }
}
