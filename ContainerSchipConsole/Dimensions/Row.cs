using ContainerSchipConsole.Containers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerSchipConsole.Dimensions
{
    class Row
    {
        int x { get; set; }
        int y { get; set; }

        public Stack[] stacks;

        public Row(int _x, int _y, int _z)
        {
            //declare row dimensions
            this.x = _x; this.y = _y;

            //create stacks
            stacks = new Stack[_y];
            for (int y = 0; y < _y; y++)
            {
                var newStack = new Stack(y, _z);
                stacks[y]  = newStack;
            }
        }

        public bool AddToStack(Container container, int y, int z)
        {
            if(stacks[y].AddContianer(container, z))
                return true;
            else
                return false;
        }

        public Container GetContainer(int y, int z)
        {
            if(y >= stacks.Length || y < 0)
            {
                return null;
            }
            return stacks[y].GetContainer(z);
        }
    }
}
