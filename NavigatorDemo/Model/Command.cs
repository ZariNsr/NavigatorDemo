using NavigatorDemo.Common;
using System;

namespace NavigatorDemo.Model
{
    public class Command
    {
        public event EventHandler<CommandEventArgs> BroadcastingSignal;
        public int Id { get; set; }
        public char Code { get; set; }
        public int DroneId { get; set; }

        public Command(char code, int droneId)
        {
            Code = code;
            DroneId = droneId;
        }

        protected virtual void OnBroadcastingSignal(CommandEventArgs e)
        {
            EventHandler<CommandEventArgs> handler = BroadcastingSignal;
            if (handler != null)
            {
                handler(this, e);
            }
        }   

        public void BroadcastCommand()
        {
            OnBroadcastingSignal(new CommandEventArgs(DroneId, this));
        }       
    }
}
