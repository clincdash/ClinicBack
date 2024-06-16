

using AutoMapper;
using clinicteo.Models.User;
using clinicteo.Models.User.dto;
using clinicteo.Repositories;

namespace clinicteo.Services;

public class ClinicService
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;
    private readonly DateOnly dateNow;

    public ClinicService( IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository ?? throw new ArgumentNullException( nameof( userRepository ) );
        this.mapper = mapper ?? throw new ArgumentNullException( nameof( mapper ) );
        dateNow = DateOnly.FromDateTime(DateTime.Now);

    }

    public UserResponseDTO Save( UserRequestDTO user )
    {
        var userFound = userRepository.GetUserByCRM(user.CRM);
        if (userFound == null)
        {
            var userModel = mapper.Map<User>( user );
            userModel.CreateAt =  dateNow;
            userRepository.CreateUser( userModel );
            
            return mapper.Map<UserResponseDTO>(userModel);
        }
        else
        {
            throw new Exception("Entity exist!");
        }
    }

    public List<UserResponseDTO> GetAll()
    {
        var users = userRepository.GetAllUsers();
        var userDtos = mapper.Map<List<UserResponseDTO>>( users );

        return userDtos;
    }

    public void Delete( int id )
    {
        userRepository.DeleteUser( id );
    }

    public UserResponseDTO Put(int id, UserRequestUpdateDTO userDTO)
    {
        var user = userRepository.GetById(id);
        user.UpdateAt = dateNow;
        mapper.Map( userDTO, user );
        var userDto = userRepository.UpdateUser( user );
        return mapper.Map<UserResponseDTO>( userDto );
    }

    public void PutPassword(int id, UserRequestUpdatePasswordDTO newPassword )
    {
        var user = userRepository.GetById(id);
        mapper.Map( newPassword, user);

        userRepository.UpdateUser( user );
    }
    private DateTime GarantirUtc( DateTime dateTime )
    {
        if (dateTime.Equals(null))
        {
            dateTime = DateTime.Now;
        }
        if (dateTime.Kind == DateTimeKind.Utc)
        {
            return dateTime;
        }

        return dateTime.ToUniversalTime();
    }

}
