using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GuardianReviews.Domain.Enumerations
{
    public enum MusicTypes
    {
        [Description("Classical music and opera")]
        Classical,
        [Description("Electronic music")]
        Electronic,
        Jazz,
        [Description("Folk music")]
        Folk,
        [Description("Pop and rock")]
        Pop,
        [Description("Urban music")]
        Urban,
        [Description("World music")]
        World
    }
}
