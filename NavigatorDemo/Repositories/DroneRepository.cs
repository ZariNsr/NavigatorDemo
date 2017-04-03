using System.Collections.Generic;
using System.Linq;
using NavigatorDemo.Model;
using System;
using NavigatorDemo.Interfaces;

namespace NavigatorDemo.Repositories
{
    public class DroneRepository : BaseEntityRepository, IDroneRepository
    {
        private static int incrementalDroneId = 0;
        private const int _dronInfoIndex = 1;      
        private const int _dronInfoInterval = 2;       

        public DroneRepository(IInputOutput fileIO)
            : base(fileIO)
        {            
        }

        public List<Drone> GetDroneList()
        {
            var list = new List<Drone>();
            for (var i = _dronInfoIndex; i < InputText.Count; i = i + _dronInfoInterval)
            {
                var drone = CreateDrone(InputText[i]);
                list.Add(drone);
            }
            return list;
        }

        private Drone CreateDrone(string droneInfo)
        {
            if (string.IsNullOrEmpty(droneInfo))
            {
                var msg = string.Format("{0}: Input text to create a drone is null or empty, application is not able to create the drone.", this.GetType().Name);
                throw new ArgumentNullException(msg);               
            }

            int x;
            int y;
            int direction;
            var info = droneInfo.Split(' ');

            DoValidation(info, 3, "drone");

            int.TryParse(info[0], out x);
            int.TryParse(info[1], out y);
            direction = info[2].ToAngle();
            var drone = new Drone(incrementalDroneId++, x, y, direction); 
 
            return drone;
        }     
    }
}
