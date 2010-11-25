using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;
using GuardianReviews.Domain;


namespace GuardianReviews.Web
{
    [System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class ReviewsDataService : DataService<GuardianReviewsContainer>
    {
        // This method is called only once to initialize service-wide policies.
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
            config.UseVerboseErrors = true;
        }
        protected override GuardianReviewsContainer CreateDataSource()
        {
            var context = new GuardianReviewsContainer();
            var tracestring = context.CreateQuery<Review>("Reviews").ToTraceString();
            return context;
        }
    }
}
