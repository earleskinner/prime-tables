namespace PrimeTables.Console
{
    using System;
    using System.Text;

    using PrimeTables.Computation;

    public class ConsoleOutput : AbstractOutput
    {
        public override void WritePrimeTable()
        {
            var table = this.CreatePrimeTable();
            var builder = new StringBuilder();

            for (var i = 0; i <= table.Length - 1; i++)
            {
                for (var j = 0; j <= table[i].Length - 1; j++)
                {
                    builder.Append(j == 0 ? "|" : string.Empty);
                    builder.Append($" {table[i][j]} |");
                }
                Console.WriteLine(builder.ToString());
                builder.Clear();
            }
        }
    }
}