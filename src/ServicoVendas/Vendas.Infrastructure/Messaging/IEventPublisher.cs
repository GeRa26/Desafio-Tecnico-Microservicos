using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;

namespace Vendas.Infrastructure.Messaging
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T @event) where T : class;
    }
}