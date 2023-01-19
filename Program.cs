using houses;
using houses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNpgsql<HousesContext>(builder.Configuration.GetConnectionString("cnnHouses"));

var app = builder.Build();

app.MapGet("/dbConnection", async ([FromServices] HousesContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"Database created: {dbContext.Database.IsNpgsql()}");
});

app.MapGet("/api/houses", async ([FromServices] HousesContext dbContext) =>
{
    return Results.Ok(dbContext.Houses);
});

app.MapPost("/api/houses", async ([FromServices] HousesContext dbContext, [FromBody] House house) =>
{
    house.HouseId = Guid.NewGuid();
    await dbContext.Houses.AddAsync(house);
    await dbContext.SaveChangesAsync();
    return Results.Ok("House created");
});

app.MapPut("/api/houses/{id}", async ([FromServices] HousesContext dbContext, [FromBody] House house, [FromRoute] Guid id) =>
{
    var currentHouse = await dbContext.Houses.FindAsync(id);
    if (currentHouse != null)
    {
        currentHouse.Title = house.Title;
        currentHouse.Motto = house.Motto;
        currentHouse.HouseInfluence = house.HouseInfluence;

        await dbContext.SaveChangesAsync();
        return Results.Ok("House updated");
    }

    return Results.NotFound("The house is not found");

});

app.MapDelete("/api/houses/{id}", async ([FromServices] HousesContext dbContext, [FromRoute] Guid id) =>
{
    var currentHouse = await dbContext.Houses.FindAsync(id);
    if (currentHouse != null)
    {
        dbContext.Houses.Remove(currentHouse);
        await dbContext.SaveChangesAsync();

        return Results.Ok("House deleted");
    }

    return Results.NotFound("The house is not found");

});

app.MapGet("/api/people", async ([FromServices] HousesContext dbContext) =>
{
    return Results.Ok(dbContext.People.Include(p => p.House));
});

app.MapPost("/api/people", async ([FromServices] HousesContext dbContext, [FromBody] Person person) =>
{
    person.PersonId = Guid.NewGuid();
    await dbContext.People.AddAsync(person);
    await dbContext.SaveChangesAsync();
    return Results.Ok("Person created");
});

app.Run();
