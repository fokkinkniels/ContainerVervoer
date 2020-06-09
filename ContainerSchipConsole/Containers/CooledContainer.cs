
namespace ContainerSchipConsole.Containers
{
    class CooledContainer : Container
    {
        public CooledContainer(int _index, int _weight)
        {
            Type = TypeContainer.Cooled_Container;
            Index = _index;
            Weight = _weight;
            Placed = false;
        }
    }
}
