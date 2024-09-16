using DataSuggesting.API.Domain.SeedWork;

namespace DataSuggesting.API.Domain.ValueObjects;

public class Comment : ValueObject<Comment>
{
    public string Text { get; init; }

    public Comment(string text)
    {
        Text = text;
    }

    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck() => [Text];
}