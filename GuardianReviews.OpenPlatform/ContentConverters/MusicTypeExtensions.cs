using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform.Results.Entities;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.OpenPlatform.ContentConverters
{
    
    public static class MusicTypeExtensions
    {
        private static readonly Dictionary<string, MusicTypes> _tagMap = new Dictionary<string, MusicTypes>
                                                                             {
                                                                                 {"music/popandrock", MusicTypes.Pop},
                                                                                 {"music/urban", MusicTypes.Urban},
                                                                                 {"music/jazz", MusicTypes.Jazz},
                                                                                 {"music/worldmusic", MusicTypes.World},
                                                                                 {"music/folk", MusicTypes.Folk},
                                                                                 {"music/classicalmusicandopera",MusicTypes.Classical},
                                                                                 {"music/electronicmusic",MusicTypes.Electronic},
                                                                                 {"music/soul", MusicTypes.Soul},
                                                                                 {"music/dance-music",MusicTypes.DanceMusic},
                                                                             };
        public static IList<MusicTypes> GetMusicTypes(this Content content)
        {
            if(content.Tags == null)
                return new List<MusicTypes>();

            return _tagMap
                .Where(t => content.Tags.Contains(new Tag {Id = t.Key}))
                .Select(t => t.Value)
                .ToList();
        }
    }
}
