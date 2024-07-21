using Banker.Core.Models;
using Banker.Core.Abstractions;

namespace Banker.Application.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _banksRepository;

        public BankService(IBankRepository banksRepository)
        {
            _banksRepository = banksRepository;
        }

        public async Task<List<Bank>> GetAllBanks()
        {
            return await _banksRepository.Get();
        }

        public async Task<Guid> CreateBank(Bank bank)
        {
            return await _banksRepository.Create(bank);
        }

        public async Task<Guid> UpdateBank(Guid id, string name)
        {
            return await _banksRepository.Update(id, name);
        }

        public async Task<Guid> DeleteBank(Guid id)
        {
            return await _banksRepository.Delete(id);
        }
    }
}
