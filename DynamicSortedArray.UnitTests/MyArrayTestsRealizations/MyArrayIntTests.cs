using DynamicSortedArray.UnitTests.MyArrayTestsAbstractions;

namespace DynamicSortedArray.UnitTests.MyArrayTestsRealizations
{
    public class MyArrayIntTests : MyArrayValuableTests<int>
    {
        protected override int Value() => 0;
        
        protected override DynamicSortedArray<int> Array() => new DynamicSortedArray<int> { 1, 2, 3, 4};
    }
}