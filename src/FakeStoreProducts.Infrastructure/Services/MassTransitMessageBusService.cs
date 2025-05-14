using FakeStoreProducts.Domain.Entities;
using FakeStoreProducts.Domain.Messages;
using FakeStoreProducts.Infrastructure.Messages;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FakeStoreProducts.Infrastructure.Services
{
    public class MassTransitMessageBusService : IMessageBusService
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<MassTransitMessageBusService> _logger;

        public MassTransitMessageBusService(
            IPublishEndpoint publishEndpoint,
            ILogger<MassTransitMessageBusService> logger)
        {
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task PublishProductCreatedEventAsync(Product product, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Publicando evento de produto criado para o produto {ProductId}", product.Id);

                var productEvent = new ProductCreatedEvent
                {
                    Id = product.Id,
                    Title = product.Title,
                    Price = product.Price,
                    Description = product.Description,
                    Category = product.Category,
                    Image = product.Image,
                    CreatedAt = DateTime.UtcNow
                };

                await _publishEndpoint.Publish<IProductCreatedEvent>(productEvent, cancellationToken);

                _logger.LogInformation("Evento de produto criado publicado com sucesso para o produto {ProductId}", product.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao publicar evento de produto criado para o produto {ProductId}", product.Id);
                throw;
            }
        }
    }
}