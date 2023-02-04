using Business.Abstract;
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

    public IResult Add(School school)
    {
        _schoolDal.Add(school);
        return new SuccessResult();
    }

    public IResult Update(School school)
    {
        _schoolDal.Update(school);
        return new SuccessResult();
    }

    public IResult Delete(School school)
    {
        _schoolDal.Delete(school);
        return new SuccessResult();
    }
}