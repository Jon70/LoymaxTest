using LoymaxTest.DataAccess.Repository;

namespace LoymaxTest.Persistence
{
    public class DbInitializer
    {
        public static void Initializer(BankDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
