
namespace MassTransit.Shared
{
    public interface INotificationCreated
    {
        DateTime NotificationDate {get;}

        string NotificationMessage { get; set; }

        NotificationType Type { get; set; }
    }
}