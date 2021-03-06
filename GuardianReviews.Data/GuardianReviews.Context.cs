//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace GuardianReviews.Domain
{
    public partial class GuardianReviewsContainer : ObjectContext
    {
        public const string ConnectionString = "name=GuardianReviewsContainer";
        public const string ContainerName = "GuardianReviewsContainer";
    
        #region Constructors
    
        public GuardianReviewsContainer()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public GuardianReviewsContainer(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public GuardianReviewsContainer(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<Review> Reviews
        {
            get { return _reviews  ?? (_reviews = CreateObjectSet<Review>("Reviews")); }
        }
        private ObjectSet<Review> _reviews;
    
        public ObjectSet<MusicType> MusicTypes
        {
            get { return _musicTypes  ?? (_musicTypes = CreateObjectSet<MusicType>("MusicTypes")); }
        }
        private ObjectSet<MusicType> _musicTypes;

        #endregion
    }
}
