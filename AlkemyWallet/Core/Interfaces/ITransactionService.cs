using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces;

public interface ITransactionService
{
    Task<bool> DeleteTransaction(int id);
    Task<bool> InsertTransaction(Transaction transaction);
    Task<bool> UpdateTransaction(int id, Transaction transaction);
    Task<IEnumerable<Transaction>> GetTransactions(int userId);
    Task<(int totalPages, IEnumerable<Transaction> recordList)> GetTransactionsPaging(int userId, int pageNumber, int pageSize);
    Task<Transaction?> GetTransactionById(int id, int userId);
    Task<bool> ValidateTransaction(Transaction transaction);
}