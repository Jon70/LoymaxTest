using LoymaxTest.Application.Commands.Finance;
using LoymaxTest.Tests.Common;
using MediatR;
using Xunit;

namespace LoymaxTest.Tests.Commands
{
    public class TransferCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task TransferCommandHandlerTests_AssetTransfer_Success()
        {
            var handler = new TransferCommandHandler(Context);
            var loginTo = "user1";
            var userIdFrom = Guid.Parse("1476B620-FFF1-45EB-9E71-860DC76A5880");
            var amount = 500;

            var task = await handler.Handle
            (
                new TransferCommand
                {
                    LoginTo = loginTo,
                    UserIdFrom = userIdFrom,
                    Amount = amount
                }, default
            );

            Assert.IsType<Unit>(task);
        }
    }
}
