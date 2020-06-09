using ContainerSchipConsole.Containers;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Security.Cryptography;

namespace ContainerSchipConsole
{
    public class ShipController
    {
        Ship ship { get; set; }
        List<Container> containersList = new List<Container>();


        /// <summary>
        /// ACTIONs
        /// </summary>


        public bool CalculateContainersPos()
        {
            List<Container> selectedContainers = new List<Container>();
            TypeContainer type = TypeContainer.Cooled_Container;
            bool toggle = false;
            bool placing = true;

            int counter02 = 0;
            int x; int y;
            x = y = 0;


            bool PlaceCooled01(Container container)
            {
                int counter01 = 0;

                while (!container.GetPlacedStatus())
                {
                    if (toggle)
                    {
                        for (int i = ship.GetRows() - 1; i > 0 && toggle; i--)
                        {
                            if (PlaceContainer(container, i, y))
                            {
                                counter02++;
                                toggle = !toggle;
                                return true;
                            }
                        }
                        counter01++;
                    }
                    else if (!toggle)
                    {

                        for (int i = 0; i < ship.GetRows() && !toggle; i++)
                        {
                            if (PlaceContainer(container, i, y))
                            {
                                counter02++;
                                //toggle = !toggle;
                                if (counter02 == 2)
                                {
                                    toggle = !toggle;
                                    counter02 = 0;
                                }
                                return true;
                            }
                        }
                        counter01++;
                    }
                    toggle = !toggle;

                    if (counter01 > ship.GetRows())
                    {
                        break;
                    }
                }

                return false;
            }
            bool PlaceUnCooled01(Container container)
            {
                int counter = 0;

                while (!container.GetPlacedStatus())
                {
                    if (toggle)
                    {
                        for (int x = ship.GetRows() - 1; x > 0 && toggle; x--)
                        {
                            for (int _y = 1; _y < ship.GetDepth(); _y++)
                            {
                                if (PlaceContainer(container, x, _y))
                                {
                                    toggle = !toggle;
                                    return true;
                                }
                            }
                        }
                        counter++;
                    }
                    else if (!toggle)
                    {

                        for (int x = 0; x < ship.GetRows() && !toggle; x++)
                        {
                            for (int _y = 0; _y < ship.GetDepth(); _y++)
                            {
                                if (PlaceContainer(container, x, _y))
                                {
                                    //toggle = !toggle;
                                    if (counter02 == 2)
                                    {
                                        toggle = !toggle;
                                        counter02 = 0;
                                    }
                                    return true;
                                }
                            }
                        }
                        counter++;
                    }
                    toggle = !toggle;

                    if (counter > ship.GetRows() * ship.GetDepth())
                    {
                        break;
                    }
                }
                return false;
            }

            bool PlaceCooled02(Container container)
            {
                int counter01 = 0;

                while (!container.GetPlacedStatus()) {
                    if (toggle)
                    {
                        for (int i = ship.GetRows()-1; i > 0 && toggle; i--)
                        {
                            if(PlaceContainer(container, i, y))
                            {
                                counter02++;
                                //toggle = !toggle;
                                if (counter02 == 2)
                                {
                                    toggle = !toggle;
                                    counter02 = 0;
                                }
                                return true;
                            }
                        }
                        counter01++;
                    }
                    else if (!toggle)
                    {

                        for (int i = 0; i < ship.GetRows() && !toggle; i++)
                        {
                            if (PlaceContainer(container, i, y))
                            {
                                counter02++;
                                //toggle = !toggle;
                                if (counter02 == 2)
                                {
                                    toggle = !toggle;
                                    counter02 = 0;
                                }
                                return true;
                            }
                        }
                        counter01++;
                    }
                    toggle = !toggle;

                    if (counter01 > ship.GetRows())
                    {
                        break;
                    }
                }

                return false;
            }
            bool PlaceUnCooled02(Container container)
            {
                int counter = 0;

                while (!container.GetPlacedStatus())
                {
                    if (toggle)
                    {
                        for (int x = ship.GetRows() - 1; x > 0 && toggle; x--)
                        {
                            for (int _y = 1; _y < ship.GetDepth(); _y++)
                            {
                                if (PlaceContainer(container, x, _y))
                                {
                                    //toggle = !toggle;
                                    if (counter02 == 2)
                                    {
                                        toggle = !toggle;
                                        counter02 = 0;
                                    }
                                    return true;
                                }
                            }
                        }
                        counter++;
                    }
                    else if (!toggle)
                    {

                        for (int x = 0; x < ship.GetRows() && !toggle; x++)
                        {
                            for (int _y = 0; _y < ship.GetDepth(); _y++)
                            {
                                if (PlaceContainer(container, x, _y))
                                {
                                    //toggle = !toggle;
                                    if (counter02 == 2)
                                    {
                                        toggle = !toggle;
                                        counter02 = 0;
                                    }
                                    return true;
                                }
                            }
                        }
                        counter++;
                    }
                    toggle = !toggle;

                    if (counter > ship.GetRows()*ship.GetDepth())
                    {
                        break;
                    }                
                }
                return false;
            }

            while (placing) {
                switch (type)
                {

                    case TypeContainer.Cooled_Container:
                        selectedContainers = FilterContainers(containersList, type);
                        selectedContainers = SortBigToSmall(selectedContainers);

                        foreach (var container in selectedContainers)
                        {
                            PlaceCooled02(container);
                        }

                        type = TypeContainer.RefrigeratedValuable_Container;
                        break;
                    //END OF CASE


                    case TypeContainer.RefrigeratedValuable_Container:

                        selectedContainers = FilterContainers(containersList, type);
                        selectedContainers = SortBigToSmall(selectedContainers);

                        foreach (var container in selectedContainers)
                        {
                            PlaceCooled02(container);
                        }

                        type = TypeContainer.Default_Container;
                        break;
                    //END OF CASE


                    case TypeContainer.Default_Container:
                        selectedContainers = FilterContainers(containersList, type);
                        selectedContainers = SortBigToSmall(selectedContainers);

                        foreach (var container in selectedContainers)
                        {
                            PlaceUnCooled02(container);
                        }

                        type = TypeContainer.Valuable_Container;
                        break;
                    //END OF CASE


                    case TypeContainer.Valuable_Container:
                        selectedContainers = FilterContainers(containersList, type);
                        selectedContainers = SortBigToSmall(selectedContainers);

                        foreach (var container in selectedContainers)
                        {
                            PlaceUnCooled02(container);
                        }

                        type = TypeContainer.Valuable_Container;
                        placing = false;
                        break;
                }
            }

            return true;
        }

        private bool PlaceContainer(Container container, int width, int depth)
        {
            for (int height = 0; height < ship.GetHeight(); height++)
            {
                if(ship.GetContainer(width, depth, height) != null)
                {
                    if (ship.GetContainer(width, depth, height).GetType() == TypeContainer.RefrigeratedValuable_Container || ship.GetContainer(width, depth, height).GetType() == TypeContainer.Valuable_Container)
                    {
                        Program.PrintError("ERR: VALUABLE");
                        return false;
                    }

                    if(!CheckWeight(container, width, depth, height))
                    {
                        Program.PrintError("ERR: WEIGHT");
                        return false;
                    }
                }

                if (ship.GetContainer(width, depth + 1, height) != null)
                {
                    if (ship.GetContainer(width, depth + 1, height).GetType() == TypeContainer.Valuable_Container || ship.GetContainer(width, depth + 1, height).GetType() == TypeContainer.RefrigeratedValuable_Container)
                    {
                        Program.PrintError("ERR: NEXT TO VALUABLE");
                        return false;
                    }
                }
                if (ship.GetContainer(width, depth - 1, height) != null)
                {
                    if (ship.GetContainer(width, depth - 1, height).GetType() == TypeContainer.Valuable_Container || ship.GetContainer(width, depth - 1, height).GetType() == TypeContainer.RefrigeratedValuable_Container)
                    {
                        Program.PrintError("ERR: NEXT TO VALUABLE");
                        return false;
                    }
                }


   
                if(ship.GetContainer(width, depth, height) == null)
                {
                    if(container.GetType() == TypeContainer.Valuable_Container || container.GetType() == TypeContainer.RefrigeratedValuable_Container)
                    {
                        if(ship.GetContainer(width, depth + 1, height)!= null)
                        {
                            Program.PrintError("ERR: NEXT TO VALUABLE");
                        }
                        if (ship.GetContainer(width, depth - 1, height) != null)
                        {
                            Program.PrintError("ERR: NEXT TO VALUABLE");
                        }
                    }


                    if (ship.AddToRow(container, width, depth, height))
                    {
                        Program.PrintMessage($"placed {container} at index: {width} {depth} {height} with a weight of: {container.GetWeight()}");
                        container.SetPlacedStatus(true);
                        container.SetIndex(height);
                        return true;
                    }
                    else
                    {
                        Program.PrintError($"Could not place container at {width} {depth} {height}");
                    }
                }
            }
            Program.PrintError($"Could not place container at {width} {depth}");
            return false;
        }


        /// <summary>
        ///    CHECKS AND VALIDATIONS
        /// </summary>


        private bool CheckWeightShip()
        {
            float weight = 0;

            for (int width = 0; width < ship.GetRows(); width++)
            {
                for (int depth = 0; depth < ship.GetDepth(); depth++)
                {
                    for (int height = 0; height < ship.GetHeight(); height++)
                    {
                        var container = ship.GetContainer(width, depth, height);
                        if (container != null)
                        {
                            weight += container.GetWeight();
                        }
                    }
                }
            }

            float load = 100 * (weight / (float)ship.GetMaxWeight());

            if (load > 100)
            {
                Program.PrintError("");
                Program.PrintError("");
                Program.PrintError("FATAL ERROR:");
                Program.PrintError($"SHIP IS OVERLOADED, THE LOAD IS {load}% OF MAX WEIGHT");
                return false;
            }
            else if (load < 50)
            {
                Program.PrintError("");
                Program.PrintError("");
                Program.PrintError("FATAL ERROR:");
                Program.PrintError($"SHIP IS UNDERLOADED, THE LOAD IS {load}% OF MAX WEIGHT");
                return false;
            }
            else
            {
                Program.PrintSucces("");
                Program.PrintSucces("");
                Program.PrintSucces($"SHIP IS LOADED PROPERLY, THE LOAD IS {load}% OF MAX WEIGHT");

                return true;
            }
        }

        private bool CheckBalanceShip()
        {
            float rows = ship.GetRows();
            float halfway = rows / 2;

            float weightL = 0;
            float weightR = 0;
            
            for (int width = 0; width < halfway; width++)
                {
                    for (int depth = 0; depth < ship.GetDepth(); depth++)
                    {
                        for (int height = 0; height < ship.GetHeight(); height++)
                        {
                            var container = ship.GetContainer(width, depth, height);
                            if(container != null)
                            {
                                weightL += container.GetWeight();
                            }     
                        }
                    }
            }
            for (int width = (int)halfway; width < rows; width++)
            {
                for (int depth = 0; depth < ship.GetDepth(); depth++)
                {
                    for (int height = 0; height < ship.GetHeight(); height++)
                    {
                        var container = ship.GetContainer(width, depth, height);
                        if (container != null)
                        {
                            weightR += container.GetWeight();
                        }       
                    }
                }
            }


            float difference = 100*(weightL/weightR);

            if(difference > 120 || difference < 80)
            {
                Program.PrintError("");
                Program.PrintError("FATAL ERROR:");
                Program.PrintError($"SHIP IS UNBALANCED, THE DIFFERENCE IS {difference}%");
                Program.PrintError("");
                return false;
            }
            else
            {
                Program.PrintSucces("");
                Program.PrintSucces($"SHIP IS BALANCED, THE DIFFERENCE IS {difference}%");
                Program.PrintSucces("");

                return true;
            }
        }

        public bool ValidateShip() { 

            if (!CheckWeightShip())
            {
                return false;
            }
            else if (!CheckBalanceShip())
            {
                return false;
            }
            else
            {
                Program.PrintMessage("");
                Program.PrintSucces("THE BOAT IS READY TO TAKE OFF");
                Program.PrintSucces($"WITH {GetLoadedContainerAmount()} CONTAINERS LOADED ONBOARD");
                Program.PrintMessage("");
                return true;
            }
        }

        private bool CheckWeight(Container container, int breeted, int depth, int z)
        {
            int weight;

            for (int i = 0; i < ship.GetHeight(); i++)
            {
                weight = container.GetWeight();
                for (int height = i; height < ship.GetHeight(); height++)
                {
                    if (ship.GetContainer(breeted, depth, height) != null)
                    {
                        weight += ship.GetContainer(breeted, depth, height).GetWeight();
                    }
                }

                if (ship.GetContainer(breeted, depth, i) != null)
                {
                    weight -= ship.GetContainer(breeted, depth, i).GetWeight();
                }

                if (weight > 120)
                {
                    return false;
                }

                weight = 0;
            }

            return true;
        }


        /// <summary>
        /// FILTERS AND SORTS
        /// </summary>


        private List<Container> FilterContainers(List<Container> unFiltered, int weight)
        {
            List<Container> filteredList = new List<Container>();

            foreach (var container in unFiltered)
            {
                if (container.GetWeight() >= weight)
                {
                    filteredList.Add(container);
                }
            }

            return filteredList;
        }

        private List<Container> FilterContainers(List<Container> unFiltered, TypeContainer type)
        {
            List<Container> filteredList = new List<Container>();

            foreach (var container in unFiltered)
            {
                if(container.GetType() == type)
                {
                    filteredList.Add(container);
                }
            }

            return filteredList;
        }

        private List<Container> SortBigToSmall(List<Container> unSortedList)
        {
            Container temp;
            for (int i = 0; i < unSortedList.Count; i++)
            {
                for (int v = 1; v < (unSortedList.Count - i); v++)
                {
                    if (unSortedList[v - 1].GetWeight() < unSortedList[v].GetWeight())
                    {
                        temp = unSortedList[v - 1];
                        unSortedList[v - 1] = unSortedList[v];
                        unSortedList[v] = temp;
                    }

                }
            }
            return unSortedList;
        }


        /// <summary>
        /// CREATE FUNCTIONS
        /// </summary>


        public bool CreateShip(int maxWidth, int maxLenght, int maxHeight)
        {
            ship = new Ship(maxWidth, maxLenght, maxHeight);
            return true;
        }

        public bool CreateContainer(int index, int weight, TypeContainer type)
        {

            if(weight > 30 || weight < 4)
            {
                Program.PrintError("The Weight of The Container cant be more than 30 and less than 4");
                return false;
            }

            if(type == TypeContainer.Default_Container)
            {
                var newContainer = new DefaultContainer(index, weight);
                containersList.Add(newContainer);
                return true;
            }
            else if (type == TypeContainer.Cooled_Container)
            {
                var newContainer = new CooledContainer(index, weight);
                containersList.Add(newContainer);
                return true;
            }
            else if (type == TypeContainer.Valuable_Container)
            {
                var newContainer = new ValuableContainer(index, weight);
                containersList.Add(newContainer);
                return true;
            }
            else if (type == TypeContainer.RefrigeratedValuable_Container)
            {
                var newContainer = new ValuableCooledContainer(index, weight);
                containersList.Add(newContainer);
                return true;
            }

            return false;
        }


        /// <summary>
        /// RETURN FUNCTIONS
        /// </summary>


        public int GetLoadedContainerAmount()
        {
            return ship.GetContainerAmount();
        }

        public Container GetContainer(int x, int y, int z)
        {
            Container container = ship.GetContainer(x, y, z);

            if (container != null)
                return container;
            else
                return null;
        }

        public void GetShipDimensions(out int width, out int lenght, out int height)
        {
            ship.GetDimensions(out width, out lenght, out height);
        }  
    }
}
