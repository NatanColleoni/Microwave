using BennerMicrowave.Data.Seedwork.Enums;
using BennerMicrowave.Data.Seedwork.Interfaces;

namespace BennerMicrowave.Data.Seedwork.Implementation
{
    public class Notification : INotification
    {
        private Models.Notification _notification;
        public bool HasNotification => _notification != null;
        public Models.Notification NotificationModel => _notification;

        public void AddNotification(string key, string message, ENotificationType notificationType)
        {
            _notification = new Models.Notification(key, message, notificationType);
        }
    }
}
