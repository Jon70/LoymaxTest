using LoymaxTest.DataAccess.Interfaces;
using LoymaxTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LoymaxTest.DataAccess.Repository
{
    public sealed class BankDbContext : DbContext, IBankDbContext
    {
        #region Constructor

        public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

        #endregion

        #region Property

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserSecurity> UsersSecurity { get; set; }

        #endregion
    }
}
