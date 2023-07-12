namespace Tranzact.Premium.Domain.Common;

public abstract class ValueObjects
{
    protected static bool EqualOperator(ValueObjects left, ValueObjects right)
    {
        if(left is null ^ right is null) return false;

        return left?.Equals(right) != false;
    }

    protected static bool NonEqualOperator(ValueObjects left, ValueObjects right)
    {
        return !(EqualOperator(left, right));
    }
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType()) return false;

        var other = (ValueObjects)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }
}
