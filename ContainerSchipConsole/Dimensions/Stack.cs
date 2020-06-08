using ContainerSchipConsole.Containers;
using System.Collections.Generic;
using System.Net.Mime;

namespace ContainerSchipConsole.Dimensions
{
    class Stack
    {
        int y { get; set; }
        int z { get; set; }

        Container[] containers;

        public Stack(int _y, int _z)
        {
            this.y = _y; this.z = _z;

            containers = new Container[_z];
            for (int z = 0; z < _z; z++)
            {
                containers[z] = null;
            }
        }

        public bool AddContianer(Container container, int z)
        {
            if(containers[z] == null)
            {
                containers[z] = container;
                return true;
            }
            else
                return false;
        }

        public Container GetContainer(int z)
        {
            return containers[z];
        }
    }
}
