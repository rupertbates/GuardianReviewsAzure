using System.Collections.Generic;
using System.ComponentModel;
using GuardianReviews.Domain.BaseClasses;

namespace GuardianReviews.Domain.Model
{
    public class MusicTypes : Enumeration
    {

        public static readonly MusicTypes Classical = new MusicTypes(0, "Classical music and opera");
        public static readonly MusicTypes Electronic = new MusicTypes(1, "Electronic music");
        public static readonly MusicTypes Jazz = new MusicTypes(2, "Jazz");
        public static readonly MusicTypes Folk = new MusicTypes(3, "Folk");
        public static readonly MusicTypes Pop = new MusicTypes(4, "Pop and Rock");
        public static readonly MusicTypes Urban = new MusicTypes(5, "Urban music");
        public static readonly MusicTypes World = new MusicTypes(6, "World music");
        public static readonly MusicTypes Soul = new MusicTypes(7, "Soul");
        public static readonly MusicTypes DanceMusic = new MusicTypes(8, "Dance music");
        public static readonly MusicTypes Unknown = new MusicTypes(9, "Unknown");
        private MusicTypes(int id, string displayName)
        {
            Id = id;
            DisplayName = displayName;
        }
        public MusicTypes()
        {
            Reviews = new List<MusicReview>();
        }

        public virtual IList<MusicReview> Reviews { get; private set; }
    }
}
