using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ContainerSchipConsole;
using ContainerSchipConsole.Containers;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void RandomTest()
        {
            //this test will succed
            ShipController controller = new ShipController();
            Random random = new Random();

            controller.CreateShip(random.Next(1, 10), random.Next(1, 10), 11);

            for (int i = 0; i < random.Next(1, 50); i++)
            {
                controller.CreateContainer(1, random.Next(4, 30), typeContainer.cooled);
            }

            for (int i = 0; i < random.Next(1, 50); i++)
            {
                controller.CreateContainer(1, random.Next(4, 30), typeContainer.refrigerated_valuable);
            }

            for (int i = 0; i < random.Next(1, 50); i++)
            {
                controller.CreateContainer(1, random.Next(4, 30), typeContainer.Default);
            }

            for (int i = 0; i < random.Next(1, 50); i++)
            {
                controller.CreateContainer(1, random.Next(4, 30), typeContainer.valuable);
            }

            controller.CalculateContainersPos();

            Assert.AreEqual(controller.ValidateShip(), true);
        }


        [TestMethod]
        public void TestMethod1()
        {
            //this test will succed
            ShipController controller = new ShipController();

            controller.CreateShip(3, 2, 11);

            controller.CreateContainer(1, 30, typeContainer.cooled);
            controller.CreateContainer(1, 30, typeContainer.cooled);
            controller.CreateContainer(1, 30, typeContainer.cooled);
            controller.CreateContainer(1, 30, typeContainer.cooled);
            controller.CreateContainer(1, 30, typeContainer.cooled);
            controller.CreateContainer(1, 10, typeContainer.cooled);
            controller.CreateContainer(1, 10, typeContainer.cooled);
            controller.CreateContainer(1, 10, typeContainer.cooled);

            controller.CreateContainer(1, 10, typeContainer.refrigerated_valuable);
            controller.CreateContainer(1, 10, typeContainer.refrigerated_valuable);
            controller.CreateContainer(1, 30, typeContainer.refrigerated_valuable);

            controller.CreateContainer(1, 10, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 30, typeContainer.Default);
            controller.CreateContainer(1, 10, typeContainer.Default);

            controller.CreateContainer(1, 10, typeContainer.valuable);
            controller.CreateContainer(1, 10, typeContainer.valuable);
            controller.CreateContainer(1, 30, typeContainer.valuable);

            controller.CalculateContainersPos();

            Assert.AreEqual(controller.ValidateShip(), true);
        }


        [TestMethod]
        public void TestMethod3()
        {
            //this test will succed
            ShipController controller = new ShipController();

            controller.CreateShip(1, 2, 11);

            controller.CreateContainer(1, 12, typeContainer.cooled);
            controller.CreateContainer(1, 12, typeContainer.cooled);
            controller.CreateContainer(1, 11, typeContainer.cooled);
            controller.CreateContainer(1, 10, typeContainer.cooled);
            controller.CreateContainer(1, 9, typeContainer.cooled);

            controller.CreateContainer(1, 25, typeContainer.refrigerated_valuable);

            controller.CreateContainer(1, 28, typeContainer.Default);
            controller.CreateContainer(1, 27, typeContainer.Default);
            controller.CreateContainer(1, 22, typeContainer.Default);
            controller.CreateContainer(1, 22, typeContainer.Default);
            controller.CreateContainer(1, 21, typeContainer.Default);
            controller.CreateContainer(1, 12, typeContainer.Default);
            controller.CreateContainer(1, 12, typeContainer.Default);
            controller.CreateContainer(1, 9, typeContainer.Default);
            controller.CreateContainer(1, 6, typeContainer.Default);
            controller.CreateContainer(1, 5, typeContainer.Default);

            controller.CreateContainer(1, 11, typeContainer.valuable);


            controller.CalculateContainersPos();

            Assert.AreEqual(controller.ValidateShip(), true);
        }


        [TestMethod]
        public void TestMethod4()
        {
            //this test will succed
            ShipController controller = new ShipController();


            controller.CreateShip(1, 2, 11);

            controller.CreateContainer(1, 27, typeContainer.cooled);
            controller.CreateContainer(1, 25, typeContainer.cooled);
            controller.CreateContainer(1, 21, typeContainer.cooled);
            controller.CreateContainer(1, 17, typeContainer.cooled);
            controller.CreateContainer(1, 5, typeContainer.cooled);
 
            controller.CreateContainer(1, 22, typeContainer.refrigerated_valuable);

            controller.CreateContainer(1, 27, typeContainer.Default);
            controller.CreateContainer(1, 21, typeContainer.Default);
            controller.CreateContainer(1, 13, typeContainer.Default);
            controller.CreateContainer(1, 9, typeContainer.Default);
            controller.CreateContainer(1, 8, typeContainer.Default);
            controller.CreateContainer(1, 5, typeContainer.Default);
   
            controller.CreateContainer(1, 27, typeContainer.valuable);


            controller.CalculateContainersPos();

            Assert.AreEqual(controller.ValidateShip(), true);
        }
    }
}
