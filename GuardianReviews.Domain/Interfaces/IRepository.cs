using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuardianReviews.Domain.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Select();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
