namespace BLL.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.UserEmail))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.UserPasswordHash))
                .ForMember(dest => dest.RegistrationTime, opt => opt.MapFrom(src => src.UserRegistrationTime))
                .ForMember(dest => dest.LastLoginTime, opt => opt.MapFrom(src => src.UserLastLoginTime))
                .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.RefreshToken))
                .ForMember(dest => dest.IsBlocked, opt => opt.MapFrom(src => src.UserIsBlocked));
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserPasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.UserRegistrationTime, opt => opt.MapFrom(src => src.RegistrationTime))
                .ForMember(dest => dest.UserLastLoginTime, opt => opt.MapFrom(src => src.LastLoginTime))
                .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.RefreshToken))
                .ForMember(dest => dest.UserIsBlocked, opt => opt.MapFrom(src => src.IsBlocked));
        }
    }
}
