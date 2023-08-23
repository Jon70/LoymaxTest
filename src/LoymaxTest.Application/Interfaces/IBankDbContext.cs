using LoymaxTest.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.Application.Interfaces
{
    public interface IBankDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
