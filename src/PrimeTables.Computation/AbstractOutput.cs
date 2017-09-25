namespace PrimeTables.Computation
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class AbstractOutput : IOutput
    {
        public int Multipler { get; set; }

        public IEnumerable<long> PrimeNumbers { get; set; }

        public abstract void WritePrimeTable();
    }
}