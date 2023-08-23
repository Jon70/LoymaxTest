using LoymaxTest.Application.Queries.Finance;

namespace LoymaxTest.Web.Controllers
{
    public class FinanceController : BaseController
    {
        /// <summary>
        /// Отправить деньги другому пользователю
        /// </summary>
        /// <param name="model">Входная модель</param>
        /// <returns>Статус перевода</returns>
        [HttpPost]
        public async Task<IActionResult> Transfer(TransferModel model)
        {
            await Mediator.Send(new TransferCommand
            {
                UserIdFrom = UserId,
                LoginTo = model.LoginTo,
                Amount = model.Amount
            });

            return Ok("Перевод прошёл успешно.");
        }

        /// <summary>
        /// Проверка баланса
        /// </summary>
        /// <returns>Баланс, руб.</returns>
        [HttpGet]
        public async Task<IActionResult> Balance()
        {
            var balance = await Mediator.Send(new BalanceCheckQuery
            {
                UserId = UserId
            });

            return Ok(balance);
        }
    }
}
