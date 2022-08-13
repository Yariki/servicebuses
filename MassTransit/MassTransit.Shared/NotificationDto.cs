namespace MassTransit.Shared;
public class NotificationDto
{
    public DateTime NotificationDate {get;}

    public string NotificationMessage { get; set; }

    public NotificationType Type { get; set; }
}
