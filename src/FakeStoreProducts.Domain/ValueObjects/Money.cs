using FakeStoreProducts.Domain.Exceptions;

namespace FakeStoreProducts.Domain.ValueObjects;

public class Money
{
    public decimal Value { get; }
    public string Currency { get; }

    private Money() { }

    public Money(decimal value, string currency = "USD")
    {
        if (value < 0)
            throw new DomainException("Valor monetário não pode ser negativo.");

        if (string.IsNullOrWhiteSpace(currency))
            throw new DomainException("Moeda não pode ser vazia.");

        Value = value;
        Currency = currency;
    }

    public static Money FromDecimal(decimal value, string currency = "USD")
    {
        return new Money(value, currency);
    }

    public Money Add(Money other)
    {
        if (other.Currency != Currency)
            throw new DomainException("Não é possível somar valores em moedas diferentes.");

        return new Money(Value + other.Value, Currency);
    }

    public Money Subtract(Money other)
    {
        if (other.Currency != Currency)
            throw new DomainException("Não é possível subtrair valores em moedas diferentes.");

        return new Money(Value - other.Value, Currency);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Money other)
            return false;

        return Value == other.Value && Currency == other.Currency;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, Currency);
    }

    public static bool operator ==(Money left, Money right)
    {
        if (left is null)
            return right is null;

        return left.Equals(right);
    }

    public static bool operator !=(Money left, Money right)
    {
        return !(left == right);
    }

    public override string ToString()
    {
        return $"{Value} {Currency}";
    }
}