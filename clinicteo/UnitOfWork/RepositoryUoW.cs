﻿using clinicteo.Context;
using clinicteo.UnitOfWork.Repositories;
using clinicteo.UnitOfWork.Repositories.impl;

namespace clinicteo.UnitOfWork;

public class RepositoryUoW: IDisposable
{
    private ClinicTeoContext clinicTeoContext { get; set; }
 
    public RepositoryUoW( ClinicTeoContext clinicTeoContext )
    {
        this.clinicTeoContext = clinicTeoContext;
    }

    private IUserRepository? _userRepository = null;

    public IUserRepository UserRepository {  
        get 
        {
            _userRepository ??= new UserRepository(clinicTeoContext);
            return _userRepository; 
        } 
    }

    public void Dispose()
    {
        clinicTeoContext.Dispose();
    }
}
