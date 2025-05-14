using FakeStoreProducts.Domain.Exceptions;

namespace FakeStoreProducts.Infrastructure.Exceptions;

/// <summary>
/// Extensões para tratamento de exceções HTTP
/// </summary>
public static class HttpExceptionHandlerExtensions
{
    /// <summary>
    /// Executa uma ação HTTP e trata as exceções de forma padronizada
    /// </summary>
    /// <typeparam name="T">Tipo de retorno da ação</typeparam>
    /// <param name="action">Ação a ser executada</param>
    /// <param name="endpoint">Nome do endpoint para logging</param>
    /// <returns>Resultado da ação</returns>
    public static async Task<T> ExecuteWithExceptionHandlingAsync<T>(Func<Task<T>> action, string endpoint)
    {
        try
        {
            return await action();
        }
        catch (HttpRequestException ex)
        {
            throw ApiCommunicationException.Create(endpoint, ex);
        }
        catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
        {
            throw ApiCommunicationException.Create(endpoint, new TimeoutException($"A requisição para {endpoint} excedeu o tempo limite.", ex));
        }
        catch (TaskCanceledException ex)
        {
            throw ApiCommunicationException.Create(endpoint, new OperationCanceledException($"A requisição para {endpoint} foi cancelada.", ex));
        }
        catch (Exception ex) when (ex is not DomainException)
        {
            throw ApiCommunicationException.Create(endpoint, ex);
        }
    }

    /// <summary>
    /// Executa uma ação HTTP e trata as exceções de forma padronizada, sem retorno
    /// </summary>
    /// <param name="action">Ação a ser executada</param>
    /// <param name="endpoint">Nome do endpoint para logging</param>
    public static async Task ExecuteWithExceptionHandlingAsync(Func<Task> action, string endpoint)
    {
        try
        {
            await action();
        }
        catch (HttpRequestException ex)
        {
            throw ApiCommunicationException.Create(endpoint, ex);
        }
        catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
        {
            throw ApiCommunicationException.Create(endpoint, new TimeoutException($"A requisição para {endpoint} excedeu o tempo limite.", ex));
        }
        catch (TaskCanceledException ex)
        {
            throw ApiCommunicationException.Create(endpoint, new OperationCanceledException($"A requisição para {endpoint} foi cancelada.", ex));
        }
        catch (Exception ex) when (ex is not DomainException)
        {
            throw ApiCommunicationException.Create(endpoint, ex);
        }
    }
}