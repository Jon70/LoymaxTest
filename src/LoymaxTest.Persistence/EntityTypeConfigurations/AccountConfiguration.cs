using LoymaxTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoymaxTest.Persistence.EntityTypeConfigurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(l => l.Id);
            builder.HasIndex(l => l.Id).IsUnique();
            builder.Property(l => l.Id).IsRequired();
            builder.Property(l => l.Balance).HasPrecision(18, 10).IsRequired();
            builder.Property(l => l.ConcurrencyToken).IsConcurrencyToken().IsRequired();
        }
    }
}
