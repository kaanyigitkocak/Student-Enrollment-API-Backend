using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ConfirmationManager : IConfirmationService
    {
        private IConfirmationDal _confirmationDal;

        public ConfirmationManager(IConfirmationDal confirmationDal)
        {
            _confirmationDal = confirmationDal;
        }

        [ValidationAspect(typeof(ConfirmationValidator))]
        public IResult Create(int parentId)
        {
            _confirmationDal.Add(_confirmationDal.CreateConfirmation(parentId));
            SendCode(parentId);
            return new SuccessResult();
        }

        public IResult Delete(int confirmationId)
        {
            _confirmationDal.Delete(_confirmationDal.Get(a => a.Id == confirmationId));
            return new SuccessResult();
        }

        public IDataResult<Confirmation> Get(int id)
        {
            return new SuccessDataResult<Confirmation>(_confirmationDal.Get(a => a.Id == id));
        }

        public IDataResult<List<Confirmation>> GetAll()
        {
            
            return new SuccessDataResult<List<Confirmation>>(_confirmationDal.GetAll());
        }

        public IResult VerifyConfirm(int confirmId, string code)
        {
            if (_confirmationDal.Get(c => c.Code == code) != null && _confirmationDal.Get(c => c.Id == confirmId) != null)
            {
                return new SuccessResult("kod dogru");
            }
            return new ErrorResult("kod yanlis ");
        }

        public void SendCode(int parentId)
        {
            //bla bla bla
            //bla bla bla
        }

      
    }
}
