using DynamicSrotedArray;
using System;
using Xunit;

namespace Tests
{
    public class DynamicSortedArrayTests
    {
        [Fact]
        public void Indexer_InputsOutOfRangeIndexes_ThrowIndexOutOfRangeException()
        {
            //arrange
            DynamicSortedArray<int> arr = new DynamicSortedArray<int>();
            arr.Add(3, 1, 5, 8, 1, 3);
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
            DynamicSortedArray<int> arr = new DynamicSortedArray<int>();
            arr.Add(3, 1, 5, 8, 1, 6);
            //act & assert
            Assert.True(arr.Contains(value));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void Remove_CheckRemoveOfElements_ReturnTrue(int value)
        {
            //arrange
            DynamicSortedArray<int> arr = new DynamicSortedArray<int>();
            arr.Add(3, 1, 5, 8, 1, 6);
            //act & assert
            Assert.True(arr.Remove(value));
        }

        [Fact]
        public void Remove_ClarCollection_ReturnTrue()
        {
            //arrange
            DynamicSortedArray<int> arr = new DynamicSortedArray<int>();
            arr.Add(3, 1, 5, 8, 1, 3);
            //act
            arr.Clear();
            //assert
            Assert.True(arr.Count == 0);
        }

        [Fact]
        public void Indexer_CollectionContainsThisElements_ReturnTrue()
        {
            //arrange
            DynamicSortedArray<int> arr = new DynamicSortedArray<int>();
            arr.Add(3, 1, 5, 8, 1, 6);
            //act & assert
            Assert.True(1.Equals(arr[0]));
            Assert.True(3.Equals(arr[2]));
            Assert.True(8.Equals(arr[5]));
        }

        [Fact]
        public void CopyTo_ThrowDynamicSrotedArrayException()
        {
            //arrange
            DynamicSortedArray<int> arr = new DynamicSortedArray<int>();
            arr.Add(3, 1, 5, 8, 1, 6);
            //act & assert
            Assert.Throws<DynamicSrotedArrayException>(() => arr.CopyTo(new int[] { 4, 5 }, 5));
        }

        [Fact]
        public void Add_AddElementInTheBeginig_RetunTrue()
        {
            //arrange
            DynamicSortedArray<int> arr = new DynamicSortedArray<int>();
            arr.Add(1, 2, 3, 4);
            //act
            arr.Add(0);
            //assert
            Assert.True(0.Equals(arr[0]));
        }

        [Fact]
        public void Add_AddElementInTheEnd_RetunTrue()
        {
            //arrange
            DynamicSortedArray<int> arr = new DynamicSortedArray<int>();
            arr.Add(1, 2, 3, 4);
            //act
            arr.Add(5);
            //assert
            Assert.True(5.Equals(arr[4]));
        }

        [Fact]
        public void Add_AddElementInCenter_RetunTrue()
        {
            //arrange
            DynamicSortedArray<int> arr = new DynamicSortedArray<int>();
            arr.Add(1, 2, 3, 4);
            //act
            arr.Add(2);
            //assert
            Assert.True(2.Equals(arr[2]));
        }

        [Fact]
        public void Add_AddNullElement_ArgumentNullException()
        {
            //arrange
            DynamicSortedArray<string> arr = new DynamicSortedArray<string>();
            arr.Add("a", "b", "c");
            string s = null;
            //act & assert
            Assert.Throws<ArgumentNullException>(() => arr.Add(s));
        }

    }
}
