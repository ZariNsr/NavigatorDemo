
namespace NavigatorDemo.Model
{
    public class MissionBoundary
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public int MinX { get; set; }
        public int MinY { get; set; }
      
        public MissionBoundary(Region rect)
        {
            MinX = rect.X;
            MinY = rect.Y; 
            MaxX = rect.X + rect.Width;
            MaxY = rect.X + rect.Height;         
        }

        public MissionBoundary(int minX, int minY, int maxX, int maxY)
        {
            MinX = minX;
            MinY = minY; 
            MaxX = maxX;
            MaxY = maxY;
        }     
    }
}
