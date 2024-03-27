using System.Numerics;

namespace ToyRobotPronamics
{
    public class ToyRobot
    {
        public Vector2 Position => _position;
        public RobotFacingDirection FacingDirection => _faceingDirection;

        private Vector2 _position = new Vector2(0, 0);
        private RobotFacingDirection _faceingDirection;

        public ToyRobot() {
            _position = new Vector2(0, 0);
            _faceingDirection = RobotFacingDirection.North;
            Console.WriteLine("Toy Robot Initiated \n");
        }
        
        public void Move()
        {
            switch (_faceingDirection)
            {
                case RobotFacingDirection.East:
                    _position.X += 1;
                    break;
                case RobotFacingDirection.North:
                    _position.Y += 1;
                    break;
                case RobotFacingDirection.South:
                    _position.Y -= 1;
                    break;
                case RobotFacingDirection.West:
                    _position.X -= 1;
                    break;
            }

            Report();
        }


        public void Place(float x, float y, RobotFacingDirection facingDirection)
        {
            _position = new Vector2(x,y);
            _faceingDirection = facingDirection;
            Report();
        }


        public void Left()
        {
            _faceingDirection = _faceingDirection.Previous();
            Report();
        }

        public void Right()
        {
            _faceingDirection = _faceingDirection.Next();
            Report();
        }


        public void Report()
        {
            Console.WriteLine($"Position (x,y) :  ({_position.X},{_position.Y}) \n Faceing : {_faceingDirection}");
        }

    }
    public static class EnumExtensions
    {
        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");

            T[] values = (T[])Enum.GetValues(src.GetType());
            int currentIndex = Array.IndexOf(values, src);
            int nextIndex = (currentIndex + 1) % values.Length;
            return values[nextIndex];
        }

        public static T Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");

            T[] values = (T[])Enum.GetValues(src.GetType());
            int currentIndex = Array.IndexOf(values, src);
            int previousIndex = (currentIndex - 1 + values.Length) % values.Length;
            return values[previousIndex];
        }
    }


    public enum RobotFacingDirection : long
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,
    }
}
