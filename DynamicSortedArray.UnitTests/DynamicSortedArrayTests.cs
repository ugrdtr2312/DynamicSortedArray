using System;
using Xunit;

namespace DynamicSortedArray.UnitTests
{
    public class DynamicSortedArrayTests
    {
        [Fact]
        public void Indexer_InputsOutOfRangeIndexes_ThrowIndexOutOfRangeException()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { 3, 1, 5, 8, 1, 3 };
            //act & assert
            Assert.Throws<IndexOutOfRangeException>(() => arr[6]);
            Assert.Throws<IndexOutOfRangeException>(() => arr[-1]);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void Contains_CheckContainsOfElements_ReturnTrue(int value)
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 3, 1, 5, 8, 1, 6 } };
            //act
            var contains = arr.Contains(value);
            //assert
            Assert.True(contains);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void Remove_CheckRemoveOfElements_ReturnTrue(int value)
        {
            //arrange
            DynamicSortedArray<int> arr = new DynamicSortedArray<int> { { 3, 1, 5, 8, 1, 6 } };
            //act & assert
            Assert.True(arr.Remove(value));
        }

        [Fact]
        public void Remove_ClearCollection_ReturnTrue()
        {
            //arrange
            DynamicSortedArray<int> arr = new DynamicSortedArray<int> { { 3, 1, 5, 8, 1, 3 } };
            //act
            arr.Clear();
            //assert
            Assert.True(arr.Count == 0);
        }

        [Fact]
        public void Indexer_CollectionContainsThisElements_ReturnTrue()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 3, 1, 5, 8, 1, 6 } };
            //act & assert
            Assert.True(1.Equals(arr[0]));
            Assert.True(3.Equals(arr[2]));
            Assert.True(8.Equals(arr[5]));
        }

        [Fact]
        public void CopyTo_ThrowDynamicSortedArrayException()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { {3, 1, 5, 8, 1, 6} };
            //act & assert
            Assert.Throws<DynamicSortedArrayException>(() => arr.CopyTo(new[] { 4, 5 }, 5));
        }

        [Fact]
        public void Add_AddElementInTheBeginning_ReturnTrue()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { 1, 2, 3, 4, 0 };
            //act
            //assert
            Assert.True(0.Equals(arr[0]));
        }

        [Fact]
        public void Add_AddElementInTheEnd_ReturnTrue()
        {
            //arrange
            var arr = new DynamicSortedArray<int> {{1, 2, 3, 4}, 5};
            //act
            //assert
            Assert.True(5.Equals(arr[4]));
        }

        [Fact]
        public void Add_AddElementInCenter_ReturnTrue()
        {
            //arrange
            var arr = new DynamicSortedArray<int> {{1, 2, 3, 4}, 2};
            //act
            //assert
            Assert.True(2.Equals(arr[2]));
        }

        [Fact]
        public void Add_AddNullElement_ArgumentNullException()
        {
            //arrange
            var arr = new DynamicSortedArray<string> {{"a", "b", "c"}};
            //act & assert
            Assert.Throws<ArgumentNullException>(() => arr.Add((string) null));
        }

    }
}

