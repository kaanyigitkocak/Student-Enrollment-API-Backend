using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Student:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int SchoolId { get; set; }
    public int ParentId { get; set; }

    
}