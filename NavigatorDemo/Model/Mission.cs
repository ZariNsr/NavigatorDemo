using System;
using System.Collections.Generic;
using NavigatorDemo.Common;

namespace NavigatorDemo.Model
{
    public class Mission
    {
        public event EventHandler<MissionEventArgs> TerminatedMission;

        public int Id { get; set; }
        public int DroneId { get; set; }
        public List<Command> Commands { get; set; }
        private int _incrementalCommandId;

        public Mission(int id, List<Command> commands)
        {
            Id = id;
            Commands = commands;
            DroneId = -1;
            _incrementalCommandId = -1;
        }

        public void ExecuteAllCommands()
        {
            for (int i = 0; i < Commands.Count; i++)
            {
                ExecuteCommand(i);
            }   
        }

        public void ExecuteNext()
        {
            if (Commands.Count-1 > _incrementalCommandId++)
            {
                ExecuteCommand(_incrementalCommandId);
            }            
        }

        private void ExecuteCommand(int index)
        {
            Commands[index].BroadcastCommand();
            if (index == Commands.Count - 1)
            {
                BroadcastMissionTermination();
            }
        }

        protected virtual void OnTerminatedMission(MissionEventArgs e)
        {
            EventHandler<MissionEventArgs> handler = TerminatedMission;

            if (handler != null)
            {
                handler(this, e);
            }
        }
     
        public void BroadcastMissionTermination()
        {
            OnTerminatedMission(new MissionEventArgs(DroneId));
        }
    }
}
