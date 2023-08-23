using LoymaxTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.DataAccess.Interfaces
{
    public interface IBankDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<UserSecurity> UsersSecurity { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        void Dispose();
    }
}
