using AutoMapper;
using clinicteo.Models.User;
using clinicteo.Models.User.Dto;
using clinicteo.UnitOfWork;

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

    public async Task<UserResponseDTO> SaveUser( UserRequestDTO user )
    {
        try
        {
            var userExist = await repositoryUoW.UserRepository.GetUserByCRMAsync( user.CRM );
            if (userExist == null)
            {
                var userModel = mapper.Map<User>( user );
                userModel.CreateAt = dateNow;
                await repositoryUoW.UserRepository.SaveAsync( userModel );
                await repositoryUoW.CommitAssync();
                return mapper.Map<UserResponseDTO>( userModel );
            }
            else
            {
                throw new InvalidOperationException( "Entity exist!" );
            }
        }
        catch
        {
            repositoryUoW.Rollback();
            throw;
        }
        finally
        {
            repositoryUoW.Dispose();
        }
    }

    public async Task<List<UserResponseDTO>> GetAllUsers()
    {
        try
        {
            var users = await repositoryUoW.UserRepository.GetAllAsync();
            var userDtos = mapper.Map<List<UserResponseDTO>>( users );
            return userDtos;
        }
        catch
        {
            repositoryUoW.Rollback();
            throw;
        }
        finally 
        {
            repositoryUoW.Dispose();
        }
    }

    public async Task DeleteUser( int id )
    {
        try
        {
            repositoryUoW.UserRepository.Delete( id );
            await repositoryUoW.CommitAssync();
        }
        catch
        {
            repositoryUoW.Rollback();
            throw;
        }
        finally
        {
            repositoryUoW.Dispose();
        }
    }

    public async Task<UserResponseDTO> PutUser(int id, UserRequestUpdateDTO userDTO)
    {
        try
        {
            var user = await repositoryUoW.UserRepository.FindByIdAsync( id );
            user.CreateAt = dateNow;
            mapper.Map( userDTO, user );
            var userDto = repositoryUoW.UserRepository.Update( user );
            await repositoryUoW.CommitAssync();
            return mapper.Map<UserResponseDTO>( userDto );
        }
        catch
        { 
            repositoryUoW.Rollback( );
            throw;
        }
        finally { 
            repositoryUoW.Dispose(); 
        }
    }

    public async Task PutPassword(int id, UserRequestUpdatePasswordDTO newPassword )
    {
        try
        {
            var user = await repositoryUoW.UserRepository.FindByIdAsync( id );
            if ( user != null )
            {
                user.UpdateAt = dateNow;
                mapper.Map( newPassword, user );

                repositoryUoW.UserRepository.Update( user );
                await repositoryUoW.CommitAssync();
            }
            else
            {
                throw new InvalidOperationException( "Unable to update password" );
            }
        }
        catch 
        { 
            repositoryUoW.Rollback( ); 
            throw;
        }
        finally { 
            repositoryUoW.Dispose(); 
        }
    }
}