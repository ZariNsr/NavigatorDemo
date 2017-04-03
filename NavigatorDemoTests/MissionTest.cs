using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigatorDemo.Model;
using System.Collections.Generic;
using NavigatorDemo.Common;

namespace NavigatorDemoTests
{
    [TestClass]
    public class MissionTest
    {

        [TestMethod]
        public void MissionConstructorTestIdAssignment()
        {
            //Arrange 
            int id = 0;
            var commands = new List<Command>();

            //Act
            var mission = new Mission(id: id, commands: commands);

            //Assert 
            Assert.AreEqual(mission.Id, id);
        }

        [TestMethod]
        public void MissionConstructorTestCommandAssignment()
        {
            //Arrange 
            int id = 0;
            var commands = new List<Command>();
            commands.Add(new Command ('*', 0));

            //Act
            var mission = new Mission(id: id, commands: commands);

            //Assert 
            Assert.AreEqual(mission.Commands.Count, 1);
        }

        [TestMethod]
        public void ExecuteAllCommandsTestAllCommandsShoulBeExecuted()
        {
            //Arrange 
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
           
            var commands = new List<Command>();
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;
            commands.Add(command);
            command = new Command('>', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;
            commands.Add(command);           

            var mission = new Mission(0, commands);
            mission.TerminatedMission += drone.OnTerminatedMission;
           

            //Act
            mission.ExecuteAllCommands();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 4));
            Assert.AreEqual(drone.Direction, 0);
        }

        [TestMethod]
        public void ExecuteNextTestOneCommandsShoulBeExecuted()
        {
            //Arrange 
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;

            var commands = new List<Command>();
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;
            commands.Add(command);
            command = new Command('>', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;
            commands.Add(command);

            var mission = new Mission(0, commands);
            mission.TerminatedMission += drone.OnTerminatedMission;


            //Act
            mission.ExecuteNext();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 4));            
        }

        [TestMethod]
        public void ExecuteNextTestTwoCommandsShoulBeExecuted()
        {
            //Arrange 
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;

            var commands = new List<Command>();
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;
            commands.Add(command);
            command = new Command('>', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;
            commands.Add(command);

            var mission = new Mission(0, commands);
            mission.TerminatedMission += drone.OnTerminatedMission;


            //Act
            mission.ExecuteNext();
            mission.ExecuteNext();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 4));
            Assert.AreEqual(drone.Direction, 0);
        }

        [TestMethod]
        public void ExecuteNextTestTwoCommandsShoulBeExecutedNotOtherImpact()
        {
            //Arrange 
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;

            var commands = new List<Command>();
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;
            commands.Add(command);
            command = new Command('>', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;
            commands.Add(command);

            var mission = new Mission(0, commands);
            mission.TerminatedMission += drone.OnTerminatedMission;


            //Act
            mission.ExecuteNext();
            mission.ExecuteNext();
            mission.ExecuteNext();
            mission.ExecuteNext();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 4));
            Assert.AreEqual(drone.Direction, 0);
        }

        [TestMethod]
        public void ExecuteTestTestEventShouldBeRaised()
        {
            //Arrange 
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;

            var commands = new List<Command>();
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;
            commands.Add(command);
            command = new Command('>', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;
            commands.Add(command);

            var mission = new Mission(0, commands);
            mission.TerminatedMission += drone.OnTerminatedMission;
            mission.DroneId = 0;

            List<int> receivedEvents = new List<int>();
            mission.TerminatedMission += delegate(object sender, MissionEventArgs e)
            {
                receivedEvents.Add(e.DroneId);
            };


            //Act
            mission.ExecuteAllCommands();          

            //Assert 
            Assert.AreEqual(1, receivedEvents.Count);
            Assert.AreEqual(0, receivedEvents[0]);
        }       

    }
}
