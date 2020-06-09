
namespace ContainerSchipConsole.Containers
{
    class ValuableContainer : Container
    {
        public ValuableContainer(int _index, int _weight)
        {
            Type = TypeContainer.Valuable_Container;
            Index = _index;
            Weight = _weight;
            Placed = false;

        }
    }
}
