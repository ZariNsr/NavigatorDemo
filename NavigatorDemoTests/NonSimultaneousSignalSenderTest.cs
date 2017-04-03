using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigatorDemo.Model;
using System.Collections.Generic;

namespace NavigatorDemoTests
{
    [TestClass]
    public class NonSimultaneousSignalSenderTest : BaseSignalSenderTest
    {
      
        [TestMethod]
        public void ExecuteTestDronesShouldMoveWithoutInterruptionInNonSimultaneousSignalSendingPlan()
        {
            //Arrange             
            var signalSender = new NonSimultaneousSignalSender();
            signalSender.MissionList = Missions;

            //Act
            signalSender.Execute();
            
            //Assert 
            Assert.AreEqual(FirstDrone.Position, new Position(4, 1));
            Assert.AreEqual(SecondDrone.Position, new Position(1, 1));          
            Assert.AreEqual(ThirdDrone.Position, new Position(1, 3));
            Assert.AreEqual(FourthDrone.Position, new Position(3, 5));
        }
       
    }
}
