using Banker.Core.Models;
using Banker.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Banker.DataAccess.Configurations
{
    public class BankConfiguration : IEntityTypeConfiguration<BankEntity>
    {
        public void Configure(EntityTypeBuilder<BankEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(Bank.MAX_NAME_LENGTH).IsRequired();
        }
    }
}
