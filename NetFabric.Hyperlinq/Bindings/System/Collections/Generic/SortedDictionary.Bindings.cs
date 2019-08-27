using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static class SortedDictionaryBindings
    {
        [Pure]
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Count;
        [Pure]
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Skip<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        [Pure]
        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Take<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), count);

        [Pure]
        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static bool All<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Count != 0;
        [Pure]
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static bool Any<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value)
            => source.Contains(value);

        [Pure]
        public static bool Contains<TKey, TValue>(this SortedDictionary<TKey, TValue> source, KeyValuePair<TKey, TValue> value, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), value, comparer);

        [Pure]
        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);
        [Pure]
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [Pure]
        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TKey, TValue, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, TSubEnumerable> selector)
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TKey, TValue>(source), selector);

        [Pure]
        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static KeyValuePair<TKey, TValue> ElementAt<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int index)
            => ValueReadOnlyCollection.ElementAt<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), index);
        [Pure]
        public static KeyValuePair<TKey, TValue> ElementAtOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int index)
            => ValueReadOnlyCollection.ElementAtOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), index);
        [Pure]
        public static Maybe<KeyValuePair<TKey, TValue>> TryElementAt<TKey, TValue>(this SortedDictionary<TKey, TValue> source, int index)
            => ValueReadOnlyCollection.TryElementAt<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), index);

        [Pure]
        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static Maybe<KeyValuePair<TKey, TValue>> TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static Maybe<KeyValuePair<TKey, TValue>> TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static MaybeAt<KeyValuePair<TKey, TValue>> TryFirst<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);
        [Pure]
        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));
        [Pure]
        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), predicate);

        [Pure]
        public static ValueEnumerable.DistinctEnumerable<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Distinct<TKey, TValue>(this SortedDictionary<TKey, TValue> source, IEqualityComparer<KeyValuePair<TKey, TValue>> comparer = null)
            => ValueEnumerable.Distinct<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source), comparer);

        [Pure]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SortedDictionary<TKey, TValue> AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source;

        [Pure]
        public static ValueWrapper<TKey, TValue> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => new ValueWrapper<TKey, TValue>(source);

        [Pure]
        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        [Pure]
        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(new ValueWrapper<TKey, TValue>(source));

        [Pure]
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey, TValue>(new ValueWrapper<TKey, TValue>(source), (item => item.Key), (item => item.Value));
        [Pure]
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this SortedDictionary<TKey, TValue> source, IEqualityComparer<TKey> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey, TValue>(new ValueWrapper<TKey, TValue>(source), (item => item.Key), (item => item.Value), comparer);
        [Pure]
        public static Dictionary<TKey2, KeyValuePair<TKey, TValue>> ToDictionary<TKey, TValue, TKey2>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, TKey2> keySelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector);
        [Pure]
        public static Dictionary<TKey2, KeyValuePair<TKey, TValue>> ToDictionary<TKey, TValue, TKey2>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, TKey2> keySelector, IEqualityComparer<TKey2> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2>(new ValueWrapper<TKey, TValue>(source), keySelector, comparer);
        [Pure]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, TKey2> keySelector, Func<KeyValuePair<TKey, TValue>, TElement> elementSelector)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector);
        [Pure]
        public static Dictionary<TKey2, TElement> ToDictionary<TKey, TValue, TKey2, TElement>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, TKey2> keySelector, Func<KeyValuePair<TKey, TValue>, TElement> elementSelector, IEqualityComparer<TKey2> comparer)
            => ValueReadOnlyCollection.ToDictionary<ValueWrapper<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TKey2, TElement>(new ValueWrapper<TKey, TValue>(source), keySelector, elementSelector, comparer);

        public readonly struct ValueWrapper<TKey, TValue>
            : IValueReadOnlyCollection<KeyValuePair<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator>
        {
            readonly SortedDictionary<TKey, TValue> source;

            public ValueWrapper(SortedDictionary<TKey, TValue> source)
            {
                this.source = source;
            }

            public readonly int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => source.Count;
            }

            [Pure]
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly SortedDictionary<TKey, TValue>.Enumerator GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => source.GetEnumerator();
            readonly IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }
    }
}