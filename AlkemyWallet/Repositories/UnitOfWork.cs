using AlkemyWallet.DataAccess;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Repositories;

public class UnitOfWork : IUnitOfWork
{
    
    private readonly WalletDbContext _dbContext;
    private readonly IRepositoryBase<Account>? _accountRepository;
    private readonly IAccountRepository? _accountWithDetails;
    private readonly IRepositoryBase<Catalogue>? _catalogueRepository;
    private readonly ICatalogueRepository? _catalogueByPoints;
    private readonly IRepositoryBase<FixedTermDeposit>? _fixedTermDepositRepository;
    private readonly IFixedTermDepositRepository? _fixedTermDepositDetailsRepository;
    private readonly IRepositoryBase<Role>? _roleRepository;
    private readonly ITransactionRepository? _transactionRepository;
    private readonly IUserRepository? _userDetailsRepository;
    private readonly IRepositoryBase<User>? _userRepository;
    

    public UnitOfWork(WalletDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IRepositoryBase<FixedTermDeposit> FixedTermDepositRepository => _fixedTermDepositRepository ?? new FixedTermDepositRepository(_dbContext);
    public IFixedTermDepositRepository FixedTermDepositDetailsRepository => _fixedTermDepositDetailsRepository ?? new FixedTermDepositRepository(_dbContext);
    public IRepositoryBase<User> UserRepository => _userRepository ?? new RepositoryBase<User>(_dbContext);

    public IUserRepository UserDetailsRepository => _userDetailsRepository ?? new UserRepository(_dbContext);
    
    public IRepositoryBase<Account> AccountRepository => _accountRepository ?? new RepositoryBase<Account>(_dbContext);

    public IAccountRepository AccountWithDetails => _accountWithDetails ?? new AccountRepository(_dbContext);

    public ITransactionRepository TransactionRepository =>
        _transactionRepository ?? new TransactionRepository(_dbContext);
    public IRepositoryBase<Role> RoleRepository => _roleRepository ?? new RepositoryBase<Role>(_dbContext);

    public IRepositoryBase<Catalogue> CatalogueRepository =>
        _catalogueRepository ?? new RepositoryBase<Catalogue>(_dbContext);

    public ICatalogueRepository CatalogueByPoints => _catalogueByPoints ?? new CatalogueRepository(_dbContext);
    public void Dispose()
    {
        if (_dbContext != null) _dbContext.Dispose();
    }

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}