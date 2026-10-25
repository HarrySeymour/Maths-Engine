using Core.Explanations.Pure.Trigonometry;
using Core.Modules.Pure.Trigonometry;

namespace Core.Presenters.Pure.Trigonometry;

public class TrigonometryPresenter
{
    private readonly ITrigonometryView _view;

    public TrigonometryPresenter(ITrigonometryView view)
    {
        _view = view;
        _view.CalculateAttempted += OnCalculateAttempted;
        _view.ClearAttempted += OnClearAttempted;
    }

    private void OnCalculateAttempted(object? sender, EventArgs e)
    {
        _view.Result = string.Empty;
        _view.Steps = string.Empty;

        try
        {
            if (_view.CheckValidCalculationChecked)
            {
                if (_view.Hypotenuse.HasValue && _view.Opposite.HasValue && _view.Adjacent.HasValue && _view.Angle.HasValue)
                {
                    var result = TrigonometryTutor.IsValidTriangleWithSteps(_view.Hypotenuse.Value, _view.Opposite.Value,
                        _view.Adjacent.Value, _view.Angle.Value);
                    _view.Result = Convert.ToString(result.IsValid);
                    _view.Steps = result.Steps;
                    return;
                }
                else
                {
                    _view.ShowError("Please fill in all fields for verification.");
                    return;
                }
            }

            if (_view.FindMissingAngleChecked)
            {
                if (_view.Hypotenuse.HasValue && _view.Opposite.HasValue && !_view.Adjacent.HasValue)
                {
                    var result = TrigonometryTutor.CalculateMissingAngleWithSteps(_view.Hypotenuse, SideType.Hypotenuse,
                        _view.Opposite, SideType.Opposite);
                    _view.Result = $"Missing Angle: {result.Value:F4} degrees";
                    _view.Steps = result.GetStepsAsString();
                    return;
                }
                if (_view.Hypotenuse.HasValue && !_view.Opposite.HasValue && _view.Adjacent.HasValue)
                {
                    var result = TrigonometryTutor.CalculateMissingAngleWithSteps(_view.Hypotenuse, SideType.Hypotenuse,
                        _view.Adjacent, SideType.Adjacent);
                    _view.Result = $"Missing Angle: {result.Value:F4} degrees";
                    _view.Steps = result.GetStepsAsString();
                    return;
                }
                if (!_view.Hypotenuse.HasValue && _view.Opposite.HasValue && _view.Adjacent.HasValue)
                {
                    var result = TrigonometryTutor.CalculateMissingAngleWithSteps(_view.Opposite, SideType.Opposite,
                        _view.Adjacent, SideType.Adjacent);
                    _view.Result = $"Missing Angle: {result.Value:F4} degrees";
                    _view.Steps = result.GetStepsAsString();
                    return;
                }
                if (_view.Hypotenuse.HasValue && _view.Opposite.HasValue && _view.Adjacent.HasValue)
                {
                    _view.ShowError("Please only fill in two sides for angle calculation or instead try 'Check Valid Calculation.'");
                }
                else
                {
                    _view.ShowError("Please fill in all required fields for angle calculation.");
                }
            }

            if (_view.FindOtherSideChecked)
            {
                if (!_view.Angle.HasValue)
                {
                    _view.ShowError("Please enter a known angle value.");
                    return;
                }

                if (!_view.TargetSide.HasValue)
                {
                    _view.ShowError("Please select which side you want to calculate.");
                    return;
                }

                double? knownSideValue = null;
                SideType? knownSideType = null;
                int providedSidesCount = 0;

                if (_view.Hypotenuse.HasValue) { knownSideValue = _view.Hypotenuse; knownSideType = SideType.Hypotenuse; providedSidesCount++; }
                if (_view.Opposite.HasValue) { knownSideValue = _view.Opposite; knownSideType = SideType.Opposite; providedSidesCount++; }
                if (_view.Adjacent.HasValue) { knownSideValue = _view.Adjacent; knownSideType = SideType.Adjacent; providedSidesCount++; }

                if (providedSidesCount != 1)
                {
                    _view.ShowError("Please provide exactly one known side length alongside your target angle.");
                    return;
                }

                SideType targetSideType = _view.TargetSide.Value;

                if (knownSideType == targetSideType)
                {
                    _view.ShowError("The known side and target side cannot be the same.");
                    return;
                }

                var result = TrigonometryTutor.CalculateMissingSideWithSteps(
                    knownSideValue,
                    _view.Angle,
                    knownSideType.Value,
                    targetSideType
                );

                _view.Result = $"Missing {targetSideType}: {result.Value:F4} units";
                _view.Steps = result.GetStepsAsString();
            }
        }
        catch (Exception ex)
        {
            _view.ShowError($"An unexpected error occurred: {ex.Message}");
        }
    }

    private void OnClearAttempted(object? sender, EventArgs e)
    {
        _view.Hypotenuse = null;
        _view.Opposite = null;
        _view.Adjacent = null;
        _view.Angle = null;

        _view.FindMissingAngleChecked = false;
        _view.FindOtherSideChecked = false;
        _view.CheckValidCalculationChecked = false;

        _view.TargetSide = null;

        _view.Result = string.Empty;
        _view.Steps = string.Empty;
    }
}