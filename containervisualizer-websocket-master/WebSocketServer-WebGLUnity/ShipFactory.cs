using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketServer_WebGLUnity
{
    public static class ShipFactory
    {
        private static Random random = new Random();

        public static string GenerateRandomShip()
        {
            return GenerateShip(random.Next(1, 5), random.Next(1, 5), random.Next(0, 4), 40);
        }

        public static string GenerateShip(int maxWidth, int maxHeight, int maxStackHeight, int maxContainerWeight)
        {
            int width = maxWidth;
            int length = maxHeight;

            string url = $"?length={length}&width={width}";

            var rowsOfStacks = GenerateRowsOfStacks(width, length, maxStackHeight, maxContainerWeight);
            string stacks = $"&stacks={rowsOfStacks.Types}";
            string weights = $"&weights={rowsOfStacks.Weights}";

            return url + stacks + weights;
        }

        static (string Types, string Weights) GenerateRowsOfStacks(int numRows, int rowLength, int maxStackHeight, int maxContainerWeight)
        {
            string rowsOfStacksTypes = "";
            string rowsOfStacksWeights = "";
            for (int i = 0; i < numRows; i++)
            {
                var rowOfStacks = GenerateRowOfStacks(rowLength, maxStackHeight, maxContainerWeight);
                rowsOfStacksTypes = rowsOfStacksTypes + rowOfStacks.Types + "/";
                rowsOfStacksWeights = rowsOfStacksWeights + rowOfStacks.Weights + "/";
            }

            return (rowsOfStacksTypes.TrimEnd('/'), rowsOfStacksWeights.TrimEnd('/'));
        }

        static (string Types, string Weights) GenerateRowOfStacks(int lengthRow, int maxStackHeight, int maxContainerWeight)
        {
            string rowOfStacksTypes = "";
            string rowOfStacksWeights = "";
            for (int l = 0; l < lengthRow; l++)
            {
                var stack = GenerateStack(maxStackHeight, maxContainerWeight);
                rowOfStacksTypes = rowOfStacksTypes + stack.Types + ",";
                rowOfStacksWeights = rowOfStacksWeights + stack.Weights + ",";
            }
            return (rowOfStacksTypes.TrimEnd(','), rowOfStacksWeights.TrimEnd(','));
        }

        static (string Types, string Weights) GenerateStack(int maxStackHeight, int maxContainerWeight)
        {
            int stackHeight = maxStackHeight;
            string stackTypes = "";
            string stackWeights = "";
            for (int h = 0; h < stackHeight; h++)
            {
                var container = GenerateContainer(maxContainerWeight);
                stackTypes = stackTypes + $"{container.Type}-";
                stackWeights = stackWeights + $"{container.Weight}-";
            }

            return (stackTypes.TrimEnd('-'), stackWeights.TrimEnd('-'));
        }

        static (string Type, string Weight) GenerateContainer(int maxContainerWeight)
        {
            return (RandomContainerType(), RandomContainerWeight(maxContainerWeight));
        }

        static string RandomContainerWeight(int maxContainerWeight)
        {
            return random.Next(1, maxContainerWeight + 1).ToString(); //in ton (Container casus valid weights are 4..30)
        }

        static string RandomContainerType()
        {
            return random.Next(1, 5).ToString(); //only 4 valid types: 1 (Normal), 2(Valuable), 3(Coolable), 4(Valuable and Coolable)
        }
    }
}
