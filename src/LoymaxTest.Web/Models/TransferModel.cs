namespace LoymaxTest.Web.Models
{
    /// <summary>
    /// Модель для перевода активов
    /// </summary>
    /// <param name="LoginTo">Получатель</param>
    /// <param name="Amount">Сумма, руб</param>
    public record TransferModel(string LoginTo, decimal Amount);
}
