using houses.Models;
namespace houses.Interfaces;
public interface IPeopleService { 

    IEnumerable<Person> Get();
    Task GetById(Guid id);
    Task Save(Person person);
    Task Update(Guid id, Person person);
    Task Delete(Guid id);
}