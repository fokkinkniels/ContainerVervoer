using ContainerSchipConsole.Containers;
using System;

namespace ContainerSchipConsole
{
    class Program
    {
        static ShipController controller;

        static void Main(string[] args)
        {

            ShipController controller = new ShipController();

            controller.CreateShip(3, 3, 11);

            controller.CreateContainer(1, 30, typeContainer.cooled);
            controller.CreateContainer(1, 30, typeContainer.cooled);
            controller.CreateContainer(1, 30, typeContainer.cooled);
            controller.CreateContainer(1, 30, typeContainer.cooled);
            controller.CreateContainer(1, 30, typeContainer.cooled);
            controller.CreateContainer(1, 30, typeContainer.cooled);
            controller.CreateContainer(1, 30, typeContainer.cooled);

            controller.CreateContainer(1, 10, typeContainer.refrigerated_valuable);
            controller.CreateContainer(1, 10, typeContainer.refrigerated_valuable);
            controller.CreateContainer(1, 30, typeContainer.refrigerated_valuable);

            controller.CreateContainer(1, 10, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 13, typeContainer.Default);
            controller.CreateContainer(1, 13, typeContainer.Default);
            controller.CreateContainer(1, 13, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 20, typeContainer.Default);
            controller.CreateContainer(1, 20, typeContainer.Default);
            controller.CreateContainer(1, 20, typeContainer.Default);

            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 10, typeContainer.Default);

            controller.CreateContainer(1, 10, typeContainer.valuable);
            controller.CreateContainer(1, 10, typeContainer.valuable);
            controller.CreateContainer(1, 30, typeContainer.valuable);

            //END TEST

            controller.CalculateContainersPos();
            controller.ValidateShip();
            

            //PrintContainers();
            //PrintDimensions();

        }

        static void PrintDimensions()
        {
            int x; int y; int z;
            controller.GetShipDimensions(out x, out y, out z);
            Console.WriteLine("The X Dimension: "+x.ToString()+ "\nThe Y Dimension: "+y.ToString()+ " \nThe Z Dimension: " +z.ToString());
        }

        static void PrintContainers()
        {
            int _x; int _y; int _z;
            controller.GetShipDimensions(out _x, out _y, out _z);

            for (int x = 0; x < _x; x++)
            {
                for (int y = 0; y < _y; y++)
                {
                    for (int z = 0; z < _z; z++)
                    {
                        var container = controller.GetContainer(x, y, z);

                        if (container != null)
                            Console.WriteLine($"The container at {x}  {y} {z} is {container} with a Weight off {container.Weight} ");
                        else
                            Console.WriteLine($"There is no Container at {x} {y} {z}");
                    }
                }
                Console.WriteLine();
            }
        }

        public static void PrintError(string Err)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Err);
            Console.ResetColor();
        }

        public static void PrintSucces(string Msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Msg);
            Console.ResetColor();
        }

        public static void PrintMessage(string Msg)
        {
            Console.WriteLine(Msg);
        }
    }
}
