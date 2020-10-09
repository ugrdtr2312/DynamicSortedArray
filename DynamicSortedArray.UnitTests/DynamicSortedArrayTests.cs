using System;
using Xunit;

namespace DynamicSortedArray.UnitTests
{
    public class DynamicSortedArrayTests
    {
        [Theory,
         InlineData(-1), InlineData(6)]
        public void Indexer_InputsOutOfRangeIndexes_ThrowIndexOutOfRangeException(int value)
        {
            //arrange
            var arr = new DynamicSortedArray<int> { {3, 1, 5, 8, 1, 3} };
            //act & assert
            Assert.Throws<IndexOutOfRangeException>(() => arr[value]);
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
        public void Add_CheckThatEventRaisedWhenAddingInBeginningOfArray_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 2, 2, 5, 8, 1, 6 } };
            //act & assert
            var receivedEvent = Assert.Raises<AddToArrayEventArgs<int>>(
                a => arr.Added += a,
                a => arr.Added -= a,
                () => { arr.Add(0); });

            Assert.NotNull(receivedEvent);

            Assert.Equal(0, receivedEvent.Arguments.AddedItem);
            Assert.Equal("0 added in head", receivedEvent.Arguments.Message);
        }

        [Fact]
        public void Add_CheckThatEventRaisedWhenAddingFirstElementOfArray_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int>();
            //act & assert
            var receivedEvent = Assert.Raises<AddToArrayEventArgs<int>>(
                a => arr.Added += a,
                a => arr.Added -= a,
                () => { arr.Add(0); });

            Assert.NotNull(receivedEvent);

            Assert.Equal(0, receivedEvent.Arguments.AddedItem);
            Assert.Equal("0 added first element", receivedEvent.Arguments.Message);
        }

        [Fact]
        public void Add_CheckThatEventRaisedWhenAddingInEndOfArray_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 2, 2, 5, 8, 1, 6 } };
            //act & assert
            var receivedEvent = Assert.Raises<AddToArrayEventArgs<int>>(
                a => arr.Added += a,
                a => arr.Added -= a,
                () => { arr.Add(14); });

            Assert.NotNull(receivedEvent);

            Assert.Equal(14, receivedEvent.Arguments.AddedItem);
            Assert.Equal("14 added in tail", receivedEvent.Arguments.Message);
        }

        [Fact]
        public void Add_CheckThatEventRaisedWhenAddingElementInCenterOfArray_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 2, 2, 5, 8, 1, 6 } };
            //act & assert
            var receivedEvent = Assert.Raises<AddToArrayEventArgs<int>>(
                a => arr.Added += a,
                a => arr.Added -= a,
                () => { arr.Add(4); });

            Assert.NotNull(receivedEvent);

            Assert.Equal(4, receivedEvent.Arguments.AddedItem);
            Assert.Equal("4 added", receivedEvent.Arguments.Message);
        }

        [Fact]
        public void Add_AddElementInTheBeginning_ReturnTrue()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 1, 2, 3, 4 } };
            //act
            arr.Add(0);
            //assert
            Assert.True(0.Equals(arr[0]));
        }

        [Fact]
        public void Add_AddElementInTheEnd_ReturnTrue()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 1, 2, 3, 4 } };
            //act
            arr.Add(5);
            //assert
            Assert.True(5.Equals(arr[4]));
        }

        [Fact]
        public void Add_AddElementInCenter_ReturnTrue()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 1, 2, 3, 4 } };
            //act
            arr.Add(3);
            //assert
            Assert.True(3.Equals(arr[2]));
        }

        [Fact]
        public void Add_AddNullElement_ArgumentNullException()
        {
            //arrange
            var arr = new DynamicSortedArray<string> { { "a", "b", "c" } };
            //act & assert
            Assert.Throws<ArgumentNullException>(() => arr.Add((string)null));
        }

        [Theory,
         InlineData(3), InlineData(5), InlineData(6)]
        public void Contains_CheckContainsOfElementsThatAreInCollection_ReturnTrue(int value)
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 3, 1, 5, 8, 1, 6 } };
            //act
            var contains = arr.Contains(value);
            //assert
            Assert.True(contains);
        }

        [Theory,
         InlineData(-1), InlineData(0), InlineData(16)]
        public void Contains_CheckContainsOfElementsThatAreNotInCollection_ReturnFalse(int value)
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 3, 1, 5, 8, 1, 6 } };
            //act
            var contains = arr.Contains(value);
            //assert
            Assert.False(contains);
        }

        [Theory,
         InlineData(3), InlineData(5), InlineData(6)]
        public void Contains_CheckContainsWhenArrayEmpty_ReturnFalse(int value)
        {
            //arrange
            var arr = new DynamicSortedArray<int>();
            //act
            var contains = arr.Contains(value);
            //assert
            Assert.False(contains);
        }

        [Theory,
         InlineData(1), InlineData(5), InlineData(8)]
        public void Remove_CheckRemoveOfElementsThatAreInCollection_ReturnTrue(int value)
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 3, 1, 5, 8, 1, 6 } };
            //act & assert
            Assert.True(arr.Remove(value));
        }

        [Theory,
         InlineData(18), InlineData(57), InlineData(-8)]
        public void Remove_CheckRemoveOfElementsThatAreNotInArray_ReturnFalse(int value)
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 3, 1, 5, 8, 1, 6 } };
            //act & assert
            Assert.False(arr.Remove(value));
        }

        [Fact]
        public void Remove_CheckRemoveOfElementsFromEmptyArray_ReturnFalse()
        {
            //arrange
            var arr = new DynamicSortedArray<int>();
            //act & assert
            Assert.False(arr.Remove(8));
        }

        [Fact]
        public void Remove_CheckThatEventRaisedWhenDeletingElementFromArray_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 2, 2, 5, 8, 1, 6 } };
            //act & assert
            var receivedEvent = Assert.Raises<RemoveFromArrayEventArgs<int>>(
                a => arr.Removed += a,
                a => arr.Removed -= a,
                () => { arr.Remove(1); });

            Assert.NotNull(receivedEvent);

            Assert.Equal(1, receivedEvent.Arguments.RemovedItem);
            Assert.Equal("1 was removed", receivedEvent.Arguments.Message);
        }

        [Fact]
        public void Clear_ClearCollection_ReturnTrue()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 3, 1, 5, 8, 1, 3 } };
            //act
            arr.Clear();
            //assert
            Assert.True(arr.Count == 0);
        }

        [Fact]
        public void CopyTo_AddElementsFromPosition_ThrowDynamicSortedArrayException()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 2, 2, 5, 8, 1, 6 } };
            //act & assert
            Assert.Throws<DynamicSortedArrayException>(() => arr.CopyTo(new[] { 4, 5 }, 5));
        }

        [Fact]
        public void GetEnumerator_CheckWithOriginEnumerator_NothingReturn()
        {
            //arrange
            var arr = new DynamicSortedArray<int> {{1, 2, 3, 4}};
            //act
            var counter = 0;
            foreach (var element in arr)
            {
                if (element != arr[counter])
                    throw new DynamicSortedArrayException($"{element} and {arr[counter]} are not equal");
                counter++;
            }
        }
    }
}

