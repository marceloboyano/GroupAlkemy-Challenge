using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces;

public interface ITransactionService
{
    Task<IEnumerable<Transaction>> GetTransactions(int userId);
    Task<Transaction> GetTransactionById(int id, int userId);
}