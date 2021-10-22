using Dojo.Rooms;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Tests
{
    public class EnclosedIslandsTests : TestBase
    {
        /*
        Summary
            You are given a two-dimensional integer matrix of 1s and 0s.
        
            A 1 represents land and 0 represents water.
        
            From any land cell you can choose a direction, North, South, East and West.
        
            Return the number of land cells from which we cannot go off the matrix.

        Example
             map = [
                        [0, 0, 0, 1],
                        [0, 1, 1, 0],
                        [0, 1, 1, 0],
                        [0, 0, 0, 0]
                     ]
        Output 
            4
        
        Explanation
            There's 4 land squares in the middle from which we cannot walk off the matrix.

         */

        private readonly EnclosedIslands sut = new EnclosedIslands();

        public EnclosedIslandsTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 0, 1, 0, 1 }, 2, 0)]
        [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },3, 0)]
        [InlineData(new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 },3, 1)]
        [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1 },3, 0)]
        [InlineData(new int[] { 0, 0, 0, 0, 1, 0, 1, 0, 1 },3, 1)]
        [InlineData(new int[] { 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0 },4, 2)]
        [InlineData(new int[] { 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0 },4, 4)]
        [InlineData(new int[] { 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0 },4, 2)]
        [InlineData(new int[] { 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },4, 3)]
        [InlineData(new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0 },4, 2)]
        [InlineData(new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },4, 1)]
        [InlineData(new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },4, 0)]
        [InlineData(new int[] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },4, 0)]
        public void RangeUpdate(int[] map, int columns, int expectedResult)
        {
            var multiDimensionalArray = map.ToMultiDimensionalArray(columns);
            output.WriteLine(multiDimensionalArray.Visualize());
            int result = sut.Process(map: multiDimensionalArray);
            result.ShouldBe(expectedResult);
        }
    }
}
