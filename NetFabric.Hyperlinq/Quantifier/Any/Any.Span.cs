using System;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this Span<TSource> source)
            => source.Length != 0;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
            => Any((ReadOnlySpan<TSource>)source, predicate);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any<TSource>(this Span<TSource> source, PredicateAt<TSource> predicate)
            => Any((ReadOnlySpan<TSource>)source, predicate);
    }
}

