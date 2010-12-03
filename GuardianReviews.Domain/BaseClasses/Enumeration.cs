using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SharpArch.Core.DomainModel;

namespace GuardianReviews.Domain.BaseClasses
{
    public abstract class Enumeration : Entity, IComparable
    {
        protected Enumeration()
        {
        }
        protected Enumeration(int id, string name):this(id, name, name, true)
        {
        }
        protected Enumeration(int id, string name, string displayName, bool showInUI)
        {
            Id = id;
            Name = name;
            DisplayName = displayName;
            ShowInUI = showInUI;
        }

            
        //public virtual int Id { get; set; }
        public virtual bool ShowInUI { get; set; }
        public virtual string Name { get; set; }
        public virtual string DisplayName { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public static bool operator ==(Enumeration a, Enumeration b)
        {
            return a.Id == b.Id;
        }

        public static bool operator !=(Enumeration a, Enumeration b)
        {
            return !(a == b);
        }


        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
            return absoluteDifference;
        }

        public static T FromValue<T>(int value) where T : Enumeration, new()
        {
            var matchingItem = parse<T, int>(value, "id", item => item.Id == value);
            return matchingItem;
        }

        public static T FromName<T>(string name) where T : Enumeration, new()
        {
            name = name.ToLower();
            var matchingItem = parse<T, string>(name, "name", item => item.Name.ToLower() == name);
            return matchingItem;
        }

        private static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public virtual int CompareTo(object other)
        {
            return Id.CompareTo(((Enumeration)other).Id);
        }
    }

}
