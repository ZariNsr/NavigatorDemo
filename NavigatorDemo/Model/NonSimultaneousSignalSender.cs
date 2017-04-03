using NavigatorDemo.Interfaces;
using System.Collections.Generic;

namespace NavigatorDemo.Model
{
    public class NonSimultaneousSignalSender : ISignalSender
    {
        public List<Mission> MissionList { get; set; }

        public void Execute()
        {
            MissionList.ForEach(m => m.ExecuteAllCommands());
        }        
    }
}
