namespace FakeStoreProducts.Application.Common.Exceptions
{
    /// <summary>
    /// Exceção lançada quando um recurso não é encontrado
    /// </summary>
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base("Recurso não encontrado", $"O recurso '{name}' ({key}) não foi encontrado.")
        {
            Name = name;
            Key = key;
        }

        public string Name { get; }
        public object Key { get; }
    }
}