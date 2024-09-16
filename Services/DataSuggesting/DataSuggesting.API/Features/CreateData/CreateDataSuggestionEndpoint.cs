using Carter;
using DataSuggesting.API.Domain.Enumerations;
using DataSuggesting.API.Domain.ValueObjects;
using MediatR;

namespace DataSuggesting.API.Features.CreateData;

public record CreateDataSuggestingRequest(
    IEnumerable<Coordinate> Coordinates,
    Material Material,
    string Email,
    string Comment);

public record CreateDataSuggestingResponse(Guid SuggestionId);

public sealed class CreateDataSuggestionEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/suggestions", async (CreateDataSuggestingRequest request, ISender sender) =>
        {
            var email = new Email(request.Email);
            var comment = new Comment(request.Comment);
            
            var createDataSuggestingCommand = new CreateDataSuggestingCommand(email,
                comment, request.Coordinates, request.Material);

            var createDataSuggestionResult = await sender.Send(createDataSuggestingCommand);

            var response = new CreateDataSuggestingResponse(createDataSuggestionResult.SuggestionId);

            return Results.Ok(response);
        });
    }
}