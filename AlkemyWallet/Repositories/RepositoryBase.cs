using AlkemyWallet.DataAccess;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly WalletDbContext _context;
    private readonly DbSet<T> _entities;

    public RepositoryBase(WalletDbContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    /// Esta clase implementa un CRUD básico para cualquier entidad de Entity Framework
    public async Task<IQueryable<T>> FindAll()
    {
        return await Task.FromResult(_entities.AsNoTracking());
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Task.FromResult(_entities.AsEnumerable());
    }

    public async Task<(int totalPages, IEnumerable<T> recordList)> GetAllPaging(int pageNumber, int pageSize)
    {
        var list = await Task.FromResult(_entities
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsEnumerable());
        var totalRecords = _entities.Count();
        return ((int)Math.Ceiling(totalRecords / (double)pageSize), list);
    }

    public async Task<T?> GetById(int id)
    {
        var result = await _entities.FindAsync(id);
        return result;
    }

    public async Task Insert(T entity)
    {
        _entities.Add(entity);
    }

    public async Task Update(T entity)
    {
        _context.Update(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);

        if (entity != null) _entities.Remove(entity);
    }
}