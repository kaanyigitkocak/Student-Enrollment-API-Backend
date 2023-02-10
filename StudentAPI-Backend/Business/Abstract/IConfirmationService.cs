using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IConfirmationService
    {
        IDataResult<List<Confirmation>> GetAll();
        IDataResult<Confirmation> Get(int id);
        IResult Create(int parentId);
        IResult Delete(int confirmationId);
        IResult VerifyConfirm(int confirmId,string code);
    }
}
