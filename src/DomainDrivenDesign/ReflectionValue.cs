using System;
using System.Linq;
using System.Reflection;

namespace Acidic.DomainDrivenDesign
{
    /// <summary>
    /// Represents a value object.
    /// 
    /// A value object is defined by its value(s) and not by a unique identifier.
    /// Two value object are considered equal, if their value properties contains
    /// the same values.
    /// </summary>
    /// <typeparam name="T">The type of the concrete value object class.</typeparam>
    public abstract class ReflectionValue<T> : IEquatable<T> where T : ReflectionValue<T>
    {
        /// <summary>
        /// An object array, containing references to all of the value object properties that should be used
        /// when comparing one value object to another.
        /// </summary>
        private readonly Lazy<object[]> _propertiesForEqualityCheck;

        protected ReflectionValue()
        {
            _propertiesForEqualityCheck = new Lazy<object[]>(() =>
            {
                return typeof(T)
                    .GetFields(BindingFlags.Instance| BindingFlags.NonPublic | BindingFlags.DeclaredOnly)
                    .Where(fieldInfo => fieldInfo.GetCustomAttribute(typeof(IgnoreValueAttribute)) == null)
                    .Select(fieldInfo => fieldInfo.GetValue(this))
                    .ToArray();
            });
        }

        /// <inheritdoc />
        public sealed override bool Equals(object other)
        {
            return Equals(other as T);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">The object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(T other)
        {
            if (other == null)
                return false;

            return _propertiesForEqualityCheck.Value.SequenceEqual(other._propertiesForEqualityCheck.Value);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            var hashCode = 352033288;

            foreach (var property in _propertiesForEqualityCheck.Value)
            {
                hashCode = hashCode * -1521134295 + property.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// Compares two object to check if they are equal.
        /// </summary>
        /// <param name="lhs">The first object to compare with.</param>
        /// <param name="rhs">The second object to compare with.</param>
        /// <returns>true if the two object are equal; otherwise, false.</returns>
        public static bool operator ==(ReflectionValue<T> lhs, ReflectionValue<T> rhs)
        {

            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares two object to check if they are not equal.
        /// </summary>
        /// <param name="lhs">The first object to compare with.</param>
        /// <param name="rhs">The second object to compare with.</param>
        /// <returns>false if the two object are equal; otherwise, true.</returns>
        public static bool operator !=(ReflectionValue<T> lhs, ReflectionValue<T> rhs) => !(lhs == rhs);

        /// <inheritdoc />
        public override string ToString()
        {
            if (_propertiesForEqualityCheck.Value.Length == 0)
            {
                return string.Empty;
            }

            if (_propertiesForEqualityCheck.Value.Length == 1)
            {
                return _propertiesForEqualityCheck.Value.First().ToString();
            }

            return string.Join(" - ", _propertiesForEqualityCheck.Value.Select(property => property.ToString()));
        }
    }
}