using System;
using Xunit;

namespace DynamicSortedArray.UnitTests
{
    public class DynamicSortedArrayTests
    {
        [Theory,
         InlineData(-1), InlineData(6)]
        public void Indexer_InputOutOfRangeIndexes_ThrowIndexOutOfRangeException(int value)
        {
            //arrange
            var arr = new DynamicSortedArray<int> { {3, 1, 5, 8, 1, 3} };
            //act & assert
            Assert.Throws<IndexOutOfRangeException>(() => arr[value]);
        }

        [Theory,
         InlineData(0, 1), InlineData(2, 3), InlineData(5, 8)]
        public void Indexer_ArrayContainsThisElementsUnderIndex_ReturnNothing(int index, int expectedValue)
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 3, 1, 5, 8, 1, 6 } };
            //act
            var actual = arr[index];
            //assert
            Assert.Equal(actual, expectedValue);
        }

        [Fact]
        public void Add_CheckThatEventRaisedWhenAddingInBeginningOfArray_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int> {{2, 2, 5, 8, 1, 6}};
            //act
            var receivedEvent = Assert.Raises<AddToArrayEventArgs<int>>(
                a => arr.Added += a,
                a => arr.Added -= a,
                () => { arr.Add(0); });
            //assert
            Assert.NotNull(receivedEvent);

            Assert.Equal(0, receivedEvent.Arguments.AddedItem);
            Assert.Equal("0 added in head", receivedEvent.Arguments.Message);
        }

        [Fact]
        public void Add_CheckThatEventRaisedWhenAddingFirstElementToArray_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int>();
            //act
            var receivedEvent = Assert.Raises<AddToArrayEventArgs<int>>(
                a => arr.Added += a,
                a => arr.Added -= a,
                () => { arr.Add(0); });
            //assert
            Assert.NotNull(receivedEvent);

            Assert.Equal(0, receivedEvent.Arguments.AddedItem);
            Assert.Equal("0 added first element", receivedEvent.Arguments.Message);
        }

        [Fact]
        public void Add_CheckThatEventRaisedWhenAddingInEndOfArray_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 2, 2, 5, 8, 1, 6 } };
            //act
            var receivedEvent = Assert.Raises<AddToArrayEventArgs<int>>(
                a => arr.Added += a,
                a => arr.Added -= a,
                () => { arr.Add(14); });
            //assert
            Assert.NotNull(receivedEvent);

            Assert.Equal(14, receivedEvent.Arguments.AddedItem);
            Assert.Equal("14 added in tail", receivedEvent.Arguments.Message);
        }

        [Fact]
        public void Add_CheckThatEventRaisedWhenAddingElementInCenterOfArray_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 2, 2, 5, 8, 1, 6 } };
            //act
            var receivedEvent = Assert.Raises<AddToArrayEventArgs<int>>(
                a => arr.Added += a,
                a => arr.Added -= a,
                () => { arr.Add(4); });
            //assert
            Assert.NotNull(receivedEvent);

            Assert.Equal(4, receivedEvent.Arguments.AddedItem);
            Assert.Equal("4 added", receivedEvent.Arguments.Message);
        }

        [Fact]
        public void Add_AddElementInTheBeginning_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 1, 2, 3, 4 } };
            var addingValue = 0;
            var expectedPosition = 0;
            //act
            arr.Add(addingValue);
            //assert
            Assert.Equal(addingValue, arr[expectedPosition]);
        }

        [Fact]
        public void Add_AddElementInTheEnd_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 1, 2, 3, 4 } };
            var addingValue = 5;
            var expectedPosition = 4;
            //act
            arr.Add(addingValue);
            //assert
            Assert.Equal(addingValue, arr[expectedPosition]);
        }

        [Fact]
        public void Add_AddElementInCenter_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 1, 2, 4 } };
            var addingValue = 3;
            var expectedPosition = 2;
            //act
            arr.Add(addingValue);
            //assert
            Assert.Equal(addingValue, arr[expectedPosition]);
        }

        [Fact]
        public void Add_AddNullElement_ThrowsArgumentNullException()
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
        public void Contains_CheckContainsWhenArrayIsEmpty_ReturnFalse(int value)
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

        [Theory,
         InlineData(18), InlineData(57), InlineData(-8)]
        public void Remove_CheckRemoveOfElementsFromEmptyArray_ReturnFalse(int value)
        {
            //arrange
            var arr = new DynamicSortedArray<int>();
            //act & assert
            Assert.False(arr.Remove(value));
        }

        [Fact]
        public void Remove_CheckThatEventRaisedWhenDeletingElementFromArray_ReturnNothing()
        {
            //arrange
            var arr = new DynamicSortedArray<int> { { 2, 2, 5, 8, 1, 6 } };
            var itemToRemove = 1;
            //act 
            var receivedEvent = Assert.Raises<RemoveFromArrayEventArgs<int>>(
                a => arr.Removed += a,
                a => arr.Removed -= a,
                () => { arr.Remove(itemToRemove); });
            //assert
            Assert.NotNull(receivedEvent);

            Assert.Equal(itemToRemove, receivedEvent.Arguments.RemovedItem);
            Assert.Equal($"{itemToRemove} was removed", receivedEvent.Arguments.Message);
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
            var arrayToAdd = new[] {4, 5};
            var positionToAdd = 5;
            //act & assert
            Assert.Throws<DynamicSortedArrayException>(() => arr.CopyTo(arrayToAdd, positionToAdd));
        }

        [Fact]
        public void GetEnumerator_CheckWithOriginEnumerator_DoNotThrowException()
        {
            //arrange
            var arr = new DynamicSortedArray<int> {{1, 2, 3, 4}};
            var counter = 0;
            //act
            foreach (var element in arr)
            {
                if (element != arr[counter])
                    throw new DynamicSortedArrayException($"{element} and {arr[counter]} are not equal");
                counter++;
            }
        }
    }
}

