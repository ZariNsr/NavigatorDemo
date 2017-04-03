using NavigatorDemo.Model;
using System.Collections.Generic;

namespace NavigatorDemo.Interfaces
{
    public interface IMissionRepository
    {
        List<Mission> GetMissionList();
    }
}
