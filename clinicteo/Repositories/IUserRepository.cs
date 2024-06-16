using clinicteo.Models.User;
using clinicteo.Models.User.dto;

namespace clinicteo.Repositories;

public interface IUserRepository
{
    User GetById(int id);
    List<User> GetAllUsers();
    User GetUserByCRM(string crm);
    void DeleteUser(int id);
    User CreateUser(User user);
    User UpdateUser(User user);
}
