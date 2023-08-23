namespace LoymaxTest.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(BankDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
