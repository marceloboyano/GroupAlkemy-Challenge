using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Entities;
using AlkemyWallet.Repositories.Interfaces;
using AutoMapper;

namespace AlkemyWallet.Core.Services
{
    public class FixedTermDepositService : IFixedTermDepositService
    {

        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public FixedTermDepositService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<IEnumerable<FixedTermDeposit>> GetFixedTermDeposits()
        {
            var fixedTermDeposits = _unitOfWork.FixedTermDepositRepository.GetAll();
            return fixedTermDeposits;
        }

        public Task<FixedTermDeposit> GetFixedTermDepositsById(int id)
        {
            var fixedTermDepositsById = _unitOfWork.FixedTermDepositRepository.GetById(id);
            return fixedTermDepositsById;
        }

        public async Task<bool> DeleteFixedTermDeposit(int id)
        {
            await _unitOfWork.FixedTermDepositRepository.Delete(id);
            return true;
        }

    }
}
