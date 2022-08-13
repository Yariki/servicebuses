using MassTransit;
using MassTransit.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitProduce.Controllers;

[ApiController]
[Route("[controller]")]
public class ProduceController : ControllerBase
{
    private readonly IPublishEndpoint publishEndpoint;
    private readonly ILogger<ProduceController> _logger;

    public ProduceController(IPublishEndpoint publishEndpoint,  
        ILogger<ProduceController> logger)
    {
        this.publishEndpoint = publishEndpoint;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Notify(NotificationDto notification)
    {
        await publishEndpoint.Publish<INotificationCreated>( new 
        {
            NotificationDate = notification.NotificationDate,
            NotificationMessage = notification.NotificationMessage,
            NotificationType = notification.Type       
        });

        return Ok();       
    }
}
