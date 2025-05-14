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
        _logger.LogInformation("Worker iniciado �s: {time}", DateTimeOffset.Now);

        // O worker n�o precisa executar nada em loop, pois o MassTransit j� gerencia os consumidores
        // Este m�todo s� � necess�rio para manter o worker rodando
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
        }
    }

    public override Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Servi�o iniciado �s: {time}", DateTimeOffset.Now);
        return base.StartAsync(cancellationToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Servi�o encerrado �s: {time}", DateTimeOffset.Now);
        return base.StopAsync(cancellationToken);
    }
}