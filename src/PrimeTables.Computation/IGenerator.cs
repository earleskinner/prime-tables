namespace PrimeTables.Computation
{
    public interface IGenerator
    {
        T GeneratePrimeNumbers<T>(IInput input)
            where T : IOutput;
    }
}