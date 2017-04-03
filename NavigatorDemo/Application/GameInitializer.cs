using System.Collections.Generic;
using NavigatorDemo.Model;
using NavigatorDemo.Interfaces;

namespace NavigatorDemo.Application
{
    public class GameInitializer : IGameInitializer
    {
        private IRegionRepository _regionRepo;
        private IDroneRepository _droneRepo;
        private IMissionRepository _missionRepo;
        private ISignalSender _signalSender;

        public GameInitializer(IRegionRepository regionRepo, 
            IDroneRepository droneRepo,
            IMissionRepository missionRepo,
            ISignalSender signalSender)          
        {
            _regionRepo = regionRepo;
            _droneRepo = droneRepo;
            _missionRepo = missionRepo;
            _signalSender = signalSender;
        }

        public void Initialize()
        {           
            var battlefield = _regionRepo.GetRegion();         
            var droneList = _droneRepo.GetDroneList();           
            var missionList = _missionRepo.GetMissionList();

            SetMissionBoundaryForAllDrones(battlefield, droneList);
            SubscribeObjectModelsToReleventEvent(droneList, missionList);
         
            _signalSender.MissionList = missionList;
            _signalSender.Execute();
        }  

        private void SetMissionBoundaryForAllDrones(Region field ,List<Drone> droneList)
        {
            MissionBoundary boundry = new MissionBoundary(field);
            droneList.ForEach(d => d.MissionBoundary = boundry);          
        }

        private void SubscribeObjectModelsToReleventEvent(List<Drone> droneList, List<Mission> missionList)
        {
            SubscribeDronesToListeneToBroadcastedCommands(droneList, missionList);
            SubscribeDronesToListeneToOtherDrones(droneList);
        }

        private void SubscribeDronesToListeneToBroadcastedCommands(List<Drone> droneList, List<Mission> missions)
        {           
            foreach (var mission in missions)
            {
                mission.Commands.ForEach(m => SubscribeDronesToBroadcastingSignalEventListener(droneList, m));  
                SubscribeDronesToTerminatedMissionEventListener(droneList, mission);
            }
        }

        private void SubscribeDronesToListeneToOtherDrones(List<Drone> droneList)
        {
            for (int i = 0; i < droneList.Count; i++)
            {
                for (int j = 0; j < droneList.Count; j++)
                {
                    if (droneList[j].Id != droneList[i].Id)
                    {
                        droneList[i].CommandExecuted += droneList[j].OnCommandExecuted;
                    }
                }
            }
        }

        private void SubscribeDronesToBroadcastingSignalEventListener(List<Drone> droneList, Command command)
        {           
            foreach (var drone in droneList)
            {
                if (drone.Id == command.DroneId)
                {
                    command.BroadcastingSignal += drone.OnBroadcastingSignal;                  
                }               
            }            
        }

        private void SubscribeDronesToTerminatedMissionEventListener(List<Drone> droneList, Mission mission)
        {
            foreach (var drone in droneList)
            {
                if (drone.Id == mission.DroneId)
                {
                    mission.TerminatedMission += drone.OnTerminatedMission;
                }
            }
        }    
    }
}
