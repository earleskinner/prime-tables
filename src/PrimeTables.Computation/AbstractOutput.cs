namespace PrimeTables.Computation
{
    public abstract class AbstractOutput : IOutput
    {
        public int Multipler { get; set; }

        public long[] PrimeNumbers { get; set; }

        public virtual long[][] CreatePrimeTable()
        {
            if (Multipler == 0 || PrimeNumbers == null || PrimeNumbers.Length < 1)
            {
                return null;
            }

            var table = new long[Multipler][];

            for (var i = 0; i <= Multipler - 1; i++)
            {
                table[i] = new long[PrimeNumbers.Length];
                for (var j = 0; j <= PrimeNumbers.Length - 1; j++)
                {
                    table[i][j] = PrimeNumbers[j] * (i + 1);
                }
            }

            return table;
        }

        public abstract void WritePrimeTable();
    }
}