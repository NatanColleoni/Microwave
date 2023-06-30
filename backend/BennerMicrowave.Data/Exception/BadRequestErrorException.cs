
namespace BennerMicrowave.Data.Exception
{
    [Serializable]
    public class BadRequestErrorException : System.Exception
    {
        public BadRequestErrorException() { }
        public BadRequestErrorException(string message) : base(message) { }
    }
}
