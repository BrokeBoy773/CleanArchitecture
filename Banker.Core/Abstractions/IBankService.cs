using Banker.Core.Models;

namespace Banker.Core.Abstractions
{
    public interface IBankService
    {
        Task<List<Bank>> GetAllBanks();
        Task<Guid> CreateBank(Bank bank);
        Task<Guid> UpdateBank(Guid id, string name);
        Task<Guid> DeleteBank(Guid id);
    }
}
