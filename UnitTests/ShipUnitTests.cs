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
            Random random = new Random();

            controller.CreateShip(random.Next(1, 10), random.Next(1, 10), 11);

            for (int i = 0; i < random.Next(1, 50); i++)
            {
                controller.CreateContainer(1, random.Next(4, 30), TypeContainer.Cooled_Container);
            }

            for (int i = 0; i < random.Next(1, 50); i++)
            {
                controller.CreateContainer(1, random.Next(4, 30), TypeContainer.RefrigeratedValuable_Container);
            }

            for (int i = 0; i < random.Next(1, 50); i++)
            {
                controller.CreateContainer(1, random.Next(4, 30), TypeContainer.Default_Container);
            }

            for (int i = 0; i < random.Next(1, 50); i++)
            {
                controller.CreateContainer(1, random.Next(4, 30), TypeContainer.Valuable_Container);
            }

            //Action
            controller.CalculateContainersPos();

            //Assert
            Assert.AreEqual(controller.ValidateShip(), true);
        }


        [TestMethod]
        public void ShipTestMethod_1()
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
        public void ShipTestMethod_2()
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
        public void ShipTestMethod_3()
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
