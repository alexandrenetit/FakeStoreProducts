namespace FakeStoreProducts.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker iniciado às: {time}", DateTimeOffset.Now);

        // O worker não precisa executar nada em loop, pois o MassTransit já gerencia os consumidores
        // Este método só é necessário para manter o worker rodando
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
        }
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Serviço iniciado às: {time}", DateTimeOffset.Now);
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Serviço encerrado às: {time}", DateTimeOffset.Now);
        return base.StopAsync(cancellationToken);
    }
}