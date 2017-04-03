using Microsoft.VisualStudio.TestTools.UnitTesting;
using NavigatorDemo.Model;
using System.Collections.Generic;

namespace NavigatorDemoTests
{
    [TestClass]
    public abstract class BaseSignalSenderTest
    {
        // FirstDrone and SecondDrone paths cross
        protected Drone FirstDrone { get; set; }
        protected Drone SecondDrone { get; set; }        

        // ThirdDrone and FourthDrone paths dont cross
        protected Drone ThirdDrone { get; set; }
        protected Drone FourthDrone { get; set; }

        protected List<Mission> Missions { get; set; }     
       

        [TestInitialize]
        public void Setup()
        {
            Missions = new List<Mission>();
            //********************** FirstDrone **********************************           
            FirstDrone = CreateDrone(0, 1, 1, 0, new char[] { '*', '*', '*' });
           

            //********************** SecondDrone *********************************
            SecondDrone = CreateDrone(1, 4, 1, 180, new char[] { '*', '*', '*' });
             

            //********************** ThirdDrone *********************************
            ThirdDrone = CreateDrone(2, 1, 2, 90, new char[] { '*', '<' });
           

            ////********************** FourthDrone ******************************
            FourthDrone = CreateDrone(3, 5, 5, 180, new char[] { '*', '*' });


            // FirstDrone and SecondDrone are listening to eachothers
            FirstDrone.CommandExecuted += SecondDrone.OnCommandExecuted;
            SecondDrone.CommandExecuted += FirstDrone.OnCommandExecuted;

            // ThirdDrone and FourthDrone are listening to eachothers
            ThirdDrone.CommandExecuted += FourthDrone.OnCommandExecuted;
            FourthDrone.CommandExecuted += ThirdDrone.OnCommandExecuted;
        }

        private Drone CreateDrone(int id ,int x, int y, int direction, char[] cmds)
        {
            // drone creation
            var drone = new Drone(id: id, x: x, y: y, direction: direction);
            var boundry = new MissionBoundary(new Region(0, 0, 0, 5, 5));
            drone.MissionBoundary = boundry;

            // command creation
            var commandList = new List<Command>();

            foreach (var cmd in cmds)
            {
                var command = new Command(cmd, id);
                command.BroadcastingSignal += drone.OnBroadcastingSignal;
                commandList.Add(command);
            }         

            // mission creation
            var firstMission = new Mission(0,commandList);
            firstMission.TerminatedMission += drone.OnTerminatedMission;

            Missions.Add(firstMission);

            return drone;
        }
      
    }
}


