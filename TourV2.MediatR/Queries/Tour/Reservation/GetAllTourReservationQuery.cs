﻿using MediatR;
using System.Collections.Generic;
using TourV2.Data.Dto;

namespace TourV2.MediatR.Queries
{
    public class GetAllTourReservationQuery : IRequest<List<TourReservationDto>>
    {
    }
}
