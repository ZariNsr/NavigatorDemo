using NavigatorDemo.Model;
using System.Collections.Generic;

namespace NavigatorDemo.Interfaces
{
    public interface ISignalSender
    {
        List<Mission> MissionList { get; set; }       
        void Execute();
    }
}
