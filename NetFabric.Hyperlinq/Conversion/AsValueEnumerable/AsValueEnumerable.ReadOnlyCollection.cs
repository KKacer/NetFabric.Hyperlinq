﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollectionExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableWrapper<TSource> AsValueEnumerable<TSource>(this IReadOnlyCollection<TSource> source)
            => new ValueEnumerableWrapper<TSource>(source);

        [GeneratorIgnore]
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource> AsValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
            => new ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>(source, getEnumerator);

        public readonly partial struct ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>
            : IValueReadOnlyCollection<TSource, TEnumerator>
            , ICollection<TSource>
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;
            readonly Func<TEnumerable, TEnumerator> getEnumerator;

            internal ValueEnumerableWrapper(TEnumerable source, Func<TEnumerable, TEnumerator> getEnumerator)
            {
                this.source = source;
                this.getEnumerator = getEnumerator;
            }

            public readonly int Count
                => source.Count;
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly TEnumerator GetEnumerator() => getEnumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => getEnumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => getEnumerator(source);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(TSource[] array, int arrayIndex) 
            {
                if (source.Count == 0)
                    return;

                if (source is ICollection<TSource> collection)
                {
                    collection.CopyTo(array, arrayIndex);
                }
                else
                {
                    checked
                    {
                        using var enumerator = source.GetEnumerator();
                        for (var index = arrayIndex; enumerator.MoveNext(); index++)
                            array[index] = enumerator.Current;
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            bool ICollection<TSource>.Contains(TSource item)
                => Contains(item);

            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            public bool Contains([MaybeNull] TSource value, IEqualityComparer<TSource>? comparer = default)
            {
                if (source.Count == 0)
                    return false;

                if (comparer is null || ReferenceEquals(comparer, EqualityComparer<TSource>.Default))
                {
                    if (source is ICollection<TSource> collection)
                        return collection.Contains(value!);

                    if (default(TSource) is object)
                        return DefaultContains(this, value);
                }

                comparer ??= EqualityComparer<TSource>.Default;
                return ComparerContains(this, value, comparer);

                static bool DefaultContains(ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource> source, [AllowNull] TSource value)
                {
                    using var enumerator = source.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value!))
                            return true;
                    }
                    return false;
                }

                static bool ComparerContains(ValueEnumerableWrapper<TEnumerable, TEnumerator, TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource> comparer)
                {
                    using var enumerator = source.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if (comparer.Equals(enumerator.Current, value!))
                            return true;
                    }
                    return false;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyCollectionExtensions.ToArray(source);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyCollectionExtensions.ToList(source);
        }

        public readonly partial struct ValueEnumerableWrapper<TSource>
            : IValueReadOnlyCollection<TSource, ValueEnumerableWrapper<TSource>.Enumerator>
            , ICollection<TSource>
        {
            readonly IReadOnlyCollection<TSource> source;

            internal ValueEnumerableWrapper(IReadOnlyCollection<TSource> source) 
                => this.source = source;

            public readonly int Count
                => source.Count;

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly Enumerator GetEnumerator() => new Enumerator(source);
            readonly IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => new Enumerator(source);
            readonly IEnumerator IEnumerable.GetEnumerator() => new Enumerator(source);

            bool ICollection<TSource>.IsReadOnly  
                => true;

            public void CopyTo(TSource[] array, int arrayIndex) 
            {
                if (source.Count == 0)
                    return;

                if (source is ICollection<TSource> collection)
                {
                    collection.CopyTo(array, arrayIndex);
                }
                else
                {
                    checked
                    {
                        using var enumerator = source.GetEnumerator();
                        for (var index = arrayIndex; enumerator.MoveNext(); index++)
                            array[index] = enumerator.Current;
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            bool ICollection<TSource>.Contains(TSource item)
                => Contains(item);

            void ICollection<TSource>.Add(TSource item) 
                => Throw.NotSupportedException();
            void ICollection<TSource>.Clear() 
                => Throw.NotSupportedException();
            bool ICollection<TSource>.Remove(TSource item) 
                => Throw.NotSupportedException<bool>();

            public readonly struct Enumerator
                : IEnumerator<TSource>
            {
                readonly IEnumerator<TSource> enumerator;

                internal Enumerator(IReadOnlyCollection<TSource> enumerable) 
                    => enumerator = enumerable.GetEnumerator();

                [MaybeNull]
                public readonly TSource Current 
                    => enumerator.Current;
                readonly TSource IEnumerator<TSource>.Current
                    => enumerator.Current;
                readonly object? IEnumerator.Current
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly bool MoveNext() 
                    => enumerator.MoveNext();

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                [ExcludeFromCodeCoverage]
                public readonly void Reset() 
                    => enumerator.Reset();

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public readonly void Dispose() 
                    => enumerator.Dispose();
            }

            public bool Contains([MaybeNull] TSource value, IEqualityComparer<TSource>? comparer = default)
            {
                if (source.Count == 0)
                    return false;

                if (comparer is null || ReferenceEquals(comparer, EqualityComparer<TSource>.Default))
                {
                    if (source is ICollection<TSource> collection)
                        return collection.Contains(value!);

                    if (default(TSource) is object)
                        return DefaultContains(this, value);
                }

                comparer ??= EqualityComparer<TSource>.Default;
                return ComparerContains(this, value, comparer);

                static bool DefaultContains(ValueEnumerableWrapper<TSource> source, [AllowNull] TSource value)
                {
                    using var enumerator = source.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value!))
                            return true;
                    }
                    return false;
                }

                static bool ComparerContains(ValueEnumerableWrapper<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource> comparer)
                {
                    using var enumerator = source.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if (comparer.Equals(enumerator.Current, value!))
                            return true;
                    }
                    return false;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public TSource[] ToArray()
                => ReadOnlyCollectionExtensions.ToArray(source);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public List<TSource> ToList()
                => ReadOnlyCollectionExtensions.ToList(source);
        }

        public static int Count<TSource>(this ValueEnumerableWrapper<TSource> source)
            => source.Count;
    }
}