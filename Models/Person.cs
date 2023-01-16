namespace houses.Models;

public class Person
{
    public Guid PersonId { get; set; }
    public Guid HouseId { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string? NickName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Resume { get; set; }
    public virtual House House {get;set;}
}