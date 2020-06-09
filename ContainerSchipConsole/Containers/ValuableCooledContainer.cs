
namespace ContainerSchipConsole.Containers
{
    class ValuableCooledContainer : Container
    {
        public ValuableCooledContainer(int _index, int _weight)
        {
            Type = TypeContainer.RefrigeratedValuable_Container;
            Index = _index;
            Weight = _weight;
            Placed = false;

        }
    }
}
