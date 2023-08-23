using LoymaxTest.Application.Interfaces;
using LoymaxTest.Domain.Models;
using LoymaxTest.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.Persistence
{
    public sealed class BankDbContext : DbContext, IBankDbContext
    {
        #region Constructor

        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

        #endregion

        #region Property

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }

        #endregion
    }
}
