using NavigatorDemo.Common;
using System;
using System.Collections.Generic;
using NavigatorDemo.Repositories;

namespace NavigatorDemo.Model
{
   
    public class Drone
    {
        public event EventHandler CommandExecuted;

        private static readonly log4net.ILog _loger = log4net.LogManager.GetLogger(typeof(Drone));
        public int Id { get; set; }
        public Position Position { get { return new Position(X, Y); }}
        public int X { get; set; }
        public int Y { get; set; }
        public int Direction { get; set; }
        public MissionBoundary MissionBoundary { get; set; }
        public Dictionary<int,Drone> Colleagues { get; set; }
        private const string _outputFilePath = "Output.txt";
        private const int _maxDegree = 360;

        public Drone(int id, int x, int y, int direction)
        {
            Id = id;
            X = x;
            Y = y;
            Direction = direction;
            Colleagues = new Dictionary<int, Drone>();
            MissionBoundary = new MissionBoundary(0,0,0,0);
        }

        protected virtual void OnCommandExecuted(EventArgs e)
        {
            EventHandler handler = CommandExecuted;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void BroadcastEndOfCommand()
        {
            OnCommandExecuted(EventArgs.Empty);
        }

        public void OnCommandExecuted(object sender, EventArgs e)
        {
            try
            {
                var drone = sender as Drone;
                if (!Colleagues.ContainsKey(drone.Id))
                {
                    Colleagues.Add(drone.Id, drone);
                }   
            }
            catch (Exception ex)
            { 
                var msg = string.Format("{0}: OnCommandExecuted {1}", this.GetType().Name, ex.Message);
                _loger.Error(msg);                
            }                        
        }

        public void OnBroadcastingSignal(object sender, CommandEventArgs e)
        {            
            ExecuteCommand(e.Command);
        }

        public void OnTerminatedMission(object sender, MissionEventArgs e)
        {
            try
            {
                var writer = new FileIO(_outputFilePath);
                writer.Write(string.Format("{0} {1} {2}", X, Y, Direction.ToDirection()));  
            }
            catch (Exception ex)
            {
                var msg = string.Format("{0}: OnTerminatedMission {1}", this.GetType().Name, ex.Message);
                _loger.Error(msg);
            }                     
        }

        private int GetMovementForX(int oldDir)
        {
            return Direction == oldDir ? (int)Math.Cos(Direction.DegreeToRadian()) : 0;
        }
        private int GetMovementForY(int oldDir)
        {
            return Direction == oldDir ? (int)Math.Sin(Direction.DegreeToRadian()) : 0;
        }

        private Position GetNextPoition(int oldDir)
        {
            var destination = new Position(X, Y);
            destination.X += GetMovementForX(oldDir);
            destination.Y += GetMovementForY(oldDir);
            return destination;
        }

        private int GetNextDirection(char code)
        {
            var oldDir = Direction;
            var newDir = (Direction + code.ToAngle()) % _maxDegree;

            return newDir - oldDir;
        }
  
        private void ExecuteCommand(Command command)
        {
            int oldDir = Direction;
            Direction += GetNextDirection(command.Code); 
            var destination = GetNextPoition(oldDir);

            if (!IsThereAnyRiskToMoveToGivenPosition(destination))
            {
                X = destination.X;
                Y = destination.Y;
            }           
            BroadcastEndOfCommand();
        }      

        private bool IsThereAnyRiskToMoveToGivenPosition(Position point)
        {
            return CheckMissionBoundry(point) || CheckRiskOfAccident(point);
        }

        private bool CheckMissionBoundry(Position point)
        {
            var res = point.X > MissionBoundary.MaxX ||
                point.Y > MissionBoundary.MaxY ||
                point.X < MissionBoundary.MinX ||
                point.Y < MissionBoundary.MinX;

            if (res )
            {
                var msg = string.Format("{0}: CheckMissionBoundry: Flight has been rejected, because it was out of the mission boundary", 
                    this.GetType().Name);
                _loger.Error(msg);
            }
            return res;
        }

        private bool CheckRiskOfAccident(Position point)
        {
            try
            {
                var risk = false;
                foreach (var colleague in Colleagues)
                {
                    if (colleague.Value.Position.Equals(point))
                    {
                        risk = true;
                    }
                }
                if (risk)
                {
                    var msg = string.Format("{0}: CheckRiskOfAccident: Flight has been rejected, because there was risk of an accident.",
                        this.GetType().Name);
                    _loger.Error(msg);
                }
                return risk;
            }
            catch (Exception ex)
            {
                var msg = string.Format("{0}: OnTerminatedMission {1}", this.GetType().Name, ex.Message);
                _loger.Error(msg);
                return true;
            }            
        }         
    }   
}
