namespace FakeStoreProducts.Application.DTOs.Responses;

/// <summary>
/// Resposta de erro padrão
/// </summary>
public record ErrorResponse : BaseResponse
{
    /// <summary>
    /// Inicializa uma nova instância de ErrorResponse
    /// </summary>
    /// <param name="message">Mensagem de erro</param>
    public ErrorResponse(string message)
    {
        Success = false;
        Message = message;
        Errors = new Dictionary<string, string[]>();
    }

    /// <summary>
    /// Inicializa uma nova instância de ErrorResponse com erros de validação
    /// </summary>
    /// <param name="message">Mensagem de erro</param>
    /// <param name="errors">Dicionário de erros de validação</param>
    public ErrorResponse(string message, IDictionary<string, string[]> errors)
    {
        Success = false;
        Message = message;
        Errors = errors;
    }

    /// <summary>
    /// Dicionário de erros de validação
    /// </summary>
    public IDictionary<string, string[]> Errors { get; }
}