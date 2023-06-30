using BennerMicrowave.Business.Services.Microwave;
using BennerMicrowave.Data.Domain;
using BennerMicrowave.Data.Seedwork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BennerMicrowave.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MicrowaveController : BaseController
    {
        private readonly IMicrowaveService _microwaveService;
        public MicrowaveController(IMicrowaveService microwaveService, INotification notification) : base(notification)
        {
            _microwaveService = microwaveService;
        }

        [HttpPost]
        public async Task<IActionResult> IsValidMicrowaveSettings(MicrowaveSettings settings) => Response(await _microwaveService.IsValidSetting(settings).ConfigureAwait(false));
        
    }
}
