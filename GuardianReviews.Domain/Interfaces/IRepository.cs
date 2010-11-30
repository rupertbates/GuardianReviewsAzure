using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GuardianReviews.Domain.Interfaces
{
    public interface IRepository<T>
    {
        List<T> Select();
        List<T> Select(Func<T, bool> predicate);
        //List<TReturn> Select(Expression<)
        void Save(T entity);
        void SaveMany(IEnumerable<T> entities);
        void Delete(T entity);
    }
}
