namespace FakeStoreProducts.Application.DTOs.Responses;

/// <summary>
/// Resposta base para todas as respostas da aplicação
/// </summary>
public record BaseResponse
{
    /// <summary>
    /// Inicializa uma nova instância de BaseResponse
    /// </summary>
    public BaseResponse()
    {
    }

    /// <summary>
    /// Inicializa uma nova instância de BaseResponse com uma mensagem
    /// </summary>
    /// <param name="success">Indica se a operação foi bem-sucedida</param>
    /// <param name="message">Mensagem de resposta</param>
    public BaseResponse(bool success, string? message = null)
    {
        Success = success;
        Message = message;
    }

    /// <summary>
    /// Indica se a operação foi bem-sucedida
    /// </summary>
    public bool Success { get; init; }

    /// <summary>
    /// Mensagem de resposta (geralmente usada para erros)
    /// </summary>
    public string? Message { get; init; }

    /// <summary>
    /// Data e hora da resposta
    /// </summary>
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
}