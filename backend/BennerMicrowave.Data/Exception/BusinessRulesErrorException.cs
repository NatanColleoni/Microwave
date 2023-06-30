namespace BennerMicrowave.Data.Exception
{
    public class BusinessRulesErrorException : System.Exception
    {
        public BusinessRulesErrorException() { }
        public BusinessRulesErrorException(string message) : base(message) { }
    }
}
