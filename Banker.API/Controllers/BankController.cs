using Banker.API.Contracts;
using Banker.Core.Models;
using Banker.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Banker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        private readonly IBankService _banksService;

        public BankController(IBankService banksService)
        {
            _banksService = banksService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BanksResponse>>> GetBanks()
        {
            List<Bank> banks = await _banksService.GetAllBanks();

            List<BanksResponse> response = banks.Select(x => new BanksResponse(x.Id, x.Name)).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBank([FromBody] BanksRequest request)
        {
            Bank bank = Bank.Create(Guid.NewGuid(), request.Name);

            Guid bankId = await _banksService.CreateBank(bank);

            return Ok(bankId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBank(Guid id, [FromBody] BanksRequest request)
        {
            Guid bankId = await _banksService.UpdateBank(id, request.Name);

            return Ok(bankId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBank(Guid id)
        {
            Guid bankId = await _banksService.DeleteBank(id);

            return Ok(bankId);
        }
    }
}
