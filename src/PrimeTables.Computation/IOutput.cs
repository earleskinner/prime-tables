namespace PrimeTables.Computation
{
    using System.Collections.Generic;

    public interface IOutput
    {
        int Multipler { get; set; }

        IEnumerable<long> PrimeNumbers { get; set; }
    }
}