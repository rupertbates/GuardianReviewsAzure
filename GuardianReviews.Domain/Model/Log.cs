using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace GuardianReviews.Domain.Model
{
    public class Log : Entity
    {
        public virtual DateTime Date { get; set; }
        public virtual string Thread { get; set; }
        public virtual string Context { get; set; }
        public virtual string Level { get; set; }
        public virtual string Logger { get; set; }
        public virtual string Message { get; set; }
        public virtual string Exception { get; set; }
    }
}
