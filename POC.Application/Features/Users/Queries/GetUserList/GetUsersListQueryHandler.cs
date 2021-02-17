using AutoMapper;
using MediatR;
using POC.Application.Contracts.Persistence;
using POC.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POC.Application.Features.Users.Queries.GetUserList
{
    class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UserViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<User> _eventRepository;

        public GetUsersListQueryHandler(IMapper mapper, IAsyncRepository<User> eventRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
        }


        public async Task<List<UserViewModel>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var queryResult = await _eventRepository.ListAllAsync();

            var vmList = _mapper.Map<List<UserViewModel>>(queryResult);

            return vmList;
        }
    }
}
