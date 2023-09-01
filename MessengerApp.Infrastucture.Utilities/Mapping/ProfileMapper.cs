namespace MessengerApp.Common.Utilities.Mapping
{
    using AutoMapper;

    using Data.Models;

    using ViewModels.Friends;

    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<ApplicationUser, FriendViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<ApplicationUser, SearchFriendViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}
