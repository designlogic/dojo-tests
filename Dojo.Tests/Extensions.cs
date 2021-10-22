using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Tests
{
    public static class Extensions
    {
        public static int[,] ToMultiDimensionalArray(this int[] numbers, int columnCount)
        {
            var rowCount = numbers.Length / columnCount;
            var multiDimensionalArray = new int[rowCount, columnCount];
            var valueIndex = 0;

            for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    multiDimensionalArray[rowIndex, columnIndex] = numbers[valueIndex];
                    valueIndex++;
                }
            }

            return multiDimensionalArray;
        }

        public static string Visualize(this int[,] values)
        {
            var output = new StringBuilder();
            output.AppendLine("--------------------------------");
            for (int row = 0; row < values.GetLength(0); row++)
            {
                for (int column = 0; column < values.GetLength(1); column++)
                {
                    output.Append($"{values[row, column]} ");
                }

                output.AppendLine();
            }

            output.AppendLine("--------------------------------");
            return output.ToString();
        }
    }
}
