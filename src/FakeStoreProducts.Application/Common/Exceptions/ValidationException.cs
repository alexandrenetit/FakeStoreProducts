using FluentValidation.Results;

namespace FakeStoreProducts.Application.Common.Exceptions;

/// <summary>
/// Exceção lançada quando a validação falha
/// </summary>
public class ValidationException : ApplicationException
{
    public ValidationException()
        : base("Erro de validação", "Um ou mais erros de validação ocorreram.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}