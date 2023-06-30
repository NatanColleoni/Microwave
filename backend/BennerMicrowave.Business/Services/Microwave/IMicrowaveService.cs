using BennerMicrowave.Business.Response;
using BennerMicrowave.Data.Domain;

namespace BennerMicrowave.Business.Services.Microwave
{
    public interface IMicrowaveService
    {
        Task<BaseResponse> IsValidSetting(MicrowaveSettings settings);
    }
}
