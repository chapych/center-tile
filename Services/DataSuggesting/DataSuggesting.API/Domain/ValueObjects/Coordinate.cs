using DataSuggesting.API.Domain.SeedWork;

namespace DataSuggesting.API.Domain.ValueObjects;

public class Coordinate(double latitude, double longitude) : ValueObject<Coordinate>
{
    public double Latitude { get; private set; } = latitude;
    public double Longitude { get; private set; } = longitude;
    protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck() => [Latitude, Longitude];
}