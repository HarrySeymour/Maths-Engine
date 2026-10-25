namespace Core.Modules.Statistics.Dispersion
{
    public interface IStandardDeviation
    {
        double StandardDeviation { get; }
        double Mean { get; }
        double Variance { get; }
        void Run();
    }
}