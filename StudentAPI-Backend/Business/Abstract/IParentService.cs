using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract;

public interface IParentService
{
    IDataResult<List<Parent>> GetAll();
    IDataResult<Parent> Get(int id);
    IResult Add(Parent parent);
    IResult Update(Parent parent);
    IResult Delete(int parentId);
}