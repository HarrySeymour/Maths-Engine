using Core.Explanations.Pure.PythagorasTheorem;
using Core.Utils.Exceptions;

namespace Core.Presenters.Pure.PythagorasTheorem;

public class PythagorasPresenter
{
    private readonly IPythagorasView _view;

    public PythagorasPresenter(IPythagorasView form)
    {
        _view = form;
        _view.CalculateAttempted += OnCalculateAttempted;
        _view.ClearAttempted += OnClearAttempted;
    }

    private void OnCalculateAttempted(object? sender, EventArgs e)
    {
        // Clear previous output
        _view.Result = string.Empty;
        _view.Steps = string.Empty;

        try
        {
            if (_view.FindHypotenuseChecked)
            {
                var result = PythagorasTheoremTutor.CalculateHypotenuseWithSteps(_view.SideA, _view.SideB);
                _view.Result = $"Hypotenuse: {result.Value:F4}";
                _view.Steps = result.GetStepsAsString();
            }

            else if (_view.FindOtherSideChecked)
            {
                var knownSide = _view.SideA ?? _view.SideB;
                var result = PythagorasTheoremTutor.CalculateOtherSideWithSteps(_view.Hypotenuse, knownSide);
                _view.Result = $"Missing Side: {result.Value:F4}";
                _view.Steps = result.GetStepsAsString();
            }

            else
            {
                _view.ShowError("Please select a calculation mode.");
            }
        }
        catch (NullInputException)
        {
            _view.ShowError("Please fill in all required fields.");
        }
        catch (NegativeSideLengthException)
        {
            _view.ShowError("Side lengths must be positive numbers.");
        }
        catch (HypotenuseNotLongestSideException)
        {
            _view.ShowError("The hypotenuse must be longer than the other side.");
        }
        catch (Exception ex)
        {
            _view.ShowError($"Unexpected error: {ex.Message}");
        }
    }

    private void OnClearAttempted(object? sender, EventArgs e)
    {
        _view.SideA = null;
        _view.SideB = null;
        _view.Hypotenuse = null;

        _view.FindOtherSideChecked = false;
        _view.FindHypotenuseChecked = false;

        _view.Result = string.Empty;
        _view.Steps = string.Empty;
    }
}