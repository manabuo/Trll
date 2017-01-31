using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Trll.Core
{
    public static class GenericExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var obj in enumerable)
                action(obj);
        }

        public static T Tap<T>(this T obj, Action<T> action)
        {
            action(obj);
            return obj;
        }

        public static TTarget Then<TSource, TTarget>(this TSource source, Func<TSource, TTarget> func) => func(source);

        public static async Task<TTarget> ThenAsync<TSource, TTarget>(
            this Task<TSource> source,
            Func<TSource, TTarget> func) =>
            func(await source);
    }
}