﻿using System;
using System.Collections.Generic;

namespace Onnx.Collections
{
    /// <summary>Convenience extension methods for <see cref="IList{T}"/>.</summary>
    public static class ListExtensions
    {
        public static bool TryRemove<T, TSelect>(this IList<T> fields, Func<T, TSelect> select, Predicate<TSelect> predicate)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                var field = fields[i];
                var value = select(field);
                if (predicate(value))
                {
                    fields.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public static bool TryRemove<T, TSelect>(this IList<T> fields, Func<T, TSelect> select, TSelect valueToRemove)
            where TSelect : IEquatable<TSelect>
        {
            var index = fields.IndexOf(select, valueToRemove);
            if (index >= 0)
            {
                fields.RemoveAt(index);
                return true;
            }
            return false;
        }

        public static int IndexOf<T, TSelect>(this IList<T> fields, Func<T, TSelect> select, TSelect valueToFind)
            where TSelect : IEquatable<TSelect>
        {
            for (int i = 0; i < fields.Count; i++)
            {
                var field = fields[i];
                var value = select(field);
                if (value.Equals(valueToFind))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
