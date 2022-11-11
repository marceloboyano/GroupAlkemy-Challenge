using AlkemyWallet.Core.Helper;
using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities;
using AlkemyWallet.Entities.Paged;
using AlkemyWallet.Repositories.Interfaces;
using Microsoft.OpenApi.Writers;

namespace AlkemyWallet.Core.Services
{
    public class TransactionService : ITransactionService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;
 
         public TransactionService(IUnitOfWork unitOfWork, IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
        }
        public async Task<IEnumerable<Transaction>> GetTransactions(int userId)
        {
            var transactions = await _unitOfWork.TransactionRepository!.GetByUser(userId);
            return transactions.OrderBy(x=>x.Date);
        }

        public async Task<(int totalPages, IEnumerable<Transaction> recordList)> GetTransactionsPaging(int userId, int pageNumber, int pageSize)
        {
            return await _unitOfWork.TransactionRepository!.GetByUserPaging(userId,pageNumber, pageSize);
        }
        public async Task<Transaction?> GetTransactionById(int id, int userId)
        {
            var tran = await _unitOfWork.TransactionRepository!.GetById(id);
            if ((tran == null) || (tran.User_id != userId)) return null;
            return tran;
        }

        public async Task<bool> DeleteTransaction(int id)
        {
            await _unitOfWork.TransactionRepository!.Delete(id);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }


        public async Task<bool> InsertTransaction(Transaction transaction)
        {
            if (await ValidateTransaction(transaction)) {

                // checkear que cuando la cuenta sea un deposito o una transferencia actualice los balances de las 
                //cuentas involucradas

                //llamar a estos metodos de account service... las validaciones y la actualizacion del repositorio de transacciones
                // ya estan incluidas en esos metodos. yo no lo cambie por que no se que logica se aplica para determinar si es
                // desposito o transferencia

                // var result = await _accountService.Deposit(transaction.Account_Id, transaction.Amount);

                //var result = await _accountService.Transfer(transaction.Account_id, transaction.Amount, transaction.To_Account);


                //si se resuelve lo de arriba estan 2 lineas no harian falta porque account service actualiza
                await _unitOfWork.TransactionRepository!.Insert(transaction);
                return await _unitOfWork.SaveChangesAsync()>0;
            }
            return false;
        }

        public async Task<bool> UpdateTransaction(int id, Transaction transaction)
        {
            if (transaction.Transaction_id != id) return false;
            if (!(await ValidateTransaction(transaction)) ) return false;
            await _unitOfWork.TransactionRepository!.Update(transaction);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> ValidateTransaction(Transaction transaction)
        {
            if (transaction.Amount <= 0) return false;

            Account? account = await _unitOfWork.AccountRepository.GetById(transaction.Account_id);
            if((account == null) || (account.User_id!=transaction.User_id) ) return false;

            User? user = await _unitOfWork.UserRepository.GetById(transaction.User_id);
            if(user == null) return false;

            return true;
        }

        public PagedList<Transaction> GetPagedTransactions(PageResourceParameters pRp)
        {
            var x = _unitOfWork.TransactionRepository.FindAll().Result.OrderBy(x => x.Date);
            return PagedList<Transaction>.PagedIQueryObj(x, pRp.Page, pRp.PageSize);
        }
    }
}