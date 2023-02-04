using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IConfirmationDal:IEntityRepository<Confirmation>
    {
        Confirmation CreateConfirmation(int ParentId);

    }
}
