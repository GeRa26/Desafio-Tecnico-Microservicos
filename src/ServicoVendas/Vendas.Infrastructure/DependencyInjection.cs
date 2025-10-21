using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vendas.Domain.Repositories;
using Vendas.Infrastructure.Messaging;
using Vendas.Infrastructure.Persistence;
using Vendas.Infrastructure.Repositories;

namespace Vendas.Infrastructure
{
    public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Banco de dados
        services.AddDbContext<VendasDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Repositórios
        services.AddScoped<IPedidoRepository, PedidoRepository>();

        // RabbitMQ / MassTransit
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMQ:Host"] ?? "rabbitmq://localhost");
            });
        });

        services.AddScoped<IEventPublisher, RabbitMqPublisher>();

        return services;
    }
}
}