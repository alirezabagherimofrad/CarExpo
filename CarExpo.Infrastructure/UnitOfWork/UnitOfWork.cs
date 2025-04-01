
using CarExpo.Domain.Interfaces;
using CarExpo.Domain.Models.Users;
using CarExpo.Infrastructure;
using CarExpo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpo.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _context;
    private readonly Dictionary<Type, object> _repositories = new();
    private IUserRepository? _userRepository;

    public UnitOfWork(DataBaseContext context)
    {
        _context = context;
    }

    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository == null)
            {
                _userRepository = new UserRepository(_context);
            }
            return _userRepository;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IGenericRepository<T> Repository<T>() where T : class
    {
        if (typeof(T) == typeof(User))
        {
            _userRepository ??= new UserRepository(_context);
            return (IGenericRepository<T>)_userRepository;
        }

        if (!_repositories.ContainsKey(typeof(T)))
        {
            var repository = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repository);
        }
        return (IGenericRepository<T>)_repositories[typeof(T)];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}


