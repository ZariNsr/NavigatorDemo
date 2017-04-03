using NavigatorDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigatorDemo.Interfaces
{
    public interface IDroneRepository
    {
        List<Drone> GetDroneList();
    }
}
