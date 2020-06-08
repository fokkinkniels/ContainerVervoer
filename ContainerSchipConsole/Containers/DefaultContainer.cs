
namespace ContainerSchipConsole.Containers
{
    class DefaultContainer : Container
    {
        public DefaultContainer(int _index, int _weight)
        {
            Type = typeContainer.Default;
            Index = _index;
            Weight = _weight;
            Placed = false;
        }
    }
}
