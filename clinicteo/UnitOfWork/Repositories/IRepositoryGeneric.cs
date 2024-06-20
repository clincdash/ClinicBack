using clinicteo.Models.Base;

namespace clinicteo.UnitOfWork.Repositories;

public interface IRepositoryGeneric<T> where T : BaseEntity
{
    T FindById( int id );
    Task<T> FindByIdAsync( int id );
    void Delete(int id);
    T Save( T entity );
    Task<T> SaveAsync( T entity );
    List<T> GetAll();
    Task<List<T>> GetAllAsync();
    T Update( T entity );
}
