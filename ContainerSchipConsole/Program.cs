using ContainerSchipConsole.Containers;
using System;

namespace ContainerSchipConsole
{
    class Program
    {
        static ShipController controller;
        static int standartHeight = 100;

        static void Main(string[] args)
        {

            controller = new ShipController();

            //standart test

            /*            controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);

                        controller.CreateContainer(1, 10, TypeContainer.RefrigeratedValuable_Container);
                        controller.CreateContainer(1, 10, TypeContainer.RefrigeratedValuable_Container);
                        controller.CreateContainer(1, 30, TypeContainer.RefrigeratedValuable_Container);

                        controller.CreateContainer(1, 10, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 13, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 13, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 13, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 20, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 20, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 20, TypeContainer.Default_Container);

                        controller.CreateContainer(1, 30, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Default_Container);
                        controller.CreateContainer(1, 10, TypeContainer.Default_Container);

                        controller.CreateContainer(1, 10, TypeContainer.Valuable_Container);
                        controller.CreateContainer(1, 10, TypeContainer.Valuable_Container);
                        controller.CreateContainer(1, 30, TypeContainer.Valuable_Container);*/

            //END TEST

            GetUserInput();


            controller.CalculateContainersPos();
            controller.ValidateShip();
        }

        static void GetUserInput()
        {
            Console.WriteLine("PLease enter ship dimensions:");
            Console.Write("What is the ships width? :");
            int x = Int32.Parse( Console.ReadLine());
            Console.Write("What is the ships depth? :");
            int y = Int32.Parse(Console.ReadLine());

            controller.CreateShip(x, y, standartHeight);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter all containers now (first weight and then type)");
            Console.WriteLine("default container: D");
            Console.WriteLine("cooled container: C");
            Console.WriteLine("valuable container: V");
            Console.WriteLine("cooled valuable container: RE");
            Console.WriteLine("so an default container with weight of 10 is '10D'");
            Console.WriteLine();

            Console.WriteLine("type Done to stop");

            bool gettingInput = true;
            while (gettingInput)
            {
                TypeContainer type = TypeContainer.Default_Container;
                string input = Console.ReadLine();
                string b = string.Empty;
                int weight = 0;

                //exits
                if (input.Contains("Done") || input.Contains("done") || input.Contains("DONE"))
                {
                    gettingInput = false;
                    break;
                }


                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsDigit(input[i]))
                        b += input[i];
                }

                if (b.Length > 0)
                {
                    weight = int.Parse(b);
                }

                if (input.Contains("D") || input.Contains("d"))
                {
                    type = TypeContainer.Default_Container;
                }
                else if (input.Contains("RE") || input.Contains("re"))
                {
                    type = TypeContainer.RefrigeratedValuable_Container;
                }
                else if (input.Contains("V") || input.Contains("v"))
                {
                    type = TypeContainer.Valuable_Container;
                }
                else if (input.Contains("C") || input.Contains("c"))
                {
                    type = TypeContainer.Cooled_Container;
                }

                controller.CreateContainer(1, weight, type);
            }
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
                            Console.WriteLine($"The container at {x}  {y} {z} is {container} with a Weight off {container.GetWeight()} ");
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
