using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class SchoolManager:ISchoolService
{
    private ISchoolDal _schoolDal;

    public SchoolManager(ISchoolDal schoolDal)
    {
        _schoolDal = schoolDal;
    }

    public IDataResult<List<School>> GetAll()
    {
        return new SuccessDataResult<List<School>>(_schoolDal.GetAll());
    }

    public IDataResult<School> Get(int id)
    {
        return new SuccessDataResult<School>(_schoolDal.Get(s => s.Id == id));
    }

    [ValidationAspect(typeof(SchoolValidator))]
    public IResult Add(School school)
    {
        _schoolDal.Add(school);
        return new SuccessResult();
    }

    [ValidationAspect(typeof(SchoolValidator))]
    public IResult Update(School school)
    {
        _schoolDal.Update(school);
        return new SuccessResult();
    }

    public IResult Delete(int schoolId)
    {
        _schoolDal.Delete(_schoolDal.Get(s => s.Id == schoolId));
        return new SuccessResult();
    }
}