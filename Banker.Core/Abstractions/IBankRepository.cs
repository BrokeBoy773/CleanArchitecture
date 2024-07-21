using Banker.Core.Models;

namespace Banker.Core.Abstractions
{
    public interface IBankRepository
    {
        Task<List<Bank>> Get();
        Task<Guid> Create(Bank bank);
        Task<Guid> Update(Guid id, string name);
        Task<Guid> Delete(Guid id);
    }
}
