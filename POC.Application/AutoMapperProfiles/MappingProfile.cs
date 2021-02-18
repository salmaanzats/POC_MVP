using AutoMapper;
using POC.Application.Features.Users.Command.CreateUser;
using POC.Application.Features.Users.Queries.GetUserDetail;
using POC.Application.Features.Users.Queries.GetUserList;
using POC.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC.Application.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, UserDetailViewModel>();
            CreateMap<User, CreateUserCommandResponse>();
        }
    }
}
