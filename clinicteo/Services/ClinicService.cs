using AutoMapper;
using clinicteo.Models.User;
using clinicteo.Models.User.Dto;
using clinicteo.UnitOfWork;
using clinicteo.UnitOfWork.Repositories.impl;

namespace clinicteo.Services;

public class ClinicService
{
    private readonly RepositoryUoW repositoryUoW;
    private readonly IMapper mapper;
    private readonly DateOnly dateNow;

    public ClinicService( RepositoryUoW repositoryUoW, IMapper mapper)
    {
        this.repositoryUoW = repositoryUoW ?? throw new ArgumentNullException( nameof( repositoryUoW ) );
        this.mapper = mapper ?? throw new ArgumentNullException( nameof( mapper ) );
        dateNow = DateOnly.FromDateTime(DateTime.Now);

    }

    public UserResponseDTO SaveUser( UserRequestDTO user )
    {
        var userExist = repositoryUoW.UserRepository.GetUserByCRM(user.CRM);
        if (userExist == null)
        {
            var userModel = mapper.Map<User>( user );
            userModel.CreateAt =  dateNow;
            repositoryUoW.UserRepository.Save( userModel );
            
            return mapper.Map<UserResponseDTO>(userModel);
        }
        else
        {
            throw new Exception("Entity exist!");
        }
    }

    public List<UserResponseDTO> GetAllUsers()
    {
        var users = repositoryUoW.UserRepository.GetAll();
        var userDtos = mapper.Map<List<UserResponseDTO>>( users );

        return userDtos;
    }

    public void DeleteUser( int id )
    {
        repositoryUoW.UserRepository.Delete( id );
    }

    public UserResponseDTO PutUser(int id, UserRequestUpdateDTO userDTO)
    {
        var user = repositoryUoW.UserRepository.FindById( id);
        user.UpdateAt = dateNow;
        mapper.Map( userDTO, user );
        var userDto = repositoryUoW.UserRepository.Update( user );
        return mapper.Map<UserResponseDTO>( userDto );
    }

    public void PutPassword(int id, UserRequestUpdatePasswordDTO newPassword )
    {
        var user = repositoryUoW.UserRepository.FindById( id);
        user.UpdateAt = dateNow;
        mapper.Map( newPassword, user);

        repositoryUoW.UserRepository.Update( user );
    }
}