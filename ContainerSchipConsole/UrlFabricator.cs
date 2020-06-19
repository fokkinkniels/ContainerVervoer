using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ContainerSchipConsole
{
    public static class UrlFabricator
    {
        static Ship ship;

        public static string GenerateShip(Ship _ship)
        {
            ship = _ship;
            int width = ship.GetRows();
            int length = ship.GetDepth();
            int maxContainerWeight = 30;

            string url = $"?length={length}&width={width}";

            var rowsOfStacks = GenerateRowsOfStacks(width, length, ship.GetHeight()-1);
            string stacks = $"&stacks={rowsOfStacks.Types}";
            string weights = $"&weights={rowsOfStacks.Weights}";

            return url + stacks + weights;
        }

        static (string Types, string Weights) GenerateRowsOfStacks(int numRows, int rowLength, int maxStackHeight)
        {
            string rowsOfStacksTypes = "";
            string rowsOfStacksWeights = "";
            for (int i = 0; i < numRows; i++)
            {
                var rowOfStacks = GenerateRowOfStacks(rowLength, maxStackHeight, i);
                rowsOfStacksTypes = rowsOfStacksTypes + rowOfStacks.Types + "/";
                rowsOfStacksWeights = rowsOfStacksWeights + rowOfStacks.Weights + "/";
            }

            return (rowsOfStacksTypes.TrimEnd('/'), rowsOfStacksWeights.TrimEnd('/'));
        }

        static (string Types, string Weights) GenerateRowOfStacks(int lengthRow, int maxStackHeight, int x)
        {
            string rowOfStacksTypes = "";
            string rowOfStacksWeights = "";
            for (int l = 0; l < lengthRow; l++)
            {
                var stack = GenerateStack(maxStackHeight, x, l);
                rowOfStacksTypes = rowOfStacksTypes + stack.Types + ",";
                rowOfStacksWeights = rowOfStacksWeights + stack.Weights + ",";
            }
            return (rowOfStacksTypes.TrimEnd(','), rowOfStacksWeights.TrimEnd(','));
        }

        static (string Types, string Weights) GenerateStack(int maxStackHeight, int x, int y)
        {
            int stackHeight = maxStackHeight;
            int type = 0;
            string stackTypes = "";
            string stackWeights = "";
            for (int h = 0; h < stackHeight; h++)
            {
                var container = ship.GetContainer(x, y, h);

                if (container != null)
                {
                    if(container.GetType() == Containers.TypeContainer.Default_Container)
                    {
                        type = 1;
                    }
                    else if (container.GetType() == Containers.TypeContainer.Valuable_Container)
                    {
                        type = 2;
                    }
                    else if (container.GetType() == Containers.TypeContainer.Cooled_Container)
                    {
                        type = 3;
                    }
                    else if (container.GetType() == Containers.TypeContainer.RefrigeratedValuable_Container)
                    {
                        type = 4;
                    }

                    stackTypes = stackTypes + $"{type}-";
                    stackWeights = stackWeights + $"{container.GetWeight()}-";
                }
            }

            return (stackTypes.TrimEnd('-'), stackWeights.TrimEnd('-'));
        }
    }
}
