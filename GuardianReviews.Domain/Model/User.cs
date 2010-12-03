using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core.DomainModel;

namespace GuardianReviews.Domain.Model
{
    public class User : Entity
    {
        public virtual string ClaimedIdentifier { get; set; }
        public virtual string FriendlyIdentifier { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string OpenIdProvider { get; set; }
        public virtual string OpenIdProviderVersion { get; set; }
    }
}
