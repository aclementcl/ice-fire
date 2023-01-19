using houses.Interfaces;
using houses.Models;

namespace houses.Services;
public class PeopleService : IPeopleService
{
    private readonly HousesContext _dbContext;
    public PeopleService(HousesContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Person> Get()
    {
        return _dbContext.People;
    }

    public Task GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Save(Person person)
    {
        throw new NotImplementedException();
    }

    public Task Update(Guid id, Person person)
    {
        throw new NotImplementedException();
    }
}