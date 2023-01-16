using houses.Models;
using Microsoft.EntityFrameworkCore;

namespace houses;

public class HousesContext : DbContext
{
    public DbSet<House> Houses { get; set; }
    public DbSet<Person> People { get; set; }
    public HousesContext(DbContextOptions<HousesContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<House> housesInit = new();
        housesInit.Add(new House() { HouseId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab7"), Title = "Stark", Motto = "Winter is Comming" });
        housesInit.Add(new House() { HouseId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab6"), Title = "Targaryen", Motto = "Fire and Blood" });

        modelBuilder.Entity<House>(house =>
        {
            house.ToTable("House");
            house.HasKey(x => x.HouseId);

            house.Property(x => x.Title).IsRequired().HasMaxLength(100);
            house.Property(x => x.Motto).IsRequired();
            house.Property(x => x.Description).IsRequired(false);
            house.Property(x => x.ShieldUrl).IsRequired(false);
            house.Property(x => x.HouseInfluence);
            house.Property(x => x.StartDate);

            house.HasData(housesInit);
        });

        List<Person> peopleInit = new();
        peopleInit.Add(new Person() { PersonId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab5"), HouseId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab7"), Name = "Jon", LastName = "Snow", NickName = "The Winterfell bastard" });
        peopleInit.Add(new Person() { PersonId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab4"), HouseId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab7"), Name = "Eddard", LastName = "Stark" });
        peopleInit.Add(new Person() { PersonId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab3"), HouseId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab7"), Name = "Robb", LastName = "Stark", NickName = "The young wolf" });
        peopleInit.Add(new Person() { PersonId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab2"), HouseId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab7"), Name = "Rickon", LastName = "Stark" });
        peopleInit.Add(new Person() { PersonId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab1"), HouseId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab6"), Name = "Aegon", LastName = "Targaryen", NickName = "The Conqueror" });
        peopleInit.Add(new Person() { PersonId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ac7"), HouseId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab6"), Name = "Daemon", LastName = "Targaryen" });
        peopleInit.Add(new Person() { PersonId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ac6"), HouseId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab6"), Name = "Baelor", LastName = "Targaryen" });
        peopleInit.Add(new Person() { PersonId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ac5"), HouseId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab6"), Name = "Aenys", LastName = "Targaryen" });
        peopleInit.Add(new Person() { PersonId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ac4"), HouseId = Guid.Parse("dc374853-680b-4fb0-acaf-e0e521359ab6"), Name = "Maegor", LastName = "Targaryen" });

        modelBuilder.Entity<Person>(person =>
        {
            person.ToTable("Person");
            person.HasKey(x => x.PersonId);
            person.HasOne(x => x.House).WithMany(x => x.People).HasForeignKey(x => x.HouseId);

            person.Property(x => x.Name).IsRequired().HasMaxLength(100);
            person.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            person.Property(x => x.NickName).IsRequired(false);
            person.Property(x => x.BirthDate);
            person.Ignore(x => x.Resume);

            person.HasData(peopleInit);
        });
    }
}