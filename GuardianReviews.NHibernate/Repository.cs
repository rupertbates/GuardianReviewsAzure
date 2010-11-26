using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
namespace KableDirect.Ted.Reports.Database
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private ISession _session;
        public Repository(ISession session)
        {
            _session = session;
        }
        public IEnumerable<T> SelectAll()
        {
            return _session
                .Linq<T>()
                .ToList();
        }
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
    }
}
