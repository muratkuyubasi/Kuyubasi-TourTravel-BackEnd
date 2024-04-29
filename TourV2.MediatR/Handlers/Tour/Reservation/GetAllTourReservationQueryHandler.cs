using AutoMapper;
using TourV2.Data.Dto;
using TourV2.MediatR.Queries;
using TourV2.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace TourV2.MediatR.Handlers
{
    public class GetAllTourReservationQueryHandler : IRequestHandler<GetAllTourReservationQuery, List<TourReservationDto>>
    {
        private readonly ITourReservationRepository _tourReservationRepository;
        private readonly IMapper _mapper;

        public GetAllTourReservationQueryHandler(
            ITourReservationRepository tourReservationRepository,
            IMapper mapper)
        {
            _tourReservationRepository = tourReservationRepository;
            _mapper = mapper;

        }
        public async Task<List<TourReservationDto>> Handle(GetAllTourReservationQuery request, CancellationToken cancellationToken)
        {
            var entities = await _tourReservationRepository.AllIncluding(
                at=>at.ActiveTour.TourRecord, p => p.ActiveTour.PeriodRecord).Where(x=>!x.IsDeleted).ToListAsync();
            return _mapper.Map<List<TourReservationDto>>(entities);
        }
    }
}
