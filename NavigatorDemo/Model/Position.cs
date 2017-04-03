
namespace NavigatorDemo.Model
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var pos = obj as Position;

            if (pos == null)
                return false;

            if ((pos.X != X) || (pos.Y != Y))
                return false;

            return true;
        }
    }
}
