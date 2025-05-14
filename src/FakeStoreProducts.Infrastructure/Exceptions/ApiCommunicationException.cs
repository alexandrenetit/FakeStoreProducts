namespace FakeStoreProducts.Infrastructure.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre um erro na comunicação com a API externa
/// </summary>
public class ApiCommunicationException : Exception
{
    public ApiCommunicationException(string message) : base(message)
    {
    }

    public ApiCommunicationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static ApiCommunicationException Create(string endpoint, Exception innerException)
    {
        return new ApiCommunicationException(
            $"Erro ao comunicar com o endpoint {endpoint}. Mensagem: {innerException.Message}",
            innerException);
    }
}