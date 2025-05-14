namespace FakeStoreProducts.Infrastructure.Exceptions;

/// <summary>
/// Exceção lançada quando ocorre um erro na deserialização ou serialização de dados
/// </summary>
public class DataMappingException : Exception
{
    public DataMappingException(string message) : base(message)
    {
    }

    public DataMappingException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public static DataMappingException Create<TSource, TDestination>(Exception innerException)
    {
        return new DataMappingException(
            $"Erro ao mapear dados de {typeof(TSource).Name} para {typeof(TDestination).Name}. Mensagem: {innerException.Message}",
            innerException);
    }
}