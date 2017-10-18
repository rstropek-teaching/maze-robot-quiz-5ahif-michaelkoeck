using Maze.Library;
using System.Collections.Generic;
using System.Drawing;

namespace Maze.Solver
{
    /// <summary>
    /// Moves a robot from its current position towards the exit of the maze
    /// </summary>
    public class RobotController
    {
        private IRobot robot;
        private List<Point> alreadyVisited = new List<Point>();
        bool end = false;
        /// <summary>
        /// Initializes a new instance of the <see cref="RobotController"/> class
        /// </summary>
        /// <param name="robot">Robot that is controlled</param>
        public RobotController(IRobot robot)
        {
            // Store robot for later use
            this.robot = robot;
        }

        /// <summary>
        /// Moves the robot to the exit
        /// </summary>
        /// <remarks>
        /// This function uses methods of the robot that was passed into this class'
        /// constructor. It has to move the robot until the robot's event
        /// <see cref="IRobot.ReachedExit"/> is fired. If the algorithm finds out that
        /// the exit is not reachable, it has to call <see cref="IRobot.HaltAndCatchFire"/>
        /// and exit.
        /// </remarks>
        public void MoveRobotToExit()
        {
            // Here you have to add your code

            // Trivial sample algorithm that can just move right
            
            int xCoord = 0;
            int yCoord = 0; 

            robot.ReachedExit += (_, __) => end = true;
            this.recursiveMethode(xCoord, yCoord);

        


        }

        public void recursiveMethode(int x, int y)
        {
           
                if (this.alreadyVisited.Contains(new Point(x, y)) == false && this.end == false)
                {
                    this.alreadyVisited.Add(new Point(x, y));

                    if (this.end == false && this.robot.TryMove(Direction.Up) == true )
                    {
                    this.recursiveMethode(x, y - 1);
                        if (this.end == false)
                        {
                        this.robot.Move(Direction.Down);
                        }
                    }
                    if (this.end == false && this.robot.TryMove(Direction.Down) == true)
                {
                    this.recursiveMethode(x, y + 1);
                        if (this.end == false)
                        {
                        this.robot.Move(Direction.Up);
                        }
                    }
                    if (this.end == false && this.robot.TryMove(Direction.Right) == true)
                {
                    this.recursiveMethode(x + 1, y);
                        if (end == false)
                        {
                        this.robot.Move(Direction.Left);
                        }
                    }
                    if (this.end == false && this.robot.TryMove(Direction.Left) == true)
                {
                    this.recursiveMethode(x - 1, y);
                        if (this.end == false)
                        {
                        this.robot.Move(Direction.Right);
                        }
                    }
                }
           

        }
    }
}
