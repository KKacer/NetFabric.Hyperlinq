using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    public class ElementAtBenchmarks : BenchmarksBase
    {
        [BenchmarkCategory("Array")]
        [Benchmark(Baseline = true)]
        public int Linq_Array() =>
            System.Linq.Enumerable.ElementAt(array, Count - 1);

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Value() =>
            System.Linq.Enumerable.ElementAt(enumerableValue, Count - 1);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Value() =>
            System.Linq.Enumerable.ElementAt(collectionValue, Count - 1);

        [BenchmarkCategory("List_Value")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Value() =>
            System.Linq.Enumerable.ElementAt(listValue, Count - 1);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Enumerable_Reference() => 
            System.Linq.Enumerable.ElementAt(enumerableReference, Count - 1);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_Collection_Reference() =>
            System.Linq.Enumerable.ElementAt(collectionReference, Count - 1);

        [BenchmarkCategory("List_Reference")]
        [Benchmark(Baseline = true)]
        public int Linq_List_Reference() =>
            System.Linq.Enumerable.ElementAt(listReference, Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Array() =>
            array.ElementAt(Count - 1);

#if SPAN_SUPPORTED
        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Span() =>
            array.AsSpan().ElementAt(Count - 1);

        [BenchmarkCategory("Array")]
        [Benchmark]
        public Option<int> Hyperlinq_Memory() =>
            memory.ElementAt(Count - 1);
#endif

        [BenchmarkCategory("Enumerable_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_Enumerable_Value() =>
            EnumerableExtensions.AsValueEnumerable<TestEnumerable.Enumerable, TestEnumerable.Enumerable.Enumerator, int>(enumerableValue, enumerable => enumerable.GetEnumerator())
            .ElementAt(Count - 1);

        [BenchmarkCategory("Collection_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_Collection_Value() =>
            ReadOnlyCollectionExtensions.AsValueEnumerable<TestCollection.Enumerable, TestCollection.Enumerable.Enumerator, int>(collectionValue, enumerable => enumerable.GetEnumerator())
            .ElementAt(Count - 1);

        [BenchmarkCategory("List_Value")]
        [Benchmark]
        public Option<int> Hyperlinq_List_Value() =>
            ReadOnlyListExtensions.AsValueEnumerable<int>(listValue)
            .ElementAt(Count - 1);

        [BenchmarkCategory("Enumerable_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_Enumerable_Reference() =>
            enumerableReference
            .AsValueEnumerable()
            .ElementAt(Count - 1);

        [BenchmarkCategory("Collection_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_Collection_Reference() =>
            collectionReference
            .AsValueEnumerable()
            .ElementAt(Count - 1);

        [BenchmarkCategory("List_Reference")]
        [Benchmark]
        public Option<int> Hyperlinq_List_Reference() =>
            listReference
            .AsValueEnumerable()
            .ElementAt(Count - 1);
    }
}
