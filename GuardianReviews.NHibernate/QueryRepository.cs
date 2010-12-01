using System;
using System.Collections.Generic;
using System.Linq;
using GuardianReviews.Domain.BaseClasses;
using GuardianReviews.Domain.Interfaces;
using NHibernate;
using NHibernateExtensions = NHibernate.Linq.NHibernateExtensions;

namespace GuardianReviews.NHibernate
{
    public class QueryRepository<T> : SharpArch.Data.NHibernate.Repository<T>, IQueryRepository<T> 
    {
        public void SaveMany(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                Session.SaveOrUpdate(entity);
            }
        }
        public IList<T> FindAll(Func<T, bool> predicate)
        {
            return FindAll(predicate, null);
        }
        public IList<T> FindAll(QueryOptions<T> options)
        {
            return ExecuteQueryOptions(NHibernateExtensions.Linq<T>(Session), options);
        }
        public IList<T> FindAll(Func<T, bool> predicate, QueryOptions<T> options)
        {
            return ExecuteQueryOptions(NHibernateExtensions.Linq<T>(Session)
                                           .Where(predicate).AsQueryable(),
                                       options);
        }
        protected IList<T> ExecuteQueryOptions(IQueryable<T> query, QueryOptions<T> options)
        {
            if (options.OrderBySelector != null)
            {
                if (options.OrderDirection == OrderByDirection.Ascending)
                    query = query.OrderBy(options.OrderBySelector).AsQueryable();
                else
                    query = query.OrderByDescending<T, object>(options.OrderBySelector).AsQueryable();
            }
            if (options.Skip != null)
                query = query.Skip(options.Skip.Value);
            if (options.Take != null)
                query = query.Take(options.Take.Value);
            return query.ToList();
        }
    }
}