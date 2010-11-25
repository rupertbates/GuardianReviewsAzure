using System;
using System.Collections.Generic;
using System.Data.Services.Common;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;

namespace GuardianReviews.Storage.TableEntities
{
    [DataServiceKey("PartitionKey", "RowKey")]
    public class BaseEntity
    {
        public string RowKey { get; set; }
        public string PartitionKey { get; set; }
        public BaseEntity():this(Guid.NewGuid().ToString(), "")
        {
        }
        public BaseEntity(string rowKey, string partitionKey)
        {
            RowKey = rowKey;
            PartitionKey = partitionKey;
        }
    }
}
