using DependencyInjection.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationSender _notificationSender;

        public NotificationsController(INotificationSender notificationSender)
        {
            _notificationSender = notificationSender;
        }

        [HttpPost]
        public async Task<IActionResult> Send([FromBody] string message)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { error = "Message cannot be empty." });
                }

                await Task.Run(() => _notificationSender.Send(message));

                return StatusCode(StatusCodes.Status200OK , new { message = "Notification sent successfully!" });
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Error: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "An unexpected error occurred while sending the notification." });
            }
        }
    }
}
