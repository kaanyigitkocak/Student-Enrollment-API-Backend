using Core.Entities.Abstract;

namespace Entities.Concrete;

public class Parent:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int Phone { get; set; }


}