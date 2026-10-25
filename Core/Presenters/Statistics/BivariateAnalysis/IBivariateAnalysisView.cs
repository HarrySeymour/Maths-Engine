namespace Core.Presenters.Statistics.BivariateAnalysis;

public interface IBivariateAnalysisView
{
    // Inputs
    List<double> Scores1 { get; }
    List<double> Scores2 { get; }

    // Outputs
    void DisplayResults(
        List<double> ranks1,
        List<double> ranks2,
        List<double> diffs,
        List<double> diffsSquared,
        double sumDiffSquared,
        double coefficient,
        string interpretation,
        string steps);

    void ClearDisplay();
    void ShowError(string message);

    // User Actions
    event EventHandler CalculateAttempted;
    event EventHandler ClearAttempted;
}