using AutoMapper;
using MediatR;
using POC.Application.Contracts.Persistence;
using POC.Application.Responses;
using POC.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POC.Application.Features.Users.Queries.GetUserDetail
{
    class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, Response<UserDetailViewModel>>
    {
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandler(IAsyncRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<UserDetailViewModel>> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var userDetail = await _userRepository.GetByIdAsync(request.UserId);

            var userDetailViewModel = _mapper.Map<UserDetailViewModel>(userDetail);

            var result = new Response<UserDetailViewModel>()
            {
                Data = userDetailViewModel
            };

            return result;
        }
    }
}
