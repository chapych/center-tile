using System.Reflection;

namespace DataSuggesting.API.Domain.SeedWork;

public abstract class Enumeration(int id, string name) : IComparable
{
    public string Name { get; init; } = name;

    public int Id { get; init; } = id;

    public override string ToString() => Name;

    private static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();

    public override bool Equals(object obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Id;

    public int CompareTo(object other) => Id.CompareTo(((Enumeration)other)!.Id);
    
    public static bool TryGetFromValueOrName<T>(
        string valueOrName,
        out T enumeration)
        where T : Enumeration
    {
        return TryParse(item => item.Name == valueOrName, out enumeration) ||
               int.TryParse(valueOrName, out var value) &&
               TryParse(item => item.Id == value, out enumeration);
    }
    
    private static bool TryParse<TEnumeration>(
        Func<TEnumeration, bool> predicate, 
        out TEnumeration enumeration)
        where TEnumeration : Enumeration
    {
        var enumerations = GetAll<TEnumeration>().ToList();
        enumeration = enumerations.FirstOrDefault(predicate);
        return enumeration != null;
    }
}