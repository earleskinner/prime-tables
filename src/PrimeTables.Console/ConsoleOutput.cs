namespace PrimeTables.Console
{
    using System;
    using System.Linq;
    using System.Text;

    using PrimeTables.Computation;

    public class ConsoleOutput : AbstractOutput
    {
        public override void WritePrimeTable()
        {
            var builder = new StringBuilder();

            for (var i = 1; i <= Multipler; i++)
            {
                var j = 0;
                foreach (var prime in PrimeNumbers)
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