using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigatorDemo.Model;
using System.Collections.Generic;

namespace NavigatorDemoTests
{
    [TestClass]
    public class SimultaneousSignalSenderTest : BaseSignalSenderTest
    {

        [TestMethod]
        public void ExecuteTestTwoDronesHaveInterruptionInSimultaneousSignalSendingPlan()
        {
            //Arrange             
            var signalSender = new SimultaneousSignalSender();
            signalSender.MissionList = Missions;

            //Act
            signalSender.Execute();

            //Assert 
            Assert.AreEqual(FirstDrone.Position, new Position(2, 1));
            Assert.AreEqual(SecondDrone.Position, new Position(3, 1));         
            Assert.AreEqual(ThirdDrone.Position, new Position(1, 3));
            Assert.AreEqual(FourthDrone.Position, new Position(3, 5));
        }
    }
}
