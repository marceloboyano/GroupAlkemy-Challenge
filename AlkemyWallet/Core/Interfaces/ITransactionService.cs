using AlkemyWallet.Core.Helper;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces;

public interface ITransactionService
{
    Task<bool> DeleteTransaction(int id);
    Task InsertTransaction(Transaction transaction);
    Task<bool> UpdateTransaction(int id, Transaction transaction);
    Task<IEnumerable<Transaction>> GetTransactions(int userId);
    Task<Transaction> GetTransactionById(int id, int userId);

}