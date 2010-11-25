using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuardianReviews.Domain.Interfaces;
namespace GuardianReviews.Storage
{
    public class AzureTableRepository<T> : IRepository<T>
    {
        public List<T> Select(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
