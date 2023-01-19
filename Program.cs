using houses;
using houses.Interfaces;
using houses.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddNpgsql<HousesContext>(builder.Configuration.GetConnectionString("cnnHouses"));

builder.Services.AddScoped<IHousesService, HousesService>();
builder.Services.AddScoped<IPeopleService, PeopleService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/dbConnection", async ([FromServices] HousesContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"Database created: {dbContext.Database.IsNpgsql()}");
});

app.MapControllers();

app.Run();
