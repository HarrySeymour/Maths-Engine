namespace Core.Presenters.Pure.PythagorasTheorem;

public interface IPythagorasView
{
    // Inputs
    public double? SideA { get; set; }
    public double? SideB { get; set; }
    public double? Hypotenuse { get; set; }
    public bool FindHypotenuseChecked { get; set; }
    public bool FindOtherSideChecked { get; set; }

    // Outputs
    public string Result { get; set; }
    public string Steps { get; set; }

    void ShowError(string message);

    // User Actions
    public event EventHandler CalculateAttempted;
    public event EventHandler ClearAttempted;
}