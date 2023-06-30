namespace BennerMicrowave.Business.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;

        public object? Data { get; set; } = null;
    }
}
