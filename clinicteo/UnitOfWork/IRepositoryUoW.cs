namespace clinicteo.UnitOfWork;

public interface IRepositoryUoW
{
    void Commit();
    Task CommitAssync();
    void Rollback();
    void BeginTransaction();
    Task RollbackAsync();
}