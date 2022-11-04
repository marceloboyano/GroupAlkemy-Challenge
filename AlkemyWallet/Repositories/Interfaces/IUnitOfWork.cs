using AlkemyWallet.Entities;
namespace AlkemyWallet.Repositories.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
       
            IRepositoryBase<User> UserRepository { get; }
            IRepositoryBase<Account> AccountRepository { get; }
            IRepositoryBase<Transaction> TransactionRepository { get; }
            IRepositoryBase<FixedTermDeposit> FixedTermDepositRepository { get; }
            IRepositoryBase<Role> RoleRepository { get; }
            IRepositoryBase<Catalogue> CatalogueRepository { get; }

            void SaveChanges();
            Task SaveChangesAsync();
        
    }
}
