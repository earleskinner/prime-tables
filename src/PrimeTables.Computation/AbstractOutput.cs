namespace PrimeTables.Computation
{
    using System.Collections.Generic;

    /// <inheritdoc />
    /// <summary>
    /// The output abstraction to force the <see cref="M:PrimeTables.Computation.AbstractOutput.WritePrimeTable" /> method implementation
    /// </summary>
    public abstract class AbstractOutput : IOutput
    {
        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the multipler
        /// </summary>
        public int Multipler { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Gets or sets the list of prime numbers
        /// </summary>
        public IEnumerable<long> PrimeNumbers { get; set; }

        /// <summary>
        /// Write the prime table
        /// </summary>
        public abstract void WritePrimeTable();
    }
}