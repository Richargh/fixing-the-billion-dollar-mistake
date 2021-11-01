using System;
using System.Collections.Generic;

namespace Richargh.BillionDollar.Classic.Common.Lang
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> WhereNotNull<TSource>(
            this IEnumerable<TSource?> source)
        {
            // not the most efficient or smart implementation
            var nonNullEntities = new List<TSource>();
            foreach (var entity in source)
            {
                if (entity != null)
                {
                    nonNullEntities.Add(entity);
                }
            }

            return nonNullEntities;
        }
    }
}