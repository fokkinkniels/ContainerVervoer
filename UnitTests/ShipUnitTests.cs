using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ContainerSchipConsole;
using ContainerSchipConsole.Containers;
using System;

namespace UnitTestsContainerShip
{
    [TestClass]
    public class ShipUnitTests
    {
        [TestMethod]
        public void RandomTest()
        {
            //Arrange
            ShipController controller = new ShipController();

            Random seedGen = new Random();

            int seed = seedGen.Next(Int32.MaxValue);

            Console.WriteLine($"The Random seed is: {seed}");

            Random random = new Random(seed);
            //print seed

            controller.CreateShip(random.Next(1, 5), random.Next(1, 5), 11);

            for (int i = 0; i < random.Next(1, 10); i++)
            {
                controller.CreateContainer(1, random.Next(20, 30), TypeContainer.Cooled_Container);
            }

            for (int i = 0; i < random.Next(1, 10); i++)
            {
                controller.CreateContainer(1, random.Next(20, 30), TypeContainer.RefrigeratedValuable_Container);
            }

            for (int i = 0; i < random.Next(1, 10); i++)
            {
                controller.CreateContainer(1, random.Next(20, 30), TypeContainer.Default_Container);
            }

            for (int i = 0; i < random.Next(1, 10); i++)
            {
                controller.CreateContainer(1, random.Next(20, 30), TypeContainer.Valuable_Container);
            }

            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), true);
        }


        [TestMethod]
        public void ShipTestMethod_01()
        {
            //Arrange
            ShipController controller = new ShipController();

            controller.CreateShip(1, 1, 11);

            controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 30, TypeContainer.RefrigeratedValuable_Container);

            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), true);
        }


        [TestMethod]
        public void ShipTestMethod_02()
        {
            //Arrange
            ShipController controller = new ShipController();

            controller.CreateShip(1, 1, 11);

            controller.CreateContainer(1, 30, TypeContainer.Valuable_Container);
            controller.CreateContainer(1, 30, TypeContainer.Valuable_Container);
            controller.CreateContainer(1, 30, TypeContainer.Valuable_Container);
            controller.CreateContainer(1, 30, TypeContainer.Valuable_Container);

            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), false);
        }


        [TestMethod]
        public void ShipTestMethod_03()
        {
            //Arrange
            ShipController controller = new ShipController();

            controller.CreateShip(2, 1, 11);

            controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);


            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), true);
        }


        [TestMethod]
        public void ShipTestMethod_04()
        {
            //Arrange
            ShipController controller = new ShipController();

            controller.CreateShip(1, 2, 11);

            controller.CreateContainer(1, 30, TypeContainer.RefrigeratedValuable_Container);
            controller.CreateContainer(1, 30, TypeContainer.RefrigeratedValuable_Container);
            controller.CreateContainer(1, 30, TypeContainer.RefrigeratedValuable_Container);
            controller.CreateContainer(1, 30, TypeContainer.RefrigeratedValuable_Container);


            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), false);
        }


        [TestMethod]
        public void ShipTestMethod_05()
        {
            //Arrange
            ShipController controller = new ShipController();

            controller.CreateShip(1, 2, 11);

            controller.CreateContainer(1, 30, TypeContainer.Valuable_Container);
            controller.CreateContainer(1, 30, TypeContainer.Valuable_Container);
            controller.CreateContainer(1, 30, TypeContainer.Valuable_Container);
            controller.CreateContainer(1, 30, TypeContainer.Valuable_Container);


            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), false);
        }


        [TestMethod]
        public void ShipTestMethod_06()
        {
            //Arrange
            ShipController controller = new ShipController();

            controller.CreateShip(1, 2, 11);

            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);

            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);

            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), false);
        }


        [TestMethod]
        public void ShipTestMethod_07()
        {
            //Arrange
            ShipController controller = new ShipController();

            controller.CreateShip(1, 1, 50);

            controller.CreateContainer(1, 5, TypeContainer.Default_Container);
            controller.CreateContainer(1, 5, TypeContainer.Default_Container);
            controller.CreateContainer(1, 5, TypeContainer.Default_Container);
            controller.CreateContainer(1, 5, TypeContainer.Default_Container);
            controller.CreateContainer(1, 5, TypeContainer.Default_Container);
            controller.CreateContainer(1, 5, TypeContainer.Default_Container);
            controller.CreateContainer(1, 5, TypeContainer.Default_Container);
            controller.CreateContainer(1, 5, TypeContainer.Default_Container);



            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), false);
        }


        [TestMethod]
        public void ShipTestMethod_08()
        {
            //Arrange
            ShipController controller = new ShipController();

            controller.CreateShip(3, 2, 11);

            controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 30, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 10, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 10, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 10, TypeContainer.Cooled_Container);

            controller.CreateContainer(1, 10, TypeContainer.RefrigeratedValuable_Container);
            controller.CreateContainer(1, 10, TypeContainer.RefrigeratedValuable_Container);
            controller.CreateContainer(1, 30, TypeContainer.RefrigeratedValuable_Container);

            controller.CreateContainer(1, 10, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 30, TypeContainer.Default_Container);
            controller.CreateContainer(1, 10, TypeContainer.Default_Container);

            controller.CreateContainer(1, 10, TypeContainer.Valuable_Container);
            controller.CreateContainer(1, 10, TypeContainer.Valuable_Container);
            controller.CreateContainer(1, 30, TypeContainer.Valuable_Container);

            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), true);
        }


        [TestMethod]
        public void ShipTestMethod_09()
        {
            //Arrange
            ShipController controller = new ShipController();

            controller.CreateShip(1, 2, 11);

            controller.CreateContainer(1, 12, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 12, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 11, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 10, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 9, TypeContainer.Cooled_Container);

            controller.CreateContainer(1, 25, TypeContainer.RefrigeratedValuable_Container);

            controller.CreateContainer(1, 28, TypeContainer.Default_Container);
            controller.CreateContainer(1, 27, TypeContainer.Default_Container);
            controller.CreateContainer(1, 22, TypeContainer.Default_Container);
            controller.CreateContainer(1, 22, TypeContainer.Default_Container);
            controller.CreateContainer(1, 21, TypeContainer.Default_Container);
            controller.CreateContainer(1, 12, TypeContainer.Default_Container);
            controller.CreateContainer(1, 12, TypeContainer.Default_Container);
            controller.CreateContainer(1, 9, TypeContainer.Default_Container);
            controller.CreateContainer(1, 6, TypeContainer.Default_Container);
            controller.CreateContainer(1, 5, TypeContainer.Default_Container);

            controller.CreateContainer(1, 11, TypeContainer.Valuable_Container);

            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), true);
        }


        [TestMethod]
        public void ShipTestMethod_10()
        {
            //Arrange
            ShipController controller = new ShipController();

            controller.CreateShip(1, 2, 11);

            controller.CreateContainer(1, 27, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 25, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 21, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 17, TypeContainer.Cooled_Container);
            controller.CreateContainer(1, 5, TypeContainer.Cooled_Container);
 
            controller.CreateContainer(1, 22, TypeContainer.RefrigeratedValuable_Container);

            controller.CreateContainer(1, 27, TypeContainer.Default_Container);
            controller.CreateContainer(1, 21, TypeContainer.Default_Container);
            controller.CreateContainer(1, 13, TypeContainer.Default_Container);
            controller.CreateContainer(1, 9, TypeContainer.Default_Container);
            controller.CreateContainer(1, 8, TypeContainer.Default_Container);
            controller.CreateContainer(1, 5, TypeContainer.Default_Container);
   
            controller.CreateContainer(1, 27, TypeContainer.Valuable_Container);

            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), true);
        }
    }
}
