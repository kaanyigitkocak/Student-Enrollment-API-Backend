using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Confirmation:IEntity
    {
        public int Id { get; set; }
        public int UserPhone { get; set; }

        public string Code { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastDate { get; set;}

    }
}
