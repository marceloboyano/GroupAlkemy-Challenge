using AlkemyWallet.Core.Helper;
using AlkemyWallet.Entities;
using AlkemyWallet.Entities.Paged;

namespace AlkemyWallet.Core.Interfaces;

public interface ITransactionService
{
    Task<bool> DeleteTransaction(int id);
    Task<bool> InsertTransaction(Transaction transaction);
    Task<bool> UpdateTransaction(int id, Transaction transaction);
    Task<IEnumerable<Transaction>> GetTransactions(int userId);
    Task<Transaction?> GetTransactionById(int id, int userId);

    Task<bool> ValidateTransaction(Transaction transaction);
    PagedList<Transaction> GetPagedTransactions(PageResourceParameters pageResourceParameters);



}