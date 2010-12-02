using System.Collections.Generic;
using System.ComponentModel;
using GuardianReviews.Domain.BaseClasses;

namespace GuardianReviews.Domain.Model
{
    public class MusicTypes : Enumeration
    {

        public static readonly MusicTypes Classical = new MusicTypes(1, "classical", "Classical music and opera");
        public static readonly MusicTypes Electronic = new MusicTypes(2, "electronic", "Electronic music");
        public static readonly MusicTypes Jazz = new MusicTypes(3, "Jazz");
        public static readonly MusicTypes Folk = new MusicTypes(4, "Folk");
        public static readonly MusicTypes Pop = new MusicTypes(5, "popandrock", "Pop and Rock");
        public static readonly MusicTypes Urban = new MusicTypes(6, "urban", "Urban music");
        public static readonly MusicTypes World = new MusicTypes(7, "world", "World music");
        public static readonly MusicTypes Soul = new MusicTypes(8, "Soul");
        public static readonly MusicTypes DanceMusic = new MusicTypes(9, "dance", "Dance music");
        public static readonly MusicTypes Unknown = new MusicTypes(10, "Unknown", "Unknown", false);
        protected MusicTypes(int id, string name):this(id, name, name, true)
        {
        }
        protected MusicTypes(int id, string name, string displayName): this(id, name, displayName, true)
        {
        }
        protected MusicTypes(int id, string name, string displayName, bool showInUI):base(id, name, displayName, showInUI)
        {
        }
        public MusicTypes()
        {
            Reviews = new List<MusicReview>();
        }

        public virtual IList<MusicReview> Reviews { get; private set; }
    }
}
