using AutoMapper;
using POC.Application.Features.Garment.GetGarmentTypeList;
using POC.Application.Features.SMV.Command.GetSMVBreakDownVersion;
using POC.Application.Features.Styles.GetStyleList;
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
            CreateMap<POC.Domain.Entitities.User, UserViewModel>().ReverseMap();
            CreateMap<POC.Domain.Entitities.User, UserDetailViewModel>();
            CreateMap<POC.Domain.Entitities.User, CreateUserCommandResponse>();
            CreateMap<UpdateUserCommand, POC.Domain.Entitities.User>();


            // -------------------------- data table mapping ------------------------------------------------------

            CreateMap<IDataRecord, GarmentTypeListViewModel>()
                  .ForMember(des => des.GarmentTypeId, src => src.MapFrom(s => s["nIEGmtTypeID"]))
                  .ForMember(des => des.GarmentType, src => src.MapFrom(s => s["cGmtType"]));

            CreateMap<IDataRecord, StyleListViewModel>()
               .ForMember(des => des.StyleNumber, src => src.MapFrom(s => s["Style"]));

            CreateMap<IDataRecord, SMVBreakDownVersionViewModel>()
              .ForMember(des => des.BreakDownNumber, src => src.MapFrom(s => s["nBdNumber"]))
              .ForMember(des => des.XMLSketch, src => src.MapFrom(s => s["xmSketchPath"]))
              .ForMember(
                           des => des.ConfirmedOn,
                           src => src.MapFrom(s => !string.IsNullOrEmpty(s["dConfirmedOn"].ToString()) ? s["dConfirmedOn"].ToString() : null
                         ))
              .ForMember(des => des.IsNewOB, src => src.MapFrom(s => s["bNewOB"]))
              .ForPath(des => des.ConfirmedBy.UserName, src => src.MapFrom(s => s["cConfirmedBy"]))
              .ForPath(des => des.Account.AccountNo, src => src.MapFrom(s => s["cBdAccount"]))
            .ForPath(des => des.Style.StyleCode, src => src.MapFrom(s => s["nBdStyleCode"]))
            .ForPath(des => des.Style.StyleNumber, src => src.MapFrom(s => s["cBdStyle"]))
            .ForPath(des => des.Style.GarmentType.GarmentTypeID, src => src.MapFrom(s => s["nIEGmtTypeID"]))
            .ForPath(des => des.Style.GarmentType.MainGarmentType, src => src.MapFrom(s => s["cGmtType"]));


        }
    }
}
