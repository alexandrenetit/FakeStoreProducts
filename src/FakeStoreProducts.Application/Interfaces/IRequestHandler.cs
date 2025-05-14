namespace FakeStoreProducts.Application.Interfaces;

/// <summary>
/// Interface para manipuladores de requisições
/// </summary>
/// <typeparam name="TRequest">Tipo da requisição</typeparam>
/// <typeparam name="TResponse">Tipo da resposta</typeparam>
public interface IRequestHandler<in TRequest, TResponse>
    where TRequest : notnull
{
    /// <summary>
    /// Manipula a requisição e retorna uma resposta
    /// </summary>
    /// <param name="request">Requisição a ser manipulada</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Resposta da requisição</returns>
    Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
}