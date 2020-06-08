
namespace ContainerSchipConsole.Containers
{
    class CooledContainer : Container
    {
        public CooledContainer(int _index, int _weight)
        {
            Type = typeContainer.cooled;
            Index = _index;
            Weight = _weight;
            Placed = false;

        }
    }
}
