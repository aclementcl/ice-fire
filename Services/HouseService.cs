using houses.Interfaces;
using houses.Models;

namespace houses.Services;
public class HousesService : IHousesService
{
    private readonly HousesContext _dbContext;
    public HousesService(HousesContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<House> Get()
    {
        return _dbContext.Houses;
    }

    public Task GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Save(House house)
    {
        throw new NotImplementedException();
    }

    public Task Update(Guid id, House house)
    {
        throw new NotImplementedException();
    }
}