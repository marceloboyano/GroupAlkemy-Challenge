using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;

namespace AlkemyWallet.Core.Services
{
    public class AccountService : IAccountService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;

        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var accounts = await _unitOfWork.AccountRepository.GetAll();
            return accounts;
        }

        public async Task<Account> GetAccountById(int id)
        {
            var account = await _unitOfWork.AccountRepository.GetById(id);
            return account;
        }

        public async Task<bool> Deposit(int id, int amount)
        {
            //el monto ingresado debe ser mayor a 0
            if (amount > 0)
            {

                var account = await _unitOfWork.AccountWithDetails.GetByIdWithDetail(id);

                if (account is null)
                    return false;

                //se suman los puntos al usuario un 2% en el deposito
                account.Money += amount;
                account.User!.Points += (amount * 2) / 100;

                var transaction = new Transaction()
                {
                    Amount = amount,
                    Concept = "Deposit",
                    Date = DateTime.Now,
                    Type = "Topup",
                    User_id = id,
                    Account_id = account.Id,
                };

                await _unitOfWork.TransactionRepository.Insert(transaction);


                return await _unitOfWork.AccountRepository.Update(account);

            }
            return false;

        }

    }
}