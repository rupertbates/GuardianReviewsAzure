using System.Collections.Generic;
using System.ComponentModel;
using GuardianReviews.Domain.BaseClasses;

namespace GuardianReviews.Domain.Model
{
    public class MusicTypes : Enumeration
    {

        public static readonly MusicTypes
            Classical = new MusicTypes(1, "classical", "Classical music and opera"),
            Electronic = new MusicTypes(2, "electronic", "Electronic music"),
            Jazz = new MusicTypes(3, "Jazz"),
            Folk = new MusicTypes(4, "Folk"),
            Pop = new MusicTypes(5, "popandrock", "Pop and Rock"),
            Urban = new MusicTypes(6, "urban", "Urban music"),
            World = new MusicTypes(7, "world", "World music"),
            Soul = new MusicTypes(8, "Soul"),
            DanceMusic = new MusicTypes(9, "dance", "Dance music"),
            Unknown = new MusicTypes(10, "Unknown", "Unknown", false);
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
