using System;
using Xunit;

namespace DynamicSortedArray.UnitTests.MyArrayTestsAbstractions
{
    public abstract class MyArrayTests<T> where T : IComparable
    {
        [Fact]
        public void Add_AddElementInTheBeginning_ReturnNothing()
        {
            //arrange
            var myArr = Array();
            const int expectedPosition = 0;
            //act
            myArr.Add(Value());
            //assert
            Assert.Equal(Value(), myArr[expectedPosition]);
        }

        protected abstract T Value();
        protected abstract DynamicSortedArray<T> Array();
    }
}