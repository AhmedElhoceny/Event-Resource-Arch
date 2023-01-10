using DataAccess.DependencyInjections;
using DataAccess.HrModuleEvents.Interfaces;
using EventResourceArch;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("EventsDBSettings:ConnectionString")));

// Add services to the container.
builder.Services.Configure<EventsDBSettings>(
builder.Configuration.GetSection(nameof(EventsDBSettings)));

builder.Services.AddSingleton<EventsDBSettings>(sp =>
sp.GetRequiredService<IOptions<EventsDBSettings>>().Value);

// Loading Events Data Access Repos
builder.Services.LoadReposDependencyInjections();


// Add services to the container.

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
