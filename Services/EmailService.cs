using DependencyInjection.Interfaces;

namespace DependencyInjection.Services
{
    public class EmailService : INotificationSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }
}
