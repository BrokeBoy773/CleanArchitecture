using Banker.Core.Models;
using Banker.Core.Abstractions;
using Banker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banker.DataAccess.Repositories
{
    public class BankRepository : IBankRepository
    {
        private readonly BankerDbContext _context;

        public BankRepository(BankerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bank>> Get()
        {
            List<BankEntity> bankEntities = await _context.Banks.AsNoTracking().ToListAsync();

            List<Bank> banks = bankEntities.Select(b => Bank.Create(b.Id, b.Name)).ToList();

            return banks;
        }

        public async Task<Guid> Create(Bank bank)
        {
            BankEntity bankEntity = new BankEntity
            {
                Id = bank.Id,
                Name = bank.Name,
            };

            await _context.Banks.AddAsync(bankEntity);
            await _context.SaveChangesAsync();

            return bankEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name)
        {
            await _context.Banks.Where(b => b.Id == id).ExecuteUpdateAsync(s => s.SetProperty(x => x.Name, x => name));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Banks.Where(b => b.Id == id).ExecuteDeleteAsync();

            return id;
        }
    }
}
