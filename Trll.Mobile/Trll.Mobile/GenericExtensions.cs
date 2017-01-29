using System;

namespace Trll.Mobile
{
    public static class GenericExtensions
    {
        public static T Tap<T>(this T obj, Action<T> action)
        {
            action(obj);
            return obj;
        }
    }
}