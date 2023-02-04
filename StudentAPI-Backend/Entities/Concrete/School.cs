using Core.Entities.Abstract;

namespace Entities.Concrete;

public class School :IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}