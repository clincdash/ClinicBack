using clinicteo.Models.Base;

namespace clinicteo.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    T FindById(int id);
    void Delete(int id);
    T Update(T entityUpdate);
    T Save(T entity);
    List<T> FindAll();
}
