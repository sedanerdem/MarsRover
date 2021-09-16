using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using marsRover.Validation;
using System.Collections.Generic;
using marsRover.Enums;

namespace marsRover.UnitTest
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void MarsRoverTest1()
        {
            // Arrange
            var upperRight = "5 5";
            var position = "1 2 N";
            var command = "LMLMLMLMM";

            Rover expectedRover = new Rover(1, 3, Direction.N);

            //Act
            Assert.AreEqual(true, new CoordinateValidation(upperRight).IsValid());

            var upperRightValues = upperRight.Split(" ");
            var plateau = new Plateau
            {
                Width = int.Parse(upperRightValues[0]),
                Height = int.Parse(upperRightValues[1]),
                Rovers = new List<Rover>()
            };


            Assert.AreEqual(true, new PositionValidation(position, plateau.Width, plateau.Height).IsValid());
            var positionValues = position.Split(" ");
            Rover rover = new Rover(int.Parse(positionValues[0]), int.Parse(positionValues[1]), (Direction)Enum.Parse(typeof(Direction), positionValues[2]));
            Assert.AreEqual(true, new CommandValidation(command).IsValid());
            rover.Execute(command, plateau);
            plateau.Rovers.Add(rover);

            //Assert
            Assert.AreEqual(rover.AxisX, expectedRover.AxisX);
            Assert.AreEqual(rover.AxisY, expectedRover.AxisY);
            Assert.AreEqual(rover.Direction, expectedRover.Direction);


        }

        [TestMethod]
        public void MarsRoverTest2()
        {
            // Arrange
            var upperRight = "5 5";
            var position = "3 3 E";
            var command = "MMRMMRMRRM";
            Rover expectedRover = new Rover(5, 1, Direction.E);

            //Act
            Assert.AreEqual(true, new CoordinateValidation(upperRight).IsValid());
            var upperRightValues = upperRight.Split(" ");
            var plateau = new Plateau
            {
                Width = int.Parse(upperRightValues[0]),
                Height = int.Parse(upperRightValues[1]),
                Rovers = new List<Rover>()
            };

            Assert.AreEqual(true, new PositionValidation(position, plateau.Width, plateau.Height).IsValid());
            var positionValues = position.Split(" ");
            Rover rover = new Rover(int.Parse(positionValues[0]), int.Parse(positionValues[1]), (Direction)Enum.Parse(typeof(Direction), positionValues[2]));
            Assert.AreEqual(true, new CommandValidation(command).IsValid());
            rover.Execute(command, plateau);
            plateau.Rovers.Add(rover);

            //Assert
            Assert.AreEqual(rover.AxisX, expectedRover.AxisX);
            Assert.AreEqual(rover.AxisY, expectedRover.AxisY);
            Assert.AreEqual(rover.Direction, expectedRover.Direction);
        }
    }
}
