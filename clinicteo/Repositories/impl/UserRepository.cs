using clinicteo.Context;
using clinicteo.Models.User;
using clinicteo.Models.User.dto;

namespace clinicteo.Repositories.impl;

public class UserRepository : IUserRepository
{
    private readonly IRepository<User> _repository;
    private readonly ClinicTeoContext _context;

    public UserRepository(ClinicTeoContext context, IRepository<User> repository)
    {
        _context = context ?? throw new ArgumentNullException( nameof(context) );
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public User CreateUser( User user )
    {
        return _repository.Save( user );
    }

    public void DeleteUser( int id )
    {
        _repository.Delete( id );
    }

    public List<User> GetAllUsers()
    {
        return _repository.FindAll();
    }

    public User GetById( int id )
    {
        return _repository.FindById( id );
    }

    public User? GetUserByCRM( string crm )
    {
        return _context.Users.FirstOrDefault( user => user.CRM.Equals( crm ) );        
    }

    public User UpdateUser( User user )
    {
        return _repository.Update( user );   
    }
}
