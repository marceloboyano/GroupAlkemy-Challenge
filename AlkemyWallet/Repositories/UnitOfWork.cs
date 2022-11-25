using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlkemyWallet.Repositories;

public class UnitOfWork : IUnitOfWork
{
 
    private readonly WalletDbContext _context;
 
    public IUserRepository UserRepository { get; private set; } 
    public IFixedTermDepositRepository FixedTermDepositRepository { get; private set; }
    public ICatalogueRepository CatalogueRepository { get; private set; }
    public ITransactionRepository TransactionRepository { get; private set; }
    public IAccountRepository AccountRepository { get; private set; }
    public IRoleRepository RoleRepository { get; private set; }

    public UnitOfWork(WalletDbContext context)
    {
        _context = context;
        UserRepository = new UserRepository(_context);
        FixedTermDepositRepository = new FixedTermDepositRepository(_context);
        CatalogueRepository = new CatalogueRepository(_context);
        TransactionRepository = new TransactionRepository(_context);
        AccountRepository = new AccountRepository(_context);
        RoleRepository = new RoleRepository(_context);
    }

     public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}