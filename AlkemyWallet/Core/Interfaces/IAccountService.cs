using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces
{
    public interface IAccountService
    {

        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccountById(int id);
        Task<(bool Success, string Message)> Deposit(int id, int amount);
        Task<(bool Success, string Message)> Transfer(int id, int amount, int toAccountId);
    }
}