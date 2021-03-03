using AutoMapper;
using POC.Application.Features.Garment.GetGarmentTypeList;
using POC.Application.Features.Users.Command.CreateUser;
using POC.Application.Features.Users.Command.UpdateUser;
using POC.Application.Features.Users.Queries.GetUserDetail;
using POC.Application.Features.Users.Queries.GetUserList;
using POC.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Data;
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
            CreateMap<UpdateUserCommand, User>();


            // data table mapping
            CreateMap<IDataRecord, GarmentTypeListViewModel>()
                .ForMember(des => des.GarmentTypeId, src => src.MapFrom(s => s["nIEGmtTypeID"]))
                .ForMember(des => des.GarmentType, src => src.MapFrom(s => s["cGmtType"]));
        }
    }
}
