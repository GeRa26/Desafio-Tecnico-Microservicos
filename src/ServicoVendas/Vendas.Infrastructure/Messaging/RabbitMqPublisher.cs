using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;

namespace Vendas.Infrastructure.Messaging
{
    public class RabbitMqPublisher : IEventPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;

    public RabbitMqPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync<T>(T @event) where T : class
    {
        await _publishEndpoint.Publish(@event);
    }
}
}