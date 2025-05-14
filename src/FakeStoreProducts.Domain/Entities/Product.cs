using FakeStoreProducts.Domain.Exceptions;

namespace FakeStoreProducts.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public decimal Price { get; private set; }
    public string Description { get; private set; }
    public string Category { get; private set; }
    public string Image { get; private set; }

    // Construtor privado para ORM e desserialização
    private Product()
    { }

    // Construtor para criar novo produto
    public Product(string title, decimal price, string description, string category, string image)
    {
        ValidateProduct(title, price, description, category);

        Title = title;
        Price = price;
        Description = description;
        Category = category;
        Image = image;
    }

    // Construtor para produto existente
    public Product(int id, string title, decimal price, string description, string category, string image)
        : this(title, price, description, category, image)
    {
        if (id <= 0)
            throw new DomainException("Id do produto deve ser maior que zero.");

        Id = id;
    }

    // Métodos de atualização
    public void UpdateTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Título do produto não pode ser vazio.");

        Title = title;
    }

    public void UpdatePrice(decimal price)
    {
        if (price < 0)
            throw new DomainException("Preço do produto não pode ser negativo.");

        Price = price;
    }

    public void UpdateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Descrição do produto não pode ser vazia.");

        Description = description;
    }

    public void UpdateCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
            throw new DomainException("Categoria do produto não pode ser vazia.");

        Category = category;
    }

    public void UpdateImage(string image)
    {
        Image = image;
    }

    // Atualização completa do produto
    public void Update(string title, decimal price, string description, string category, string image)
    {
        ValidateProduct(title, price, description, category);

        Title = title;
        Price = price;
        Description = description;
        Category = category;
        Image = image;
    }

    // Validação do produto
    private void ValidateProduct(string title, decimal price, string description, string category)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("Título do produto não pode ser vazio.");

        if (price < 0)
            throw new DomainException("Preço do produto não pode ser negativo.");

        if (string.IsNullOrWhiteSpace(description))
            throw new DomainException("Descrição do produto não pode ser vazia.");

        if (string.IsNullOrWhiteSpace(category))
            throw new DomainException("Categoria do produto não pode ser vazia.");
    }
}