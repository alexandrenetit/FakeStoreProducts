using FakeStoreProducts.Domain.Entities;

namespace FakeStoreProducts.Domain.Specifications;

public static class ProductSpecification
{
    public static bool HasValidTitle(string title)
    {
        return !string.IsNullOrWhiteSpace(title) && title.Length <= 100;
    }

    public static bool HasValidPrice(decimal price)
    {
        return price >= 0 && price <= 10000;
    }

    public static bool HasValidDescription(string description)
    {
        return !string.IsNullOrWhiteSpace(description) && description.Length <= 1000;
    }

    public static bool HasValidCategory(string category)
    {
        return !string.IsNullOrWhiteSpace(category) && category.Length <= 50;
    }

    public static bool HasValidImage(string imageUrl)
    {
        return string.IsNullOrWhiteSpace(imageUrl) || Uri.TryCreate(imageUrl, UriKind.Absolute, out _);
    }

    public static bool IsValid(Product product)
    {
        return HasValidTitle(product.Title) &&
               HasValidPrice(product.Price) &&
               HasValidDescription(product.Description) &&
               HasValidCategory(product.Category) &&
               HasValidImage(product.Image);
    }
}