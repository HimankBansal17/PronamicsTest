namespace ToyRobotPronamics
{
    public class Setup
    {
        public ToyRobot ToyRobot;
        public Table Table;

        public Setup(int x, int y)
        {

            Table = new Table(x, y);
            ToyRobot = new ToyRobot();
        }


        public void StartProgram()
        {
            LoadInstructions();
            ConsoleKeyInfo input;
            do
            {
                input = Console.ReadKey();
                Console.WriteLine("\n");
                PerformAction(input.Key);
                

            } while (input.Key != ConsoleKey.Escape);
        }

        public void PerformAction(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.A:
                    ToyRobot.Left();
                    break;
                case ConsoleKey.D:
                    ToyRobot.Right();
                    break;
                case ConsoleKey.Spacebar:
                    if (Table.IsMoveValid(ToyRobot.Position.X, ToyRobot.Position.Y, ToyRobot.FacingDirection))
                    {
                        ToyRobot.Move();
                    }
                    else
                    {
                        Console.WriteLine("Robot cannot go out of table");
                    }
                    break;
                case ConsoleKey.P:
                    Console.WriteLine("Please enter x,y,F  position and direction sepeareted by ,  to move to:");
                    var xyPos = Console.ReadLine();
                    var xyPostSPlit = xyPos.Split(',');
                    PerformRobotPlace(xyPostSPlit);

                    break;
                case ConsoleKey.R:
                    ToyRobot.Report();
                    break;
                case ConsoleKey.C:
                    Console.Clear();

                    LoadInstructions();
                    break;

            }
        }

        public void PerformRobotPlace(string[] xyPostSPlit)
        {
            if (int.TryParse(xyPostSPlit[0], out var x) && int.TryParse(xyPostSPlit[1], out int y) && int.TryParse(xyPostSPlit[2], out var face))
            {
                if (Table.IsInTableRange(x,y))
                {
                    ToyRobot.Place(x,
                          y,
                          (RobotFacingDirection)face);
                }
                else
                {
                    Console.WriteLine("Robot cannot go out of table");
                }

            }
            else
            {
                Console.WriteLine("Invalid Input please input data as requested");
            }
       
            
        }

        public void LoadInstructions()
        {
            Console.WriteLine(@$"
Table Size ({Table.XSize}, {Table.YSize})
Please Enter following keys  to perform actions:
Move -> SpaceBar 
Left -> A
Right -> D
Report -> R
Place -> P
ClearScreen -> C

For  Facing values enter
North -> 0
East -> 1
South -> 2
West -> 3

");
        }

    }
}
