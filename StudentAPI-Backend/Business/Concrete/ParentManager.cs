using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ParentManager:IParentService
{
    private IParentDal _parentDal;

    public ParentManager(IParentDal parentDal)
    {
        _parentDal = parentDal;
    }

    [CacheAspect]
    public IDataResult<List<Parent>> GetAll()
    {
        return new SuccessDataResult<List<Parent>>(_parentDal.GetAll());
    }

    public IDataResult<Parent> Get(int id)
    {
        if (_parentDal.Get(p => p.Id == id) == null)
        {
            return new ErrorDataResult<Parent>("Bu id degerine sahip parent bulunamadi");
        }
        return new SuccessDataResult<Parent>(_parentDal.Get(p => p.Id == id));
    }

    [TransactionScopeAspect]
    [CacheRemoveAspect("IParentService.Get")]
    [ValidationAspect(typeof(ParentValidator))]
    public IResult Add(Parent parent)
    {
        _parentDal.Add(parent);

        if (parent.Name == "asd")
        {
            throw new Exception("asdsadasdsad");
        }
        return new SuccessResult();
    }


    [CacheRemoveAspect("IParentService.Get")]
    [ValidationAspect(typeof(ParentValidator))]
    public IResult Update(Parent parent)
    {
        _parentDal.Update(parent);
        return new SuccessResult();
    }

    [CacheRemoveAspect("IParentService.Get")]
    public IResult Delete(int parentId)
    {
        _parentDal.Delete(_parentDal.Get(p => p.Id == parentId));
        return new SuccessResult();
    }
}