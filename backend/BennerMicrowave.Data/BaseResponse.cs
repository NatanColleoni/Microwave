namespace BennerMicrowave.Data
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;

        public object? Data { get; set; } = null;
    }
}
