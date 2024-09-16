using Carter;
using DataSuggesting.API.Database;
using DataSuggesting.API.JsonConverters;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddCarter();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

var connectionStringBuilder = new NpgsqlConnectionStringBuilder(builder.Configuration.GetConnectionString("DataSuggestionsDb"))
    {
        Password = builder.Configuration["DataSuggestionsDbPassword"]
    };

var connection = connectionStringBuilder.ConnectionString;
builder.Services.AddDbContext<DataSuggestingDbContext>(options => options.UseNpgsql(connection));

builder.Services.Configure<JsonOptions>(options => options.SerializerOptions.Converters.Add(new EnumerationJsonConverter()));

var app = builder.Build();

app.UseCors(policyBuilder => policyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataSuggestingDbContext>();
    db.Database.Migrate();
}

app.MapCarter();

app.Run();