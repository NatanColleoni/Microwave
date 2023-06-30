using BennerMicrowave.Data.Seedwork.Enums;
using BennerMicrowave.Data.Seedwork.Interfaces;
using BennerMicrowave.Data.Seedwork.Models;

namespace BennerMicrowave.Data.Seedwork.Implementation
{
    public class Notification : INotification
    {
        public List<NotificationModel> _notification = new List<NotificationModel>();
        public bool HasNotification => _notification.Any();
        public List<NotificationModel> ListNotificationModel => _notification;

        public void AddNotification(string key, string message, ENotificationType notificationType)
        {
            _notification.Add(new NotificationModel(key, message, notificationType));
        }
    }
}
