using BennerMicrowave.Data.Seedwork.Enums;

namespace BennerMicrowave.Data.Seedwork.Models
{
    public class Notification
    {
        public Guid NotificationId { get; private set; }
        public string Key { get; private set; }
        public string Message { get; private set; }
        public ENotificationType NotificationType { get; set; }

        public Notification(string key, string message)
        {
            NotificationId = Guid.NewGuid();
            Key = key;
            Message = message;
        }

        public Notification(string key, string message, ENotificationType notificationType)
        {
            NotificationId = Guid.NewGuid();
            Key = key;
            Message = message;
            NotificationType = notificationType;
        }
    }
}
