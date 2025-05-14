namespace FakeStoreProducts.Application.Interfaces;

/// <summary>
/// Interface base para casos de uso
/// </summary>
/// <typeparam name="TRequest">Tipo da requisição</typeparam>
/// <typeparam name="TResponse">Tipo da resposta</typeparam>
public interface IUseCase<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : notnull
{
    /// <summary>
    /// Executa o caso de uso
    /// </summary>
    /// <param name="request">Requisição para o caso de uso</param>
    /// <param name="cancellationToken">Token de cancelamento</param>
    /// <returns>Resposta do caso de uso</returns>
    Task<TResponse> ExecuteAsync(TRequest request, CancellationToken cancellationToken = default);
}