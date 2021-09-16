using System;
using System.Linq;

namespace marsRover.Validation
{
    public class PositionValidation : IValidation
    {
        private readonly string input;
        private readonly int width;
        private readonly int height;

        public PositionValidation(string _input, int _width, int _height)
        {
            input = _input;
            width = _width;
            height = _height;
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Position is null or empty");
                return false;
            }

            var inputValues = input.Split(" ");
            if (inputValues.Length != 3)
            {
                Console.WriteLine("Position length should be 3");
                return false;
            }

            for (int i = 0; i < 2; i++)
            {
                var isParseable = int.TryParse(inputValues[i], out int number);
                if (isParseable == false)
                {
                    Console.WriteLine("Invalid Position!");
                    return false;
                }
            }

            if (int.Parse(inputValues[0]) > width || int.Parse(inputValues[0]) < 0)
            {
                Console.WriteLine("Starting position must be inside the plateau!");
                return false;
            }
            
            if (int.Parse(inputValues[1]) > height || int.Parse(inputValues[1]) < 0)
            {
                Console.WriteLine("Starting position must be inside the plateau!");
                return false;
            }
            
            string[] directions = { "N", "E", "S", "W" };
            if (!directions.Contains(inputValues[2]))
            {
                Console.WriteLine("Invalid Directions!");
                return false;
            }
            return true;

        }
    }
}