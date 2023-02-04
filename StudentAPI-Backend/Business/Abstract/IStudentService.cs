using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract;

public interface IStudentService
{
    IDataResult<List<Student>> GetAll();
    IDataResult<Student> Get(int id);
    IResult Add(Student student);
    IResult Update(Student student);
    IResult Delete(int studentId);

    IDataResult<List<Student>> GetStudentsByParentId(int parentId);
    IDataResult<List<Student>> GetStudentsBySchoolId(int schoolId);
    IDataResult<List<StudentDetailDto>> GetStudentDetailDto();

    IDataResult<StudentDetailDto> GetStudentDetailDtoById(int studentId);
}