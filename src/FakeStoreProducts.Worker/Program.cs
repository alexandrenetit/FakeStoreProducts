using FakeStoreProducts.Infrastructure.Services;
using FakeStoreProducts.Worker;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;

        // Configurar MassTransit com RabbitMQ
        services.AddMassTransit(config =>
        {
            // Configurar os consumidores
            config.AddConsumer<ProductCreatedConsumer>();

            config.UsingRabbitMq((context, cfg) =>
            {
                // Configurar conexão com RabbitMQ
                cfg.Host(configuration["RabbitMQ:Host"] ?? "localhost", "/", h =>
                {
                    h.Username(configuration["RabbitMQ:Username"] ?? "guest");
                    h.Password(configuration["RabbitMQ:Password"] ?? "guest");
                });

                // Configurar endpoints
                cfg.ConfigureEndpoints(context);

                // Configurar retry policy
                cfg.UseMessageRetry(r =>
                {
                    r.Interval(3, TimeSpan.FromSeconds(5));
                });
            });
        });

        // Adicionar o serviço worker
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();