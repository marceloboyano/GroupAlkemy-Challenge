using AlkemyWallet.Core.Interfaces;
using AlkemyWallet.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AlkemyWallet.Controllers
{
    [ApiController]
    [Route("[transaction]")]

    public class TransactionsController: ControllerBase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionsService transactionsService, IMapper mapper)
        {
            _transactionsService = transactionsService;
            _mapper = mapper;
        }

       
    }
}
