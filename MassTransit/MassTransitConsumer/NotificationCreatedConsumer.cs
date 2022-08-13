using MassTransit;
using MassTransit.Shared;
using System.Text.Json;

namespace MassTransitConsumer
{
    public class NotificationCreatedConsumer : IConsumer<INotificationCreated>
    {
        public Task Consume(ConsumeContext<INotificationCreated> context)
        {
            var notifation = JsonSerializer.Serialize(context.Message);

            Console.WriteLine($"Message: {notifation}");

            return Task.CompletedTask;
        }
    }
}