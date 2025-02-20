using DependencyInjection.Interfaces;

namespace DependencyInjection.Services
{
    public class NotificationService
    {
        private readonly INotificationSender _notificationSender;

        // Constructor Injection
        public NotificationService(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }

        public void SendNotification(string message)
        {
            _notificationSender.Send(message);
        }
    }
}
