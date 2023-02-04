using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfConfirmationDal : EntityRepositoryBase<Confirmation, StudentContext>, IConfirmationDal
    {
        private DateTime createdDate;
        private DateTime lastDate;
        private static Random random = new Random();

        public Confirmation CreateConfirmation(int ParentId)
        {
            createdDate = DateTime.Now;
            lastDate = createdDate.AddMinutes(5);
            using (StudentContext context = new StudentContext())
            {
                var result = from Parent in context.Parents
                             where Parent.Id == ParentId
                             select new Confirmation()
                             {
                                 CreatedDate = createdDate,
                                 LastDate = lastDate,
                                 UserPhone = Parent.Phone,
                                 Code = RandomString(5)
                             };
                context.SaveChanges();
                return result.Single();
            }
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
