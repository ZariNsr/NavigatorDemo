using NavigatorDemo.Interfaces;
using NavigatorDemo.Model;
using System;
using System.Collections.Generic;

namespace NavigatorDemo.Repositories
{
    public class MissionRepository : BaseEntityRepository, IMissionRepository
    {
        private static readonly log4net.ILog _loger = log4net.LogManager.GetLogger(typeof(MissionRepository));
        private static int incrementalMissionId = 0;
        private const int _missionInfoIndex = 2;
        private const int _missionInfoInterval = 2;

        public MissionRepository(IInputOutput fileIO)
            : base(fileIO)
        {
        }

        public List<Mission> GetMissionList()
        {
            var missionList = new List<Mission>();
            for (var i = _missionInfoIndex; i < InputText.Count; i = i + _missionInfoInterval)
            {
                var mission = CreateMission(InputText[i], incrementalMissionId++);
                missionList.Add(mission);
            }

            return missionList;
        }

        private Mission CreateMission(string commandsInfo, int id)
        {
            List<Command> commands = new List<Command>();

            if (string.IsNullOrEmpty(commandsInfo))
            {
                var msg = string.Format("{0}: Input text does not contain any command for drone number {1}.", this.GetType().Name, id);
                _loger.Warn(msg);    
            }

            for (var i = 0; i < commandsInfo.Length; i++)
            {
                var regionInfo = commandsInfo[i];
                regionInfo.DoValidation();
                Command command = new Command(commandsInfo[i], id);            
                commands.Add(command);

            }

            var mission = new Mission(id, commands);
            mission.DroneId = id;
            return mission;
        }
    }
}
