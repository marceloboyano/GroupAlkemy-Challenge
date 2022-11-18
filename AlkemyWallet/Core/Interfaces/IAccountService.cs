using AlkemyWallet.Core.Models;
using AlkemyWallet.Entities;
using Microsoft.Identity.Client;

namespace AlkemyWallet.Core.Interfaces;

public interface IAccountService
{
    Task<IEnumerable<Account>> GetAccounts();
    Task<AccountForShowWithDetailsDTO> GetAccountById(int id);
    Task InsertAccounts(AccountForCreationDTO accountDTO);
    Task<bool> UpdateAccount(int id, AccountForUpdateDTO accountDTO);
    Task<(bool Success, string Message)> DeleteAccount(int id);
    Task<(bool Success, string Message)> Deposit(int userIdFromToken, int accountId, int amount);
    Task<(bool Success, string Message)> Transfer(int userId, int accountId, int amount, int toAccountId);
    Task<(bool Success, string Message)> Block(int id);
    Task<(bool Success, string Message)> Unblock(int id);
    Task<(int totalPages, IEnumerable<Account> recordList)> GetAccountsPaging(int pageNumber, int pageSize);
}