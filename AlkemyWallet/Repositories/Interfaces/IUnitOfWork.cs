using AlkemyWallet.Entities;

namespace AlkemyWallet.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
 
    int SaveChanges();
    Task<int> SaveChangesAsync();

    IUserRepository UserRepository { get; }
    IFixedTermDepositRepository FixedTermDepositRepository { get; }
    ICatalogueRepository CatalogueRepository { get; }
    ITransactionRepository TransactionRepository { get; }
    IAccountRepository AccountRepository { get; }
    IRoleRepository RoleRepository { get; }
}