using clinicteo.Context;
using clinicteo.Models.User;
using Microsoft.EntityFrameworkCore;


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
    public async Task<User?> GetUserByCRMAsync( string crm )
    {
        return await context.Users.FirstOrDefaultAsync( user => user.CRM.Equals( crm ) );
    }
}
