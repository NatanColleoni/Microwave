using BennerMicrowave.Business.Response;
using BennerMicrowave.Business.Validator;
using BennerMicrowave.Data.Domain;
using BennerMicrowave.Data.Seedwork.Interfaces;

namespace BennerMicrowave.Business.Services.Microwave
{
    public class MicrowaveService : BaseService, IMicrowaveService
    {
        public MicrowaveService(INotification notification) : base(notification)
        {

        }

        public async Task<BaseResponse> IsValidSetting(MicrowaveSettings settings) => await ExecuteAsync(async () =>
        {
            Validate(settings, new MicrowaveSettingsValidator());

            var resp = new BaseResponse()
            {
                Success = true,
                Data = new
                {
                    IsValidSetting = true
                }
            };

            return resp;
        });
    }
}
