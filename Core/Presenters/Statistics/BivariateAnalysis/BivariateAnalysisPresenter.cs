using Core.Utils.Exceptions;
using Core.Explanations.Statistics;

namespace Core.Presenters.Statistics.BivariateAnalysis;

public class BivariateAnalysisPresenter
{
    private readonly IBivariateAnalysisView _view;

    public BivariateAnalysisPresenter(IBivariateAnalysisView view)
    {
        _view = view;
        _view.CalculateAttempted += OnCalculateAttempted;
        _view.ClearAttempted += OnClearAttempted;
    }

    private void OnCalculateAttempted(object? sender, EventArgs e)
    {
        try
        {
            var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(_view.Scores1, _view.Scores2);

            _view.DisplayResults(
                result.Ranks1,
                result.Ranks2,
                result.Difference,
                result.DifferenceSquared,
                result.SumDifferenceSquared,
                result.Correlation,
                result.CorrelationInterpretation,
                result.Steps
            );
        }
        catch (NullInputException)
        {
            _view.ShowError("Calculation failed: One or both of the data sets are missing or null.");
        }
        catch (ListsNotSameSizeException)
        {
            _view.ShowError("Calculation failed: Both Score rows must have the exact same number of entries.");
        }
        catch (InsufficientDataException)
        {
            _view.ShowError("Calculation failed: You must enter at least two data points.");
        }
        catch (Exception ex)
        {
            _view.ShowError($"An unexpected error occurred: {ex.Message}");
        }
    }

    private void OnClearAttempted(object? sender, EventArgs e)
    {
        _view.ClearDisplay();
    }
}