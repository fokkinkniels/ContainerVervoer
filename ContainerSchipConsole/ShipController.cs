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
            typeContainer type = typeContainer.cooled;
            bool toggle = false;
            bool placing = true;

            int counter02 = 0;
            int x; int y;
            x = y = 0;


            bool PlaceCooled01(Container container)
            {
                int counter01 = 0;

                while (!container.Placed)
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

                while (!container.Placed)
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

                while (!container.Placed) {
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

                while (!container.Placed)
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


                    case typeContainer.cooled:
                        selectedContainers = FilterContainers(containersList, type);
                        selectedContainers = SortBigToSmall(selectedContainers);

                        foreach (var container in selectedContainers)
                        {
                            PlaceCooled02(container);
                        }

                        type = typeContainer.refrigerated_valuable;
                        break;
                    //END OF CASE


                    case typeContainer.refrigerated_valuable:

                        selectedContainers = FilterContainers(containersList, type);
                        selectedContainers = SortBigToSmall(selectedContainers);

                        foreach (var container in selectedContainers)
                        {
                            PlaceCooled02(container);
                        }

                        type = typeContainer.Default;
                        break;
                    //END OF CASE


                    case typeContainer.Default:
                        selectedContainers = FilterContainers(containersList, type);
                        selectedContainers = SortBigToSmall(selectedContainers);

                        foreach (var container in selectedContainers)
                        {
                            PlaceUnCooled02(container);
                        }

                        type = typeContainer.valuable;
                        break;
                    //END OF CASE


                    case typeContainer.valuable:
                        selectedContainers = FilterContainers(containersList, type);
                        selectedContainers = SortBigToSmall(selectedContainers);

                        foreach (var container in selectedContainers)
                        {
                            PlaceUnCooled02(container);
                        }

                        type = typeContainer.valuable;
                        placing = false;
                        break;
                }
            }

            return true;
        }

        private bool PlaceContainer(Container container, int x, int y)
        {
            for (int _z = 0; _z < ship.GetHeight(); _z++)
            {
                if(ship.GetContainer(x, y, _z) != null)
                {
                    if (ship.GetContainer(x, y, _z).Type == typeContainer.refrigerated_valuable || ship.GetContainer(x, y, _z).Type == typeContainer.valuable)
                    {
                        Program.PrintError("ERR: VALUABLE");
                        return false;
                    }

                    if(!CheckWeight(container, x, y, _z))
                    {
                        Program.PrintError("ERR: WEIGHT");
                        return false;
                    }
                }

                if (ship.GetContainer(x, y + 1, _z) != null)
                {
                    if (ship.GetContainer(x, y + 1, _z).Type == typeContainer.valuable || ship.GetContainer(x, y + 1, _z).Type == typeContainer.refrigerated_valuable)
                    {
                        Program.PrintError("ERR: NEXT TO VALUABLE");
                        return false;
                    }
                }
                if (ship.GetContainer(x, y - 1, _z) != null)
                {
                    if (ship.GetContainer(x, y - 1, _z).Type == typeContainer.valuable || ship.GetContainer(x, y - 1, _z).Type == typeContainer.refrigerated_valuable)
                    {
                        Program.PrintError("ERR: NEXT TO VALUABLE");
                        return false;
                    }
                }


   
                if(ship.GetContainer(x, y, _z) == null)
                {
                    if(container.Type == typeContainer.valuable || container.Type == typeContainer.refrigerated_valuable)
                    {
                        if(ship.GetContainer(x, y + 1, _z)!= null)
                        {
                            Program.PrintError("ERR: NEXT TO VALUABLE");
                        }
                        if (ship.GetContainer(x, y - 1, _z) != null)
                        {
                            Program.PrintError("ERR: NEXT TO VALUABLE");
                        }
                    }


                    if (ship.AddToRow(container, x, y, _z))
                    {
                        Program.PrintMessage($"placed {container} at index: {x} {y} {_z} with a weight of: {container.Weight}");
                        container.Placed = true;
                        container.Index = _z;
                        return true;
                    }
                    else
                    {
                        Program.PrintError($"Could not place container at {x} {y} {_z}");
                    }
                }
            }
            Program.PrintError($"Could not place container at {x} {y}");
            return false;
        }


        /// <summary>
        ///    CHECKS AND VALIDATIONS
        /// </summary>


        private bool CheckWeightShip()
        {
            float weight = 0;

            for (int x = 0; x < ship.GetRows(); x++)
            {
                for (int y = 0; y < ship.GetDepth(); y++)
                {
                    for (int z = 0; z < ship.GetHeight(); z++)
                    {
                        var container = ship.GetContainer(x, y, z);
                        if (container != null)
                        {
                            weight += container.Weight;
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
            
            for (int x = 0; x < halfway; x++)
                {
                    for (int y = 0; y < ship.GetDepth(); y++)
                    {
                        for (int z = 0; z < ship.GetHeight(); z++)
                        {
                            var container = ship.GetContainer(x, y, z);
                            if(container != null)
                            {
                                weightL += container.Weight;
                            }     
                        }
                    }
            }
            for (int x = (int)halfway; x < rows; x++)
            {
                for (int y = 0; y < ship.GetDepth(); y++)
                {
                    for (int z = 0; z < ship.GetHeight(); z++)
                    {
                        var container = ship.GetContainer(x, y, z);
                        if (container != null)
                        {
                            weightR += container.Weight;
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

        private bool CheckWeight(Container container, int x, int y, int z)
        {
            //TOOD: Weight is not added right, dont know where the bug is at yet
            int weight = 0;

            for (int i = 0; i < ship.GetHeight(); i++)
            {
                weight = container.Weight;
                for (int _z = i; _z < ship.GetHeight(); _z++)
                {
                    if (ship.GetContainer(x, y, _z) != null)
                    {
                        weight += ship.GetContainer(x, y, _z).Weight;
                    }
                }

                if (ship.GetContainer(x, y, i) != null)
                {
                    weight -= ship.GetContainer(x, y, i).Weight;
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
                if (container.Weight >= weight)
                {
                    filteredList.Add(container);
                }
            }

            return filteredList;
        }

        private List<Container> FilterContainers(List<Container> unFiltered, typeContainer type)
        {
            List<Container> filteredList = new List<Container>();

            foreach (var container in unFiltered)
            {
                if(container.Type == type)
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
                    if (unSortedList[v - 1].Weight < unSortedList[v].Weight)
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


        public bool CreateShip(int x, int y, int z)
        {
            ship = new Ship(x, y, z);
            return true;
        }

        public bool CreateContainer(int index, int weight, typeContainer type)
        {

            if(weight > 30 || weight < 4)
            {
                Program.PrintError("The Weight of The Container cant be more than 30 and less than 4");
                return false;
            }

            if(type == typeContainer.Default)
            {
                var newContainer = new DefaultContainer(index, weight);
                containersList.Add(newContainer);
                return true;
            }
            else if (type == typeContainer.cooled)
            {
                var newContainer = new CooledContainer(index, weight);
                containersList.Add(newContainer);
                return true;
            }
            else if (type == typeContainer.valuable)
            {
                var newContainer = new ValuableContainer(index, weight);
                containersList.Add(newContainer);
                return true;
            }
            else if (type == typeContainer.refrigerated_valuable)
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

        public void GetShipDimensions(out int _x, out int _y, out int _z)
        {
            ship.GetDimensions(out _x, out _y, out _z);
        }  
    }
}
