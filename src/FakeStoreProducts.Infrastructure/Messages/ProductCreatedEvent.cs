using FakeStoreProducts.Domain.Messages;

namespace FakeStoreProducts.Infrastructure.Messages;

public class ProductCreatedEvent : IProductCreatedEvent
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}