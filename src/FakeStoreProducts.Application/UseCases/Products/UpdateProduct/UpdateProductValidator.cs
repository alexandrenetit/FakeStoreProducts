using FakeStoreProducts.Application.DTOs.Requests;
using FluentValidation;

namespace FakeStoreProducts.Application.UseCases.Products.UpdateProduct;

/// <summary>
/// Validador para a requisição de atualização de produto
/// </summary>
public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidator()
    {
        RuleFor(p => p.ProductId)
            .GreaterThan(0).WithMessage("ID do produto deve ser maior que zero");

        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("O título é obrigatório")
            .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres");

        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("O preço deve ser maior que zero");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("A descrição é obrigatória")
            .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres");

        RuleFor(p => p.Category)
            .NotEmpty().WithMessage("A categoria é obrigatória")
            .MaximumLength(50).WithMessage("A categoria deve ter no máximo 50 caracteres");

        RuleFor(p => p.ImageUrl)
            .Must(uri => string.IsNullOrEmpty(uri) || Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("A URL da imagem deve ser válida");
    }
}