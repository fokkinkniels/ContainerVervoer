
namespace ContainerSchipConsole.Containers
{
    class DefaultContainer : Container
    {
        public DefaultContainer(int _index, int _weight)
        {
            Type = TypeContainer.Default_Container;
            Index = _index;
            Weight = _weight;
            Placed = false;
        }
    }
}
