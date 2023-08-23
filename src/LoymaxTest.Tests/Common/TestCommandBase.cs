using LoymaxTest.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LoymaxTest.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        #region Private

        private static readonly Mutex Mut = new();
        private static bool _isInitialization;
        private static DbContextOptions<BankDbContext> Options
            => new DbContextOptionsBuilder<BankDbContext>()
                .UseInMemoryDatabase("1476B620-FFF1-45EB-9E71-860DC76A5856")
                .Options;

        #endregion

        protected BankDbContext Context { get; init; }

        protected TestCommandBase()
        {
            Context = CreateContext();

            Mut.WaitOne();

            if (!_isInitialization)
            {
                BankContextFactory.Initialization(Context);
                _isInitialization = true;
            }

            Mut.ReleaseMutex();
        }

        protected BankDbContext CreateContext()
        {
            var context = BankContextFactory.Create(Options);
            return context;
        }

        public void Dispose()
        {
            BankContextFactory.Destroy(Context);
        }
    }
}
