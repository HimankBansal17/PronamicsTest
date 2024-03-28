using ToyRobotPronamics;

namespace RobotoTests
{
    public class RobotTest
    {   
        private Setup setup;
        
        [SetUp]
        public void Setup()
        {
            setup = new Setup(10, 10);
        }

        [Test]
        
        public void TestValidMove()
        {
            setup.PerformAction(ConsoleKey.Spacebar); //Move the robot in default direction
            Assert.That(setup.ToyRobot.Position.X == 0);
            Assert.That(setup.ToyRobot.Position.Y == 1);
        }

        [Test]
        public void TestInvalidMove()
        {
            setup.PerformAction(ConsoleKey.A);
            setup.PerformAction(ConsoleKey.A);
            setup.PerformAction(ConsoleKey.Spacebar);

            Assert.That(setup.ToyRobot.FacingDirection == RobotFacingDirection.South);
            Assert.That(setup.ToyRobot.Position.X == 0);
            Assert.That(setup.ToyRobot.Position.Y == 0);
        }



        [Test]
        [TestCase(1, 1,"North")]
        [TestCase(1, 10, "East")]
        [TestCase(10, 10, "East")]
        [TestCase(10, 1, "East")]
        [TestCase(5, 5, "East")]
        public void TestValidPlace(float toPlaceX, float toPlaceY, string robotFacingDirection)
        {
            setup.PerformRobotPlace(new string[] {toPlaceX.ToString(),
                                                toPlaceY.ToString(), robotFacingDirection.ToString()});

            Assert.That(setup.ToyRobot.Position.X == toPlaceX);
            Assert.That(setup.ToyRobot.Position.Y == toPlaceY);

        }

        [Test]
        [TestCase(1, -1, 0)]
        [TestCase(-1, -1, 0)]
        [TestCase(11, 1, 0)]
        [TestCase(11, 11, 0)]
        [TestCase(10, 11, 0)]
        public void TestInvalidPlace(float toPlaceX, float toPlaceY, int robotFacingDirection)
        {
            setup.PerformRobotPlace(new string[] {toPlaceX.ToString(),
                                                toPlaceY.ToString(), robotFacingDirection.ToString()});

            Assert.That(setup.ToyRobot.Position.X == 0);
            Assert.That(setup.ToyRobot.Position.Y == 0);
            Assert.That(setup.ToyRobot.FacingDirection == RobotFacingDirection.North);


        }


        [Test]
        [TestCase("a","1","1")]
        [TestCase("a", "b", "1")]
        [TestCase("a", "b", "c")]
        [TestCase("1", "b", "c")]

        public void TestInvalidPlace(string toPlaceX, string toPlaceY, string robotFacingDirection)
        {
            setup.PerformRobotPlace(new string[] { toPlaceX, toPlaceY, robotFacingDirection });
            Assert.That(setup.ToyRobot.Position.X == 0);
            Assert.That(setup.ToyRobot.Position.Y == 0);
            Assert.That(setup.ToyRobot.FacingDirection == RobotFacingDirection.North);


        }
    }
}