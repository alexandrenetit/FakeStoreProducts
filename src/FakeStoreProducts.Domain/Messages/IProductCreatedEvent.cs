namespace FakeStoreProducts.Domain.Messages;

public interface IProductCreatedEvent
{
    int Id { get; }
    string Title { get; }
    decimal Price { get; }
    string Description { get; }
    string Category { get; }
    string Image { get; }
    DateTime CreatedAt { get; }
}