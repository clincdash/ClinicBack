using clinicteo.Models.User;

namespace clinicteo.UnitOfWork.Repositories;

public interface IUserRepository : IRepositoryGeneric<User>
{
    User? GetUserByCRM( string crm );
    Task<User?> GetUserByCRMAsync( string crm );

}
