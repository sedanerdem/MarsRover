using System;
using System.Linq;

namespace marsRover.Validation
{
    public class CommandValidation : IValidation
    {
        private readonly string input;

        public CommandValidation(string _input)
        {
            input = _input;
        }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Command is null or empty");
                return false;
            }
                
            var inputValues = input.Split(" ");
            if (inputValues.Length != 1)
            {
                Console.WriteLine("Command length should be 1");
                return false;
            }
                
            char[] commands = { 'L', 'R', 'M' };
            if (!input.All(c => commands.Contains(c)))
            {
                Console.WriteLine("Invalid Movement!");
                return false;
            }
            return true;
        }

    }
}