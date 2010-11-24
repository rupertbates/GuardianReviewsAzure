using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;

namespace GuardianReviews.Storage.TableEntities
{
    public class ReviewEntity : BaseEntity
    {
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public int ReviewType { get; set; }
        public int? StarRating { get; set; }
    }
}
