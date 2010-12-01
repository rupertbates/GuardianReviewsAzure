using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.OpenPlatform.Results.Entities;
using GuardianReviews.Domain.Model;

namespace GuardianReviews.OpenPlatform.ContentConverters
{
    public static class ReviewTypeExtensions
    {
        private static readonly Dictionary<string, ReviewTypes> _tagMap = new Dictionary<string, ReviewTypes> {
            {"books/books", ReviewTypes.Books},
            {"tv-and-radio/tv-and-radio", ReviewTypes.TvAndRadio}, 
            {"music/music", ReviewTypes.Music},
            {"technology/games", ReviewTypes.Game}, 
            {"film/film", ReviewTypes.Film}, 
            {"stage/theatre", ReviewTypes.Theatre}
        };
        private static readonly Dictionary<string, ReviewTypes> _sectionMap = new Dictionary<string, ReviewTypes> {
            {"books", ReviewTypes.Books},
            {"tv-and-radio", ReviewTypes.TvAndRadio},
            {"music", ReviewTypes.Music},
            {"technology", ReviewTypes.Game},
            {"film", ReviewTypes.Film}, 
            {"stage", ReviewTypes.Theatre}
        };
        
        public static ReviewTypes GetReviewType(this Content content)
        {
            var tagTypes = GetReviewTypesFromTag(content);
            //if no tags match then ignore it
            if (tagTypes.Count() == 0)
                return ReviewTypes.Unknown;
            //if there is a one to one match, pick that type
            if (tagTypes.Count() == 1)
                return tagTypes.First();
            //There is more than one matching tag, check the section
            var section = GetReviewTypeFromSection(content);

            //if the section matches with a tag, return that
            if (tagTypes.Contains(section))
                return section;

            //otherwise just return the first tag
            return tagTypes.First();

        }
        public static List<ReviewTypes> GetReviewTypesFromTag(this Content content)
        {
            if(content.Tags == null)
                return new List<ReviewTypes>();
            
            return _tagMap
                .Where(t => content.Tags.Contains(new Tag { Id = t.Key }))
                .Select(t => t.Value)
                .ToList();
        }
        public static ReviewTypes GetReviewTypeFromSection(this Content content)
        {
            var section = _sectionMap.Where(s => content.SectionId == s.Key);
            if (section.Count() == 0)
                return ReviewTypes.Unknown;

            return section.First().Value;
        }
    }
}
