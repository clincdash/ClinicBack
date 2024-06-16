using AutoMapper;
using clinicteo.Models.User.dto;

namespace clinicteo.Models.User.mapper;

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
