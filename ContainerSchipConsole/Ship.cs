using ContainerSchipConsole.Containers;
using ContainerSchipConsole.Dimensions;
using System.Collections.Generic;

namespace ContainerSchipConsole
{
    class Ship
    {
        int width { get; set; }
        int lenght { get; set; }
        int height { get; set; }

        int maxWeightPerSpot = 100;
        int maxWeight { get; set; }

        Row[] rows;
        List<Container> containers = new List<Container>();

        public Ship(int maxWidth, int maxLenght, int maxHeight)
        {
            //declare ship dimensions
            width = maxWidth; lenght = maxLenght; height = maxHeight;

            //calculate maxweight
            CalculateMaxWeight();

            //create rows
            rows = new Row[width];
            for (int x = 0; x < width; x++)
            {
                var newRow = new Row(lenght, height);
                rows[x] = newRow;
            }
        }


        private void CalculateMaxWeight()
        {
            for (int breeted = 0; breeted < width; breeted++)
            {
                for (int depth = 0; depth < lenght; depth++)
                {
                    maxWeight += maxWeightPerSpot;    
                }
            }
        }

        public bool AddToRow(Container container, int breeted, int depth, int height)
        {
            if (rows[breeted].AddToStack(container, depth, height))
            {
                containers.Add(container);
                return true;
            }
            else
                return false;
        }


        /// <summary>
        /// RETURN FUNCTIONS
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_z"></param>



        public int GetRows()
        {
            return rows.Length;
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetDepth()
        {
            return lenght;
        }

        public int GetMaxWeight()
        {
            return maxWeight;
        }

        public int GetContainerAmount()
        {
            return containers.Count;
        }

        public void GetDimensions(out int x, out int y, out int z)
        {
            //returns ship dimensions
            x = width; y = lenght; z = height;
            return;
        }

        public Container GetContainer(int x, int y, int z)
        {
            if (x >= rows.Length || x < 0)
            {
                return null;
            }
            return rows[x].GetContainer(y, z);
        }
    }
}
