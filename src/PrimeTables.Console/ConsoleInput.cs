namespace PrimeTables.Console
{
    using System;

    public class ConsoleInput
    {
        public ConsoleInput(string[] args)
        {
            if (args.Length != 1)
            {
                throw new ArgumentException("Invalid arguments Example: > pt [number]");
            }

            int upperBound;
            if (!int.TryParse(args[0], out upperBound))
            {
                throw new ArgumentException("Please ensure [number] is an integer. Example: 100");
            }

            if (upperBound < 1)
            {
                throw new ArgumentException("Please ensure [number] is greater than 1. Example: 100");
            }

            if (upperBound >= int.MaxValue)
            {
                throw new ArgumentException($"Please ensure [number] is less than {int.MaxValue}. Example: 100");
            }

            UpperBound = upperBound;
        }

        public int UpperBound { get; }
    }
}