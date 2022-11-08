using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Core.Services
{
    public class TransactionService : ITransactionService
    {
        
        private readonly IUnitOfWork _unitOfWork;
 
         public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
         }
        public async Task<IEnumerable<Transaction>> GetTransactions(int userId)
        {
            var transactions = await _unitOfWork.TransactionRepository!.GetByUser(userId);
            return transactions.OrderBy(x=>x.Date);
        }

        public async Task<Transaction> GetTransactionById(int id, int userId)
        {
            var tran = await _unitOfWork.TransactionRepository!.GetById(id);
            if ((tran == null) || (tran.User_id != userId)) return null;
            return tran;
        }

        public async Task<bool> DeleteTransaction(int id)
        {
            return await _unitOfWork.TransactionRepository!.Delete(id);

        }

        public async Task InsertTransaction(Transaction transaction)
        {
            if (await ValidateTransaction(transaction)) await _unitOfWork.TransactionRepository!.Insert(transaction);
        }

        public async Task<bool> UpdateTransaction(int id, Transaction transaction)
        {
            if (transaction.Transaction_id != id) return false;
            if (await ValidateTransaction(transaction)) return await _unitOfWork.TransactionRepository!.Update(transaction);
            else return false;
        }
     }
}