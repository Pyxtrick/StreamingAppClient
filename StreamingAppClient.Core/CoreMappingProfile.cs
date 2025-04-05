using AutoMapper;
using StreamingApp.API.VTubeStudio.Props;
using StreamingAppClient.Core.VtubeStudio.Props;
using VTS.Core;

namespace StreamingApp.Core.Utility;
public class CoreMappingProfile : Profile
{
    public CoreMappingProfile()
    {
        CreateMap<VTSModelData, Model>().ReverseMap();

        CreateMap<HotkeyData, Toggle>().ReverseMap();

        CreateMap<ItemFile, Item>().ReverseMap();
        CreateMap<ItemInstance, Item>().ReverseMap();

        /**CreateMap<User, UserDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserText))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.TwitchDetail.Url))
            .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => src.Status.UserType))
            .ForMember(dest => dest.GiftedSubsCount, opt => opt.MapFrom(src => src.TwitchAchievements.GiftedSubsCount))
            .ForMember(dest => dest.GiftedBitsCount, opt => opt.MapFrom(src => src.TwitchAchievements.GiftedBitsCount))
            .ForMember(dest => dest.GiftedDonationCount, opt => opt.MapFrom(src => src.TwitchAchievements.GiftedDonationCount))
            .ForMember(dest => dest.WachedStreams, opt => opt.MapFrom(src => src.TwitchAchievements.WachedStreams))
            .ReverseMap();
        CreateMap<User, User>().ForAllMembers(opts => opts.Condition((src, dest, member) => member != null));**/
    }
}
