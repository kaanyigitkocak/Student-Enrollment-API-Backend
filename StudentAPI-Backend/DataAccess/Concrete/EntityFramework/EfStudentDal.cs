using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfStudentDal:EntityRepositoryBase<Student, StudentContext>, IStudentDal
{
    public List<StudentDetailDto> GetStudentDetailDto()
    {
        using (StudentContext context = new StudentContext())
        {
            var result = from student in context.Students
                join parent in context.Parents on student.ParentId equals parent.Id
                join school in context.Schools on student.SchoolId equals school.Id
                select new StudentDetailDto()
                {
                    StudentName = student.Name,
                    ParentName = parent.Name,
                    SchoolName = school.Name,
                    SchoolAddress = school.Address,
                    StudentAge= student.Age
                };
            return result.ToList();
        }
    }

    public StudentDetailDto GetStudentDetailDtoById(int studentId)
    {
        using (StudentContext context = new StudentContext())
        {
            var result = from student in context.Students
                         join parent in context.Parents on student.ParentId equals parent.Id
                         join school in context.Schools on student.SchoolId equals school.Id
                         select new StudentDetailDto()
                         {
                             Id = student.Id,
                             StudentName = student.Name,
                             ParentName = parent.Name,
                             SchoolName = school.Name,
                             SchoolAddress = school.Address,
                             StudentAge = student.Age
                         };
            return result.Where(s => s.Id == studentId).Single();
        }
    }
}