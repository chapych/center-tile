using DataSuggesting.API.Domain.SeedWork;

namespace DataSuggesting.API.Domain.ValueObjects;

public class Email : ValueObject<Email>
{
    public string Value { get; private set; }

    public Email(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck() => [Value];
}