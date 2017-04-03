using System;

namespace NavigatorDemo.Common
{
    public class MissionEventArgs: EventArgs 
    {
        public int DroneId { get; set; }
      
        public MissionEventArgs(int droneId)
        {
            DroneId = droneId;          
        }
    }
}
