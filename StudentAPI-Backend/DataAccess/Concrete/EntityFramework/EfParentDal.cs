using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfParentDal:EntityRepositoryBase<Parent,StudentContext>,IParentDal
{
    
}