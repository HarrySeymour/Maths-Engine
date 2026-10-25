using Core.Modules.Pure.Trigonometry;

namespace Core.Presenters.Pure.Trigonometry;

public interface ITrigonometryView
{
    public double? Hypotenuse { get; set; }
    public double? Adjacent { get; set; }
    public double? Opposite { get; set; }
    public double? Angle { get; set; }

    public bool FindOtherSideChecked { get; set; }
    public bool FindMissingAngleChecked { get; set; }
    public bool CheckValidCalculationChecked { get; set; }

    public SideType? TargetSide { get; set; }

    public string Result { get; set; }
    public string Steps { get; set; }

    void ShowError(string message);

    public event EventHandler CalculateAttempted;
    public event EventHandler ClearAttempted;
}