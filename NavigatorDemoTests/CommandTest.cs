using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigatorDemo.Model;
using System.Collections.Generic;
using NavigatorDemo.Common;

namespace NavigatorDemoTests
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void CommandConstructorTestIdAssignment()
        {
            //Arrange 
            int x = 1;

            //Act
            var cmd = new Command('*', 1);

            //Assert 
            Assert.AreEqual(cmd.DroneId, 1);
        }

        [TestMethod]
        public void CommandConstructorTestCodeAssignment()
        {
            //Arrange 
            int x = 1;

            //Act
            var cmd = new Command('*', 1);

            //Assert 
            Assert.AreEqual(cmd.Code, '*');
        }

        [TestMethod]
        public void BroadcastCommandTestEventShouldBeRaised()
        {
            //Arrange  
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 90);
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            List<Command> receivedEvents = new List<Command>();
            command.BroadcastingSignal += delegate(object sender, CommandEventArgs e)
            {
                receivedEvents.Add(e.Command);
            };

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual('*', receivedEvents[0].Code);
        }       
    }
}
