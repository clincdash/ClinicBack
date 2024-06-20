namespace clinicteo.UnitOfWork;

public interface IRepositoryUoW
{
    int Commit();
    Task<int> CommitAssync();
    void Rollback();
}