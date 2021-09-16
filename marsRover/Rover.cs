using marsRover.Enums;
using System;

namespace marsRover
{
    public class Rover
    {
        public int AxisX { get; set; }
        public int AxisY { get; set; }
        public Direction Direction { get; set; }

        public Rover(int _axisX, int _axisY, Direction _direction)
        {
            AxisX = _axisX;
            AxisY = _axisY;
            Direction = _direction;
        }

        private void Left()
        {
            Direction = Direction switch
            {
                Direction.N => Direction.W,
                Direction.W => Direction.S,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        private void Right()
        {
            Direction = Direction switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        private void Move(int Width, int Height)
        {
            switch (Direction)
            {
                case Direction.N:
                    if (AxisY + 1 <= Height)
                        AxisY++;
                    else
                        Console.WriteLine("The rover cannot out of the plateau!");
                    break;
                case Direction.E:
                    if (AxisX + 1 <= Width)
                        AxisX++;
                    else
                        Console.WriteLine("The rover cannot out of the plateau!");
                    break;
                case Direction.S:
                    if (AxisY - 1 >= 0)
                        AxisY--;
                    else
                        Console.WriteLine("The rover cannot out of the plateau!");
                    break;
                case Direction.W:
                    if (AxisX - 1 >= 0)
                        AxisX--;
                    else
                        Console.WriteLine("The rover cannot out of the plateau!");
                    break;
            }
        }

        public void Execute(string command, Plateau plateau)
        {
            foreach (var c in command)
            {
                switch (c)
                {
                    case 'L':
                        Left();
                        break;
                    case 'R':
                        Right();
                        break;
                    case 'M':
                        Move(plateau.Width, plateau.Height);
                        break;
                }
            }
        }
    }
}