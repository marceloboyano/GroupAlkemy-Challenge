using AlkemyWallet.DataAccess;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq.Expressions;

namespace AlkemyWallet.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly WalletDbContext _context;   

    public RepositoryBase(WalletDbContext context)
    {
        _context = context;        
    }


    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<(int totalPages, IEnumerable<T> recordList)> GetAllPaging(int pageNumber, int pageSize)
    {
        var list = await _context.Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        var totalRecords = _context.Set<T>().Count();
        return ((int)Math.Ceiling(totalRecords / (double)pageSize), list);
    }

    public async Task<T?> GetById(int id) => await _context.Set<T>().FindAsync(id);
      
    

    public async Task Insert(T entity) => await _context.Set<T>().AddAsync(entity);
    

    public async Task Update(T entity) => await Task.FromResult(_context.Update(entity));
  

    public async Task Delete(int id)
    {
        var entity = await GetById(id);

        if (entity is not null) 
            _context.Set<T>().Remove(entity);
    }
}