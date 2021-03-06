using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Contains<TSource>(this Memory<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = null)
            => Contains((ReadOnlySpan<TSource>)source.Span, value, comparer);
    }
}

