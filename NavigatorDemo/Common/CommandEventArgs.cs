using System;
using NavigatorDemo.Model;

namespace NavigatorDemo.Common
{
    public class CommandEventArgs: EventArgs 
    {
        public int DroneId { get; set; }
        public Command Command { get; set; }

        public CommandEventArgs(int droneId, Command command)
        {
            DroneId = droneId;
            Command = command;
        }
    }
}
