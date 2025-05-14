using FakeStoreProducts.Application.Interfaces;
using FluentValidation;

namespace FakeStoreProducts.Application.Common.Behaviors
{
    /// <summary>
    /// Comportamento de validação que usa FluentValidation para validar requisições
    /// </summary>
    /// <typeparam name="TRequest">Tipo da requisição</typeparam>
    /// <typeparam name="TResponse">Tipo da resposta</typeparam>
    public class ValidationBehavior<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IValidator<TRequest>? _validator;
        private readonly IRequestHandler<TRequest, TResponse> _next;

        public ValidationBehavior(
            IValidator<TRequest>? validator,
            IRequestHandler<TRequest, TResponse> next)
        {
            _validator = validator;
            _next = next;
        }

        public async Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            if (_validator is null)
            {
                return await _next.HandleAsync(request, cancellationToken);
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return await _next.HandleAsync(request, cancellationToken);
        }
    }
}