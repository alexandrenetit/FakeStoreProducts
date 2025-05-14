using FakeStoreProducts.Infrastructure.ApiClient;
using FakeStoreProducts.Infrastructure.ApiClient.Options;
using FakeStoreProducts.Infrastructure.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace FakeStoreProducts.Infrastructure.DependencyInjection;

/// <summary>
/// Extensões para configurar os serviços da camada de infraestrutura
/// </summary>
public static class InfrastructureServiceCollectionExtensions
{
    /// <summary>
    /// Adiciona os serviços da camada de infraestrutura ao container de injeção de dependência
    /// </summary>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configura as opções da FakeStore API
        services.Configure<FakeStoreApiOptions>(
            configuration.GetSection(FakeStoreApiOptions.SectionName));

        // Adiciona o serviço HttpClientService com políticas de resiliência
        services.AddHttpClient<HttpClientService>((serviceProvider, client) =>
        {
            var options = configuration
                .GetSection(FakeStoreApiOptions.SectionName)
                .Get<FakeStoreApiOptions>() ?? new FakeStoreApiOptions();

            client.BaseAddress = new Uri(options.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
        })
        .ConfigureResiliencyPolicies();

        // Registra o cliente da API
        services.AddScoped<IFakeStoreApiClient, FakeStoreApiClient>();

        // Configurar MassTransit com RabbitMQ para a API (apenas para publicação)
        services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((context, cfg) =>
            {
                // Configurar conexão com RabbitMQ
                cfg.Host(configuration["RabbitMQ:Host"] ?? "localhost", "/", h =>
                {
                    h.Username(configuration["RabbitMQ:Username"] ?? "guest");
                    h.Password(configuration["RabbitMQ:Password"] ?? "guest");
                });

                // Configurar retry policy
                cfg.UseMessageRetry(r =>
                {
                    r.Interval(3, TimeSpan.FromSeconds(5));
                });
            });
        });

        // Registrar o serviço de mensageria
        services.AddScoped<IMessageBusService, MassTransitMessageBusService>();

        return services;
    }

    /// <summary>
    /// Configura as políticas de resiliência para o HttpClient
    /// </summary>
    private static IHttpClientBuilder ConfigureResiliencyPolicies(this IHttpClientBuilder builder)
    {
        // Política de retry para erros transitórios HTTP
        builder.AddPolicyHandler(HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))));

        // Política de circuit breaker
        builder.AddPolicyHandler(HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        // Política de timeout
        builder.AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10)));

        return builder;
    }
}