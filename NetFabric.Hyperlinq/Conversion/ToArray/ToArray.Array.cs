﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TSource[] ToArray<TSource>(this TSource[] source)
            => source.Clone() as TSource[];

        [Pure]
        static TSource[] ToArray<TSource>(this TSource[] source, int skipCount, int takeCount)
        {
            var array = new TSource[takeCount];
            System.Array.Copy(source, skipCount, array, 0, takeCount);
            return array;
        }
    }
}
