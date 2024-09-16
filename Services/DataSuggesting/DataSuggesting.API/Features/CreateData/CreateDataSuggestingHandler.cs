using BuildingBlocks.CQRS;
using DataSuggesting.API.Database;
using DataSuggesting.API.Domain.Entities;
using DataSuggesting.API.Domain.Enumerations;
using DataSuggesting.API.Domain.ValueObjects;

namespace DataSuggesting.API.Features.CreateData;

public record CreateDataSuggestingCommand(
    Email Email, 
    Comment Comment,
    IEnumerable<Coordinate> Coordinates,
    Material Material)
    : ICommand<CreateDataSuggestionResult>;
public record CreateDataSuggestionResult(Guid SuggestionId);

public sealed class CreateDataSuggestingHandler 
    : ICommandHandler<CreateDataSuggestingCommand, CreateDataSuggestionResult>
{
    private readonly DataSuggestingDbContext _context;

    public CreateDataSuggestingHandler(DataSuggestingDbContext context)
    {
        _context = context;
    }

    public async Task<CreateDataSuggestionResult> Handle(CreateDataSuggestingCommand command, CancellationToken cancellationToken)
    {
        var dataSuggestion = new DataSuggestion(command.Email, command.Comment, command.Coordinates, command.Material);

        _context.DataSuggestions.Add(dataSuggestion);

        await _context.SaveChangesAsync(cancellationToken);

        return new CreateDataSuggestionResult(dataSuggestion.Id);
    }
}