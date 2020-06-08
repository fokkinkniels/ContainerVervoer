using ContainerSchipConsole.Containers;
using ContainerSchipConsole.Dimensions;
using System.Collections.Generic;

namespace ContainerSchipConsole
{
    class Ship
    {
        int x { get; set; }
        int y { get; set; }
        int z { get; set; }

        int maxWeightPerSpot = 100;
        int maxWeight { get; set; }

        Row[] rows;
        List<Container> containers = new List<Container>();


        private void CalculateMaxWeight()
        {
            for (int _x = 0; _x < x; _x++)
            {
                for (int _y = 0; _y < y; _y++)
                {
                    maxWeight += maxWeightPerSpot;    
                }
            }
        }

        public Ship(int _x, int _y, int _z)
        {
            //declare ship dimensions
            this.x = _x; this.y = _y; this.z = _z;

            //calculate maxweight
            CalculateMaxWeight();

            //create rows
            rows = new Row[_x];
            for (int x = 0; x < _x ; x++)
            {
                var newRow = new Row(x, _y, _z);
                rows[x] = newRow;
            }
        }

        public bool AddToRow(Container container, int x, int y, int z)
        {
            if (rows[x].AddToStack(container, y, z))
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
            return z;
        }

        public int GetDepth()
        {
            return y;
        }

        public int GetMaxWeight()
        {
            return maxWeight;
        }

        public int GetContainerAmount()
        {
            return containers.Count;
        }

        public void GetDimensions(out int _x, out int _y, out int _z)
        {
            //returns ship dimensions
            _x = this.x; _y = this.y; _z = this.z;
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
