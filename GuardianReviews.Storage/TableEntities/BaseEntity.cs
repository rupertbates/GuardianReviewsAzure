using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;

namespace GuardianReviews.Storage.TableEntities
{
    public class BaseEntity : TableServiceEntity
    {
        public BaseEntity():base(Guid.NewGuid().ToString(), "")
        {
        }
    }
}
