using ContainerSchipConsole.Containers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerSchipConsole.Dimensions
{
    class Row
    {
        public Stack[] stacks;

        public Row(int maxLength, int maxHeight)
        {
            //create stacks
            stacks = new Stack[maxLength];
            for (int depth = 0; depth < maxLength; depth++)
            {
                var newStack = new Stack(depth, maxHeight);
                stacks[depth]  = newStack;
            }
        }

        public bool AddToStack(Container container, int depth, int height)
        {
            if(stacks[depth].AddContainer(container, height))
                return true;
            else
                return false;
        }

        public Container GetContainer(int depth, int height)
        {
            if(depth >= stacks.Length || depth < 0)
            {
                return null;
            }
            return stacks[depth].GetContainer(height);
        }
    }
}
