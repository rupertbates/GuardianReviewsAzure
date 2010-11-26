//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace GuardianReviews.Domain
{
    public partial class MusicType
    {
        #region Primitive Properties
    
        public virtual string Id
        {
            get;
            set;
        }
    
        public virtual string Description
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Review> Reviews
        {
            get
            {
                if (_reviews == null)
                {
                    var newCollection = new FixupCollection<Review>();
                    newCollection.CollectionChanged += FixupReviews;
                    _reviews = newCollection;
                }
                return _reviews;
            }
            set
            {
                if (!ReferenceEquals(_reviews, value))
                {
                    var previousValue = _reviews as FixupCollection<Review>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupReviews;
                    }
                    _reviews = value;
                    var newValue = value as FixupCollection<Review>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupReviews;
                    }
                }
            }
        }
        private ICollection<Review> _reviews;

        #endregion
        #region Association Fixup
    
        private void FixupReviews(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Review item in e.NewItems)
                {
                    if (!item.MusicTypes.Contains(this))
                    {
                        item.MusicTypes.Add(this);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Review item in e.OldItems)
                {
                    if (item.MusicTypes.Contains(this))
                    {
                        item.MusicTypes.Remove(this);
                    }
                }
            }
        }

        #endregion
    }
}