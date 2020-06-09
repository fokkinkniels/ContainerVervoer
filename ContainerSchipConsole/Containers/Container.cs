
using System.ComponentModel;

namespace ContainerSchipConsole.Containers
{
    public enum TypeContainer { Default_Container, Valuable_Container, Cooled_Container, RefrigeratedValuable_Container };

    public abstract class Container
    {
        protected int Index;
        protected int Weight;
        protected bool Placed;
        protected TypeContainer Type;

        public override string ToString()
        {
            return Type.ToString();
        }


        /// <summary>
        /// SETTERS
        /// </summary>
        /// <param name="index"></param>

        public void SetIndex(int index)
        {
            Index = index;
        }

        public void SetPlacedStatus(bool placed)
        {
            Placed = placed;
        }


        /// <summary>
        /// GETTERS
        /// </summary>
        /// <returns></returns>

        public int GetIndex()
        {
            return Index;
        }

        public int GetWeight()
        {
            return Weight;
        }

        public bool GetPlacedStatus()
        {
            return Placed;
        }

        public TypeContainer GetType()
        {
            return Type;
        }
    }
}
