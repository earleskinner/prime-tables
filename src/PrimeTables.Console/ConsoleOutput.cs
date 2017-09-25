namespace PrimeTables.Console
{
    using System;
    using System.Text;

    using PrimeTables.Computation;

    /// <inheritdoc />
    /// <summary>
    /// Output a prime table to the console
    /// </summary>
    public class ConsoleOutput : AbstractOutput
    {
        /// <inheritdoc />
        /// <summary>
        /// The write prime table
        /// </summary>
        public override void WritePrimeTable()
        {
            var builder = new StringBuilder();

            for (var i = 1; i <= this.Multipler; i++)
            {
                var j = 0;
                foreach (var prime in this.PrimeNumbers)
                {
                    builder.Append(j == 0 ? "|" : string.Empty);
                    builder.Append($" {prime * i} |");
                    j++;
                }
                Console.WriteLine(builder.ToString());
                builder.Clear();
            }
        }
    }
}