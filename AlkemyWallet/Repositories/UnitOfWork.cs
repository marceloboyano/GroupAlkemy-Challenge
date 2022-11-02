using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {


        /// <summary>
        /// Basicamente unit of work tiene la funcion de crear funciones sincronicas, por ejemplo : al transferir dinero de una cuenta
        /// bancaria a otra, las dos cuentas bancarias sufren un cambio en sus depositos de forma simultanea, unit of work se encarga de enlazar
        /// las dos tablas o mas para asi utilizar una sola instancia de DBcontext.
        /// https://www.youtube.com/watch?v=GdRBFc_KKKM este video de la tutoria les permitira tener un ejemplo de en que momento usar
        /// la sincronizacion.(tambien para ver como initiliazar el context en con el unit of work en los endpoints).
        /// </summary>


        private UserRepository _userRepository;
        private RoleRepository _roleRepository;
        private AccountRepository _accountRepository;
        private TransactionRepository _transactionRepository;
        private FixedTermDepositRepository _fixedTermDepositRepository;
        private CatalogueRepository _catalogueRepository;
        private WalletDbContext _dbContext;
        public UnitOfWork(WalletDbContext context)
        {
            _dbContext = context;

         }

        public void Save()
        {
            _dbContext.SaveChanges();
        }


    }
}
