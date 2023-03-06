using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface ISchoolService
{
    IDataResult<List<School>> GetAll();
    IDataResult<School> Get(int id);
    IResult Add(School school);
    IResult Update(School school);
    IResult Delete(int   schoolId);
}   