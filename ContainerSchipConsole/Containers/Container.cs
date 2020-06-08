
namespace ContainerSchipConsole.Containers
{
    public enum typeContainer { Default, valuable, cooled, refrigerated_valuable };

    public abstract class Container
    {
        public int Index { get; set; }
        public int Weight { get; set; }
        public bool Placed { get; set; }
        public typeContainer Type { get; set; }
    }
}
