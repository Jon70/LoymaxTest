namespace LoymaxTest.Application.Common.Exceptions
{
    public class NotEnoughFundsException : Exception
    {
        public NotEnoughFundsException(string msg)
            : base(msg) { }
    }
}
