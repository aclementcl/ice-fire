using houses.Models;

namespace houses.Interfaces;
public interface IHousesService { 

    IEnumerable<House> Get();
    Task GetById(Guid id);
    Task Save(House house);
    Task Update(Guid id, House house);
    Task Delete(Guid id);
}