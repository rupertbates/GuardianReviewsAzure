using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuardianReviews.Domain.BaseClasses
{
    public enum OrderByDirection { Ascending, Descending }
    public class QueryOptions<T>
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public Func<T, object> OrderBySelector{ get; set; }
        public OrderByDirection OrderDirection { get; set; }
    }
}
