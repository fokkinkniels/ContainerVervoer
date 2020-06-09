using ContainerSchipConsole.Containers;
using System.Collections.Generic;
using System.Net.Mime;

namespace ContainerSchipConsole.Dimensions
{
    class Stack
    {
        int maxHeight;

        Container[] containers;

        public Stack(int _y, int _z)
        {
            maxHeight = _z;

            containers = new Container[maxHeight];
            for (int height = 0; height < maxHeight; height++)
            {
                containers[height] = null;
            }
        }

        public bool AddContainer(Container container, int height)
        {
            if(containers[height] == null)
            {
                containers[height] = container;
                return true;
            }
            else
                return false;
        }

        public Container GetContainer(int height)
        {
            return containers[height];
        }
    }
}
