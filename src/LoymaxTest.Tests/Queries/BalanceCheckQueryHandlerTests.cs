using LoymaxTest.Application.Queries.Finance;
using LoymaxTest.Tests.Common;
using Xunit;

namespace LoymaxTest.Tests.Queries
{
    public class BalanceCheckQueryHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task BalanceCheckQueryHandlerTests_GetBalance_BalanceIsReceived()
        {
            var handler = new BalanceCheckQueryHandler(Context);
            var userId = Guid.Parse("1476B620-FFF1-45EB-9E71-860DC76A5880");

            var balance = await handler.Handle
            (
                new BalanceCheckQuery
                {
                    UserId = userId
                }, default
            );

            Assert.IsType<decimal>(balance);
            Assert.Equal(1000, balance);
        }
    }
}
