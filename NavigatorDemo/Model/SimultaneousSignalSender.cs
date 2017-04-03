using System;
using System.Collections.Generic;
using NavigatorDemo.Interfaces;

namespace NavigatorDemo.Model
{
    public class SimultaneousSignalSender : ISignalSender
    {
        public List<Mission> MissionList { get; set; }

        public void Execute()
        {
            var maxCommandCount = CalculateMaxCommandCount(MissionList);

            for (int j = 0; j < maxCommandCount; j++)
            {
                for (int i = 0; i < MissionList.Count; i++)
                {
                    MissionList[i].ExecuteNext();
                }
            }               
        }

        private int CalculateMaxCommandCount(List<Mission> missions)
        {
            int maxCount = 0;
            foreach (var mission in missions)
            {
                maxCount = Math.Max(mission.Commands.Count, maxCount);
            }
            return maxCount;
        }
    }
}
