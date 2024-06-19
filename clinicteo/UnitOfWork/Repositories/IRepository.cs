using clinicteo.Models.Base;

namespace clinicteo.UnitOfWork.Repositories;

public interface IRepositoryGeneric<T> where T : BaseEntity
{
    T FindById(int id);
    void Delete(int id);
    T Update(T entityUpdate);
    T Save(T entity);
    List<T> GetAll();
}
