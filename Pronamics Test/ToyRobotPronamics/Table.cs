namespace ToyRobotPronamics
{
    public class Table
    {
        public readonly int XSize;
        public readonly int YSize;

        public bool IsMoveValid(float x, float y, RobotFacingDirection robotFacingDirection)
        {
            switch (robotFacingDirection)
            {
                case RobotFacingDirection.East:
                    return x+1 <= XSize;
                case RobotFacingDirection.North:
                    return y + 1 <= YSize;
                case RobotFacingDirection.South:
                    return y - 1 >= 0;
                case RobotFacingDirection.West:
                    return x - 1 >= 0;
                default:
                    throw new ArgumentException($"Out of range no validation for  {robotFacingDirection}");
            }
        }
        public bool IsInTableRange(float  x, float y)
        { 
            
            return x >= 0 && x <= XSize && y >= 0 && y <= YSize;
        }
        public Table(int x, int y) {
            XSize = x;
            YSize = y;
            Console.WriteLine($"Table Created of size {x},{y}");
        }
    }
}
