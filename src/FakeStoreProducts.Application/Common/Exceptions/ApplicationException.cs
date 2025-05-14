namespace FakeStoreProducts.Application.Common.Exceptions;

/// <summary>
/// Exceção base para todas as exceções da camada de aplicação
/// </summary>
public abstract class ApplicationException : Exception
{
    protected ApplicationException(string title, string message)
        : base(message)
    {
        Title = title;
    }

    public string Title { get; }
}