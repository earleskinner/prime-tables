namespace PrimeTables.Computation
{
    using System.Collections.Generic;

    /// <summary>
    /// The interface for output
    /// </summary>
    public interface IOutput
    {
        /// <summary>
        /// Gets or sets the multipler
        /// </summary>
        int Multipler { get; set; }

        /// <summary>
        /// Gets or sets the list of prime numbers
        /// </summary>
        IEnumerable<long> PrimeNumbers { get; set; }
    }
}