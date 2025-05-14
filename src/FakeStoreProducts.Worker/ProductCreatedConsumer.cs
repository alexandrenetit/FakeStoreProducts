using FakeStoreProducts.Domain.Messages;
using MassTransit;

namespace FakeStoreProducts.Worker;

public class ProductCreatedConsumer : IConsumer<IProductCreatedEvent>
{
    private readonly ILogger<ProductCreatedConsumer> _logger;

    public ProductCreatedConsumer(ILogger<ProductCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<IProductCreatedEvent> context)
    {
        try
        {
            var product = context.Message;

            _logger.LogInformation("Produto criado consumido: {ProductId} - {Title} - {Price}",
                product.Id, product.Title, product.Price);

            // Aqui você pode implementar a lógica para processar o produto criado
            // Por exemplo, atualizar um cache, enviar um e-mail, etc.

            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao consumir evento de produto criado");
            throw;
        }
    }
}