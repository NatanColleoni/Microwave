using BennerMicrowave.Business.Services.Microwave;
using BennerMicrowave.Data.Seedwork.Implementation;
using BennerMicrowave.Data.Seedwork.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BennerMicrowave.Infra
{
    public static class NativeInjector
    {
        public static void AddLocalServices(this IServiceCollection services)
        {
            services.AddScoped<INotification, Notification>();
            services.AddScoped<IMicrowaveService, MicrowaveService>(); 
        }
    }
}
