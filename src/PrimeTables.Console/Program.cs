namespace PrimeTables.Console
{
    using PrimeTables.Computation;

    using Console = System.Console;

    /// <summary>
    /// The console to generate prime tables
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main program execution path
        /// </summary>
        /// <param name="args">
        /// The arguments supplied
        /// </param>
        public static void Main(string[] args)
        {
            var input = new ConsoleInput(args);
            var generator = new SieveOfEratosthenes();

            Console.WriteLine("Generating prime numbers...");

            var output = generator.GeneratePrimeNumbers<ConsoleOutput>(input);
            output.WritePrimeTable();

            Console.WriteLine("Please any key to quit");
            Console.ReadKey();
        }
    }
}
