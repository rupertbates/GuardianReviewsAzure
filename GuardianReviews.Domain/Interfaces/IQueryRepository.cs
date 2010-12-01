using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using GuardianReviews.Domain.BaseClasses;
using SharpArch.Core.PersistenceSupport;

namespace GuardianReviews.Domain.Interfaces
{
    public interface IQueryRepository<T> : IRepository<T>
    {
        IList<T> FindAll(QueryOptions<T> options);
        IList<T> FindAll(Func<T, bool> predicate);
        IList<T> FindAll(Func<T, bool> predicate, QueryOptions<T> options);
        void SaveMany(IEnumerable<T> entities);
    }
}
