
namespace ContainerSchipConsole.Containers
{
    class ValuableCooledContainer : Container
    {
        public ValuableCooledContainer(int _index, int _weight)
        {
            Type = typeContainer.refrigerated_valuable;
            Index = _index;
            Weight = _weight;
            Placed = false;

        }
    }
}
