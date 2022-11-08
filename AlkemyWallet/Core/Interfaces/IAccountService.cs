using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Interfaces;

public interface IAccountService
{
    Task<IEnumerable<Account>> GetAccounts();
    Task<Account> GetAccountById(int id);
    Task InsertAccounts(AccountForCreationDTO accountDTO);
    Task<bool> UpdateAccount(int id, AccountForUpdateDTO accountDTO);
    Task<(bool Success, string Message)> Deposit(int id, int amount);
    Task<(bool Success, string Message)> Transfer(int id, int amount, int toAccountId);
    Task<(bool Success, string Message)> Block(int id);
}