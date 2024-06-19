using clinicteo.Context;
using clinicteo.Models.User;


namespace clinicteo.UnitOfWork.Repositories.impl;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ClinicTeoContext context;

    public UserRepository( ClinicTeoContext context ) : base( context ) 
    { 
        this.context = context;
    }

    public User? GetUserByCRM( string crm )
    {
        return context.Users.FirstOrDefault( user => user.CRM.Equals( crm ) );
    }
}
