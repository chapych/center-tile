namespace DataSuggesting.API.Domain.SeedWork;

public abstract class ValueObject<T> where T : ValueObject<T>
{
    protected abstract IEnumerable<object> GetAttributesToIncludeInEqualityCheck();

    public override bool Equals(object other) => Equals(other as T);

    private bool Equals(T other) =>
        other != null && GetAttributesToIncludeInEqualityCheck()
            .SequenceEqual(other.GetAttributesToIncludeInEqualityCheck());

    public static bool operator ==(ValueObject<T> left, ValueObject<T> right) => 
        Equals(left, right);

    public static bool operator !=(ValueObject<T> left, ValueObject<T> right) => 
        !(left == right);

    public override int GetHashCode() => GetAttributesToIncludeInEqualityCheck()
        .Select(x => x != null ? x.GetHashCode() : 0)
        .Aggregate((x, y) => x ^ y);
}
