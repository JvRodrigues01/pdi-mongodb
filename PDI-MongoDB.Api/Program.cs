using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PDI_MongoDB.Infra.Context;
using PDI_MongoDB.Infra.Repositories;
using PDI_MongoDB.Services.Services;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddSingleton<IMongoClient>(x =>
{
    var options = x.GetService<DatabaseConfig>();

    return new MongoClient(options.ConnectionString);
});

builder.Services.AddSingleton(x => {
    var options = new DatabaseConfig();
    configuration.GetSection("DatabaseConfig").Bind(options);

    return options;
});

builder.Services.AddTransient(x =>
{
    BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

    var options = x.GetService<DatabaseConfig>();
    var mongoClient = x.GetService<IMongoClient>();

    return mongoClient.GetDatabase(options.DatabaseName);
});

builder.Services.AddScoped<IWorkService, WorkService>();
builder.Services.AddSingleton<IWorkRepository, WorkRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
