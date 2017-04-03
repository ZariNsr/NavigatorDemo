using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigatorDemo.Model;

namespace NavigatorDemoTests
{
    [TestClass]
    public class DroneTest
    {
        [TestMethod]       
        public void DroneConstructorTestIdAssignment()
        {
            //Arrange 
            int droneId = 0;

            //Act
            var drone = new Drone(id: droneId, x: 2, y: 1, direction: 90);
             
            //Assert 
            Assert.AreEqual (drone.Id, droneId);            
        }

        [TestMethod]
        public void DroneConstructorTestXAssignment()
        {
            //Arrange 
            int x = 1;

            //Act
            var drone = new Drone(id: 0, x: x, y: 1, direction: 90);

            //Assert 
            Assert.AreEqual(drone.Position.X, x);
        }

        [TestMethod]
        public void DroneConstructorTestYAssignment()
        {
            //Arrange 
            int y = 3;

            //Act
            var drone = new Drone(id: 0, x: 1, y: y, direction: 90);

            //Assert 
            Assert.AreEqual(drone.Position.Y, y);
        }

        [TestMethod]
        public void DroneConstructorTestDirectionAssignment()
        {
            //Arrange 
            int direction = 180;

            //Act
            var drone = new Drone(id: 0, x: 1, y: 3, direction: direction);

            //Assert 
            Assert.AreEqual(drone.Direction, direction);
        }

        [TestMethod]
        public void DroneConstructorTestColleaguesAssignment()
        {
            //Arrange             

            //Act
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 0);

            //Assert 
            Assert.AreEqual(drone.Colleagues.Count, 0);
        }    

        [TestMethod]
        public void DroneExecuteCommandTestMoveToNorth()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 90);
            var boundry = new MissionBoundary(new Region (0,0,0,5,5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;           

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 4));
        }

        [TestMethod]
        public void DroneExecuteCommandTestMoveToNorthDoesNotChangeDirection()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Direction, 90);
        }

        [TestMethod]
        public void DroneExecuteCommandTestDoesNotMoveNorthAtTheEndOfBoundry()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 5, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();
           
            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 5));
        }

        [TestMethod]
        public void DroneExecuteCommandTestMoveNorthAtTheBeginingOfBoundry()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 0, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 1));
        }

        [TestMethod]
        public void DroneExecuteCommandTestMoveWest()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 180);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(0, 3));
        }

        [TestMethod]
        public void DroneExecuteCommandTestMoveWestDoesNotChangeDirection()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 180);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Direction, 180);
        }

        [TestMethod]
        public void DroneExecuteCommandTestDoesNotMoveWestAtTheBeginingOfBoundry()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 0, y: 2, direction: 180);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(0, 2));
        }

        [TestMethod]
        public void DroneExecuteCommandTestMoveWestAtTheEndOfBoundry()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 5, y: 2, direction: 180);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(4, 2));
        }

        [TestMethod]
        public void DroneExecuteCommandTestMoveEast()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 0);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(2, 3));
        }

        [TestMethod]
        public void DroneExecuteCommandTestMoveEastDoesNotChangeDirection()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 0);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Direction, 0);
        }

        [TestMethod]
        public void DroneExecuteCommandTestDoesNotMoveEastAtTheEndOfBoundry()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 5, y: 1, direction: 0);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(5, 1));
        }

        [TestMethod]
        public void DroneExecuteCommandTestMoveEastAtTheBeginingOfBoundry()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 0, y: 1, direction: 0);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 1));
        }


        [TestMethod]
        public void DroneExecuteCommandTestMoveToSouth()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 270);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 2));
        }

        [TestMethod]
        public void DroneExecuteCommandTestMoveToSouthDoesNotChangeDirection()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 270);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Direction, 270);
        }

        [TestMethod]
        public void DroneExecuteCommandTestDoesNotMoveSouthAtTheEndOfBoundry()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 0, direction: 270);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 0));
        }

        [TestMethod]
        public void DroneExecuteCommandTestMoveSouthAtTheBeginingOfBoundry()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 5, direction: 270);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 4));
        }

        [TestMethod]
        public void DroneExecuteCommandTestRotateToRight()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 4, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('>', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Direction,0);
        }

        [TestMethod]
        public void DroneExecuteCommandTestRotateToRightDoesNotChangePosition()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 4, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('>', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 4));
        }

        [TestMethod]
        public void DroneExecuteCommandTestRotateToLeft()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 4, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('<', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Direction, 180);
        }

        [TestMethod]
        public void DroneExecuteCommandTestRotateToLeftDoesNotChangePosition()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 4, direction: 90);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;
            var command = new Command('<', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 4));
        }

        [TestMethod]
        public void DroneExecuteCommandTestNoMoveIfBoundryIsNotSet()
        {
            //Arrange     
            var drone = new Drone(id: 0, x: 1, y: 3, direction: 90);          
            var command = new Command('*', 0);
            command.BroadcastingSignal += drone.OnBroadcastingSignal;

            //Act
            command.BroadcastCommand();

            //Assert 
            Assert.AreEqual(drone.Position, new Position(1, 3));
        }
    }
}
