using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Core.Services;

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
        return transactions.OrderBy(x => x.Date);
    }

    public async Task<(int totalPages, IEnumerable<Transaction> recordList)> GetTransactionsPaging(int userId, int pageNumber, int pageSize)
    {
        return await _unitOfWork.TransactionRepository!.GetByUserPaging(userId, pageNumber, pageSize);
    }

    public async Task<Transaction?> GetTransactionById(int id, int userId)
    {
        var tran = await _unitOfWork.TransactionRepository!.GetById(id);
        if (tran == null || tran.User_id != userId) return null;
        return tran;
    }

    public async Task<bool> DeleteTransaction(int id)
    {
        await _unitOfWork.TransactionRepository!.Delete(id);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }


    public async Task<bool> InsertTransaction(Transaction transaction)
    {
        if (await ValidateTransaction(transaction))
        {
            await _unitOfWork.TransactionRepository!.Insert(transaction);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        return false;
    }

    public async Task<bool> UpdateTransaction(int id, Transaction transaction)
    {
        if (transaction.Transaction_id != id) return false;
        if (!await ValidateTransaction(transaction)) return false;
        await _unitOfWork.TransactionRepository!.Update(transaction);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public async Task<bool> ValidateTransaction(Transaction transaction)
    {
        if (transaction.Amount <= 0) return false;

        var account = await _unitOfWork.AccountRepository.GetById(transaction.Account_id);
        if (account == null || account.User_id != transaction.User_id) return false;

        var user = await _unitOfWork.UserRepository.GetById(transaction.User_id);
        if (user == null) return false;

        return true;
    }
}