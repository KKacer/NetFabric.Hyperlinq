using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class RangeTests
    {
        [Theory]
        [InlineData(-1)]
        public void Range_With_NegativeCount_Should_Throw(long count)
        {
            // Arrange

            // Act
            Action action = () => Enumerable.Range(0, count);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentOutOfRangeException>()
                .And
                .ParamName.Should()
                    .Be("count");
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, -1)]
        public void Indexer_With_IndexOutOfRange_Should_Throw(long count, long index)
        {
            // Arrange

            // Act
            Func<long> action = () => Enumerable.Range(0, count)[index];

            // Assert
            action.Should().ThrowExactly<IndexOutOfRangeException>();
        }
  
        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_With_ValidData_Should_Succeed(long start, long count, long[] expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count);

            // Assert
            result.Should().Generate(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.RangeSkip), MemberType = typeof(TestData))]
        public void Range_With_Skip_Should_Succeed(long start, long count, long skipCount, long[] expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count).Skip(skipCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.RangeTake), MemberType = typeof(TestData))]
        public void Range_With_Take_Should_Succeed(long start, long count, long takeCount, long[] expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count).Take(takeCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.RangeSkipTake), MemberType = typeof(TestData))]
        public void Range_With_SkipTake_Should_Succeed(long start, long count, long skipCount, long takeCount, long[] expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count).Skip(skipCount).Take(takeCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
  
        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_With_ToArray_Should_Succeed(long start, long count, long[] expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count).ToArray();

            // Assert
            result.AsEnumerable().Should().Equal(expected as long[]);
        }
  
        [Theory]
        [MemberData(nameof(TestData.Range), MemberType = typeof(TestData))]
        public void Range_With_ToList_Should_Succeed(long start, long count, long[] expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Range(start, count).ToList();

            // Assert
            result.AsEnumerable().Should().Equal(new List<long>(expected));
        }
    }
}