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

            CreateMap<Friend,FriendViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Friends.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Friends.UserName))
                .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.Friends.ImageUrl));

            CreateMap<ApplicationUser, SearchFriendViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ImageUrl));

            CreateMap<FriendRequest, FriendRequestsViewModel>()
                .ForMember(dest => dest.SentById, opt => opt.MapFrom(src => src.SenderId))
                .ForMember(dest => dest.SentByUsername, opt => opt.MapFrom(src => src.Sender.UserName))
                .ForMember(dest => dest.SentByProfilePictureUrl, opt => opt.MapFrom(src => src.Sender.ImageUrl))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
