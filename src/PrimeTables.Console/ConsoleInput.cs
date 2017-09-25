namespace PrimeTables.Console
{
    using System;
    using System.Collections.Generic;

    using PrimeTables.Computation;

    /// <inheritdoc />
    /// <summary>
    /// Takes the input from the console application
    /// </summary>
    public class ConsoleInput : IInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleInput"/> class.
        /// </summary>
        /// <param name="args">
        /// The console arguments
        /// </param>
        /// <exception cref="ArgumentException">
        /// The number of arguments must be 1
        /// The argument must be a integer and not a decimal
        /// The argument must be greater than 0
        /// The argument must be less than 2,147,483,647
        /// </exception>
        public ConsoleInput(IReadOnlyList<string> args)
        {
            if (args.Count != 1)
            {
                throw new ArgumentException("Invalid arguments Example: > pt.exe [number]");
            }

            if (!int.TryParse(args[0], out var upperBound))
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

            this.UpperBound = upperBound + 1;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the upper bound
        /// </summary>
        public int UpperBound { get; set;  }
    }
}