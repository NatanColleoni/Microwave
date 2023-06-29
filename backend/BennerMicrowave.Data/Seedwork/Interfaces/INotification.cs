using BennerMicrowave.Data.Seedwork.Enums;
using BennerMicrowave.Data.Seedwork.Models;

namespace BennerMicrowave.Data.Seedwork.Interfaces
{
    public interface INotification
    {
        Notification NotificationModel { get; }
        bool HasNotification { get; }
        void AddNotification(string key, string message, ENotificationType notificationType);
    }
}
