using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IslandExtractor
{
    public abstract class Enumeration : IComparable
    {
        protected Enumeration()
        {
        }

        protected Enumeration(Int32 value, String name)
        {
            Value = value;
            Name = name;
        }

        public Int32 Value { get; protected set; }

        public String Name { get; protected set; }

        public override String ToString()
        {
            return Name;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();

                if (info.GetValue(instance) is T locatedValue)
                {
                    yield return locatedValue;
                }
            }
        }

        public override Boolean Equals(Object obj)
        {
            if (!(obj is Enumeration otherValue))
            {
                return false;
            }

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override Int32 GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static Int32 AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
            return absoluteDifference;
        }

        public static T FromValue<T>(Int32 value) where T : Enumeration, new()
        {
            var matchingItem = Parse<T, Int32>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static T FromDisplayName<T>(String displayName) where T : Enumeration, new()
        {
            var matchingItem = Parse<T, String>(displayName, "display name", item => item.Name == displayName);
            return matchingItem;
        }

        private static T Parse<T, TK>(TK value, String description, Func<T, Boolean> predicate)
            where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem != null) return matchingItem;

            var message = $"'{value}' is not a valid {description} in {typeof(T)}";
            throw new ApplicationException(message);

        }

        public Int32 CompareTo(Object other)
        {
            return Value.CompareTo(((Enumeration)other).Value);
        }
    }
}
