﻿using AutoMapper;
using HeinekenRobotAPI.DTO.Create;
using HeinekenRobotAPI.DTO.Update;
using HeinekenRobotAPI.DTO.ViewModels;
using HeinekenRobotAPI.Entities;

namespace HeinekenRobotAPI.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Robot, RobotVM>().ForMember(dest => dest.RobotTypeName,
                                       opt => opt.MapFrom(src => src.RobotType!.RobotTypeName))
                                       .ForMember(dest => dest.LocationName,
                                       opt => opt.MapFrom(src => src.Location!.LocationName))
                                       .ReverseMap();
            CreateMap<RobotCreateDTO, Robot>().ReverseMap();
            CreateMap<RobotUpdateDTO, Robot>().ReverseMap();


        }
    }
}
