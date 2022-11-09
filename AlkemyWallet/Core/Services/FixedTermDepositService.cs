using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;

namespace AlkemyWallet.Core.Services
{
    public class FixedTermDepositService : IFixedTermDepositService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FixedTermDepositService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FixedTermDeposit>> GetFixedTermDepositsByUserId(int userId)
        {
            var fixedTermDepositsByUserId = await _unitOfWork.FixedTermDepositDetailsRepository!.GetByUser(userId);
            return fixedTermDepositsByUserId;
        }

        public async Task<IEnumerable<FixedTermDeposit>> GetFixedTermDeposits()
        {
            var fixedTermDeposits = await _unitOfWork.FixedTermDepositRepository!.GetAll();
            return fixedTermDeposits;
        }

    }
}
