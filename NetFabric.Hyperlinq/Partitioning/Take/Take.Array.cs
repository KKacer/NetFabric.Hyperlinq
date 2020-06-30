﻿using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
#if SPAN_SUPPORTED

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Memory<TSource> Take<TSource>(this TSource[] source, int count)
            => Take(source.AsMemory(), count);

#else

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegment<TSource> Take<TSource>(this TSource[] source, int count)
            => new ArraySegment<TSource>(source, 0, Utils.Take(source.Length, count));

#endif

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ArraySegment<TSource> Take<TSource>(this in ArraySegment<TSource> source, int count)
            => new ArraySegment<TSource>(source.Array, 0, Utils.Take(source.Count, count));
    }
}
