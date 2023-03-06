using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete;

public class Parent:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public int Phone { get; set; }


}