using marsRover.Enums;
using marsRover.Validation;
using System;
using System.Collections.Generic;

namespace marsRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region input
            Console.WriteLine("Test Input:");
            var upperRight = "5 5";

            //rover1
            var position1 = "1 2 N";
            var command1 = "LMLMLMLMM";
            //rover2
            var position2 = "3 3 E";
            var command2 = "MMRMMRMRRM";

            Console.WriteLine(upperRight + "\n" + position1 + "\n" + command1 + "\n" + position2 + "\n" + command2);
            #endregion input
            #region plateau
            if (!new CoordinateValidation(upperRight).IsValid())
                return;
            var upperRightValues = upperRight.Split(" ");
            var plateau = new Plateau
            {
                Width = int.Parse(upperRightValues[0]),
                Height = int.Parse(upperRightValues[1]),
                Rovers = new List<Rover>()
            };
            #endregion plateau
            #region rover1
            if (!new PositionValidation(position1, plateau.Width, plateau.Height).IsValid())
                return;

            var positionValues1 = position1.Split(" ");
            var rover1 = new Rover(int.Parse(positionValues1[0]), int.Parse(positionValues1[1]), (Direction)Enum.Parse(typeof(Direction), positionValues1[2]));

            if (!new CommandValidation(command1).IsValid())
                return;

            rover1.Execute(command1, plateau);
            plateau.Rovers.Add(rover1);
            #endregion rover1
            #region rover2
            if (!new PositionValidation(position2, plateau.Width, plateau.Height).IsValid())
                return;

            var positionValues2 = position2.Split(" ");
            var rover2 = new Rover(int.Parse(positionValues2[0]), int.Parse(positionValues2[1]), (Direction)Enum.Parse(typeof(Direction), positionValues2[2]));
            if (!new CommandValidation(command2).IsValid())
                return;

            rover2.Execute(command2, plateau);
            plateau.Rovers.Add(rover2);
            #endregion rover2
            #region output
            Console.WriteLine("Output:");
            foreach (var item in plateau.Rovers)
            {
                Console.WriteLine(item.AxisX + " " + item.AxisY + " " + item.Direction);
            }
            #endregion output
        }
    }
}
