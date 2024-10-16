﻿using CarBook.Application.Features.Mediator.Results.CarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarQueries
{
    public class GetCarWithBrandByCarIdQuery :IRequest<GetCarWithBrandQueryResult>
    {
        public int Id { get; set; }

		public GetCarWithBrandByCarIdQuery(int id)
		{
			Id = id;
		}
	}
}
