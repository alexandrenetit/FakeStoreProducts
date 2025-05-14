using FakeStoreProducts.Domain.Entities;

namespace FakeStoreProducts.Infrastructure.Services;

public interface IMessageBusService
{
    Task PublishProductCreatedEventAsync(Product product, CancellationToken cancellationToken = default);
}