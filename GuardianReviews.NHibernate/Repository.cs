using System;
using System.Collections.Generic;
using System.Linq;
using GuardianReviews.Domain.Interfaces;
using NHibernate;
using NHibernate.Linq;

namespace GuardianReviews.NHibernate
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ISession _session;
        public Repository(ISession session)
        {
            _session = session;
        }
        public List<T> Select()
        {
            return _session
                .Linq<T>()
                .ToList();
        }
        public List<T> Select(Func<T, bool> predicate)
        {
            return _session
                .Linq<T>()
                .Where(predicate)
                .ToList();
        }
        //public List<TResult> Select(Expression<Func<T>)

        public void Save(T entity)
        {
            _session.Save(entity);
            _session.Flush();
        }
        public void SaveMany(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _session.SaveOrUpdate(entity);
            }
            _session.Flush();
        }
        public void Delete(T entity)
        {
            _session.Delete(entity);
        }
    }
}
