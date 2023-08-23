using LoymaxTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoymaxTest.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(p => p.Login).IsUnique();
            builder.Property(p => p.Login).HasMaxLength(15).IsRequired();
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Patronymic).HasMaxLength(50).IsRequired();
            builder.Property(p => p.SaltedHashedPassword).HasColumnName("Password").IsRequired();

            builder.HasOne(p => p.Account)
                .WithOne()
                .HasForeignKey<Account>(l => l.UserId);
        }
    }
}
