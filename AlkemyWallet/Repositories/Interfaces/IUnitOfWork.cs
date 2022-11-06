using AlkemyWallet.Entities;
namespace AlkemyWallet.Repositories.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
       
            IRepositoryBase<User> UserRepository { get; }
            IUserRepository UserDetailsRepository { get; }
            IRepositoryBase<Account> AccountRepository { get; }
            ITransactionRepository TransactionRepository { get; }
            IRepositoryBase<FixedTermDeposit> FixedTermDepositRepository { get; }
            IRepositoryBase<Role> RoleRepository { get; }
            IRepositoryBase<Catalogue> CatalogueRepository { get; }

            void SaveChanges();
            Task SaveChangesAsync();
        
    }
}
