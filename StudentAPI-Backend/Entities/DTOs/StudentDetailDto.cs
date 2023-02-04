using Core.Entities.Abstract;

namespace Entities.DTOs;

public class StudentDetailDto:IDto
{
    public int Id { get; set; }
    public string StudentName { get; set; }
    public int StudentAge { get; set; }
    public string ParentName { get; set; }
    public string SchoolName { get; set; }
    public string SchoolAddress { get; set; }

}