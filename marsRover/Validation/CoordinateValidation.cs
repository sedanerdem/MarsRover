using System;

namespace marsRover.Validation
{
    public class CoordinateValidation : IValidation
    {
        private readonly string input;

        public CoordinateValidation(string _input)
        {
            input = _input;
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Coordinate is null or empty");
                return false;
            }

            var inputValues = input.Split(" ");

            if (inputValues.Length != 2)
            {
                Console.WriteLine("Coordinate length should be 2");
                return false;
            }
                
            foreach (string value in inputValues)
            {
                var isParseable = int.TryParse(value, out int number);
                if (isParseable == false)
                {
                    Console.WriteLine("Invalid Coordinate!");
                    return false;
                }

                if (number <= 0)
                {
                    Console.WriteLine("Coordinate must be greater than zero!");
                    return false;
                }
            }
            return true;

        }
    }
}