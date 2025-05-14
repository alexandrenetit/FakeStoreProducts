namespace FakeStoreProducts.Application.DTOs.Responses;

/// <summary>
/// Resposta de sucesso padrão
/// </summary>
public record SuccessResponse : BaseResponse
{
    /// <summary>
    /// Inicializa uma nova instância de SuccessResponse
    /// </summary>
    /// <param name="message">Mensagem de sucesso</param>
    public SuccessResponse(string message)
    {
        Success = true;
        Message = message;
    }
}