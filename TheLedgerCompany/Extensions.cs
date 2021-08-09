using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLedgerCompany
{
    public static class Extensions
    {
        public static void EnsureNotNull<T>(this T target, string name)
        {
            if (target == null)
            {
                throw new ArgumentNullException(name, $"{ name } cannot be null");
            }
        }

        public static void EnsureNotNullOrEmpty(this string target, string name)
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                throw new ArgumentException($"{name} cannot be null or empty");
            }
        }

        public static void EnsureCollectionNotNullOrEmpty<T>(this IEnumerable<T> collection, string name)
        {
            if (collection == null || collection.Any() == false)
            {
                throw new ArgumentException($"{name} should have at least one item");
            }
        }

    }
}
