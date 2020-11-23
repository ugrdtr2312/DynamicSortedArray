using DynamicSortedArray.UnitTests.MyArrayTestsAbstractions;

namespace DynamicSortedArray.UnitTests.MyArrayTestsRealizations
{
    public class MyArrayStringTests : MyArrayReferenceTests<string>
    {
        protected override string Value() => "a";
        
        protected override DynamicSortedArray<string> Array() => new DynamicSortedArray<string> { "b", "c", "d", "e"};
    }
}