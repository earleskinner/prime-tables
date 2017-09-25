namespace PrimeTables.Computation
{
    /// <summary>
    /// The interface for prime number generators
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// The method called when wanting to generate prime numbers
        /// </summary>
        /// <param name="input">
        /// The input interface
        /// </param>
        /// <typeparam name="T">
        /// T must be of type IOutput
        /// </typeparam>
        /// <returns>
        /// Returns the output interface of <see cref="T"/>.
        /// </returns>
        T GeneratePrimeNumbers<T>(IInput input) where T : IOutput;
    }
}