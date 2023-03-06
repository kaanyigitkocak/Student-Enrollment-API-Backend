using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete;

public class StudentManager:IStudentService
{
    private IStudentDal _studentDal;
    private IConfirmationService _confirmationService;

    public StudentManager(IStudentDal studentDal, IConfirmationService confirmationService)
    {
        _studentDal = studentDal;
        _confirmationService = confirmationService;
    }

    [SecuredOperation("admin")]
    public IDataResult<List<Student>> GetAll()
    {

        return new SuccessDataResult<List<Student>>(_studentDal.GetAll(),"tum ogrenciler basariyla getirildi") ;
    }
     
    public IDataResult<Student> Get(int id)
    {
        
        return new SuccessDataResult<Student>(_studentDal.Get(s => s.Id == id));
    }

    //[ValidationAspect(typeof(StudentValidator))]
    public IResult Add(Student student)
    {
        
        if (student.Age >= 19)
        {
            
            return new ErrorResult("The student must be older than 6 or younger than 19 years old.");
        }
            _confirmationService.Create(student.ParentId);
            _studentDal.Add(student);
            return new SuccessResult("The student has been successfully added.");

        
    }

    //[ValidationAspect(typeof(StudentValidator))]
    public IResult Update(Student student)
    {
        _studentDal.Update(student);
        return new SuccessResult("The student has been successfully updated.");
    }

    public IResult Delete(int studentId)
    {

        _studentDal.Delete(_studentDal.Get(s => s.Id == studentId));
        return new SuccessResult("The student has been successfully deleted.");
    }

    public IDataResult<List<Student>> GetStudentsByParentId(int parentId)
    {
        return new SuccessDataResult<List<Student>>(_studentDal.GetAll(student => student.ParentId == parentId));
    }

    public IDataResult<List<Student>> GetStudentsBySchoolId(int schoolId)
    {
        return new SuccessDataResult<List<Student>>(_studentDal.GetAll(student => student.SchoolId == schoolId));
    }   

    public IDataResult<List<StudentDetailDto>> GetStudentDetailDto()
    {
        return new SuccessDataResult<List<StudentDetailDto>>(_studentDal.GetStudentDetailDto());
    }

    public IDataResult<StudentDetailDto> GetStudentDetailDtoById(int studentId)
    {
        return new SuccessDataResult<StudentDetailDto>(_studentDal.GetStudentDetailDtoById(studentId));
    }
}