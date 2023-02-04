using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface IStudentDal:IEntityRepository<Student>
{
    List<StudentDetailDto> GetStudentDetailDto();

    StudentDetailDto GetStudentDetailDtoById(int studentId);
}