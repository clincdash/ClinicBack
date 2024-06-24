using AutoMapper;
using clinicteo.Models.User.Dto;

namespace clinicteo.Models.User.Mapper;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserRequestDTO, User>();
        CreateMap<User, UserResponseDTO>();
        CreateMap<UserRequestDTO, UserResponseDTO>();
        CreateMap<UserRequestUpdateDTO, User>();
        CreateMap<UserRequestUpdatePasswordDTO, User>();
    }
}
