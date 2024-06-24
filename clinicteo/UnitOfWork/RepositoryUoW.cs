using clinicteo.Context;
using clinicteo.UnitOfWork.Repositories;
using clinicteo.UnitOfWork.Repositories.impl;
using Microsoft.EntityFrameworkCore.Storage;

namespace clinicteo.UnitOfWork;

public class RepositoryUoW: IDisposable, IRepositoryUoW
{
    private ClinicTeoContext _clinicTeoContext { get; set; }
 
    public RepositoryUoW( ClinicTeoContext clinicTeoContext)
    {
        _clinicTeoContext = clinicTeoContext;
    }

    private IDbContextTransaction? _transaction = null;
    private IUserRepository? _userRepository = null;

    public IUserRepository UserRepository {  
        get 
        {
            _userRepository ??= new UserRepository(_clinicTeoContext);
            return _userRepository; 
        } 
    }

    public void Dispose()
    {
        _transaction?.Dispose();
    }

    public async Task DisposeAsync()
    {
        if (_transaction != null)
        {
            await _transaction.DisposeAsync();
        }
    }

    public void Commit()
    {
        _clinicTeoContext.SaveChanges();
        _transaction?.Commit();
    }

    public async Task CommitAssync()
    {
        await _clinicTeoContext.SaveChangesAsync();
        if ( _transaction != null)
        {
            await _transaction.CommitAsync();
        }
    }

    public void Rollback()
    {
        _transaction?.Rollback();
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
        }
    }

    public void BeginTransaction()
    {
        _transaction = _clinicTeoContext.Database.BeginTransaction();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _clinicTeoContext.Database.BeginTransactionAsync();
    }
}