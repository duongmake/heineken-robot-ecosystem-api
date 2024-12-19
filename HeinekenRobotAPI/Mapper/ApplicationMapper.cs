using AutoMapper;
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


            CreateMap<UserVM, User>().ReverseMap().ForMember(dest => dest.RoleName,
                                       opt => opt.MapFrom(src => src.Role!.RoleName));
            CreateMap<UserCreateDTO, User>().ReverseMap();
            CreateMap<UserUpdateDTO, User>().ReverseMap();

            CreateMap<CampaignVM, Campaign>().ReverseMap().ForMember(dest => dest.RegionName,
                                       opt => opt.MapFrom(src => src.Region!.RegionName));
            CreateMap<CampaignCreateDTO, Campaign>().ReverseMap();
            CreateMap<CampaignUpdateDTO, Campaign>().ReverseMap();

            CreateMap<CampaignRobotMachineVM, CampaignRobotMachine>().ReverseMap().ForMember(dest => dest.CampaignName,
                                       opt => opt.MapFrom(src => src.Campaign!.CampaignName))
                                                                                  .ForMember(dest => dest.RobotName,
                                       opt => opt.MapFrom(src => src.Robot!.RobotName))
                                                                                  .ForMember(dest => dest.MachineCode,
                                       opt => opt.MapFrom(src => src.RecycleMachine!.MachineCode))
                                                                                  .ForMember(dest => dest.LocationName,
                                       opt => opt.MapFrom(src => src.Location!.LocationName));
            CreateMap<CampaignRobotMachineCreateDTO, CampaignRobotMachine>().ReverseMap();
            CreateMap<CampaignRobotMachineUpdateDTO, CampaignRobotMachine>().ReverseMap();

        }
    }
}
