namespace MathsEngine.Core.Utils.Exceptions
{
    ///// General

    /// <summary>
    /// Exception thrown when the input entered to a function is null or empty.
    /// </summary>
    public class NullInputException : Exception
    {
        public NullInputException() : base("Values entered must not be null") { }
        public NullInputException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when the input entered has too many null values for a calculation.
    /// </summary>
    public class NullValuesException : Exception
    {
        public NullValuesException() : base("Too many null values") { }
        public NullValuesException(string message) : base(message) { }
    }



    ///// PURE
    
    // Pythagoras Theorem

    /// <summary>
    /// Exception thrown when a negative length is entered for a side.
    /// </summary>
    public class NegativeSideLengthException : Exception
    {
        public NegativeSideLengthException() : base("Side lengths must be positive.") { }
        public NegativeSideLengthException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when the hypotenuse is not the longest side entered.
    /// </summary>
    public class HypotenuseNotLongestSideException : Exception
    {
        public HypotenuseNotLongestSideException() : base("Hypotenuse must be the longest side") { }
        public HypotenuseNotLongestSideException(string message) : base(message) { }
    }

    // Trigonometry

    /// <summary>
    /// Exception thrown when an acute angle isn't between 0 and 90.
    /// </summary>
    public class AcuteAngleException : Exception
    {
        public AcuteAngleException() : base("Angle must be between 0 and 90 degrees") { }
        public AcuteAngleException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when the same side is entered to a calculation twice.
    /// </summary>
    public class DuplicateSideException : Exception
    {
        public DuplicateSideException() : base("Known side and the side to find cannot be the same") { }
        public DuplicateSideException(string message) : base(message){ }
    }

    // Matrices

    /// <summary>
    /// Exceptions thrown when the matrices are not the same size so they can't be added or subtracted.
    /// </summary>
    public class IncompatibleMatrixAdditionException : Exception
    {
        public IncompatibleMatrixAdditionException() : base("Matrices can't be added, they are not the same size") { }
        public IncompatibleMatrixAdditionException(string message) : base(message) { }
    }
    public class IncompatibleMatrixSubtractionException : Exception
    {
        public IncompatibleMatrixSubtractionException() : base("Matrices can't be subtracted, they are not the same size") { }
        public IncompatibleMatrixSubtractionException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when the matrices are not compatible for multiplication.
    /// </summary>
    public class IncompatibleMatrixMultiplicationException : Exception
    {
        public IncompatibleMatrixMultiplicationException() : base("Cannot multiply these matrices") { }
        public IncompatibleMatrixMultiplicationException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when the user tries to calculate the determinant of a non-square matrix.
    /// </summary>
    public class NotSquareMatrixException : Exception
    {
        public NotSquareMatrixException(string message) : base(message) { }
    }



    ///// Statistics

    // Bivariate Analysis
    public class ListsNotSameSizeException : Exception
    {
        public ListsNotSameSizeException() : base("Inputs must have the same amount of data points") { }
        public ListsNotSameSizeException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when the used has not inputted enough variables to perform a calculation.
    /// </summary>
    public class InsufficientDataException : Exception
    {
        public InsufficientDataException() : base("There is insufficient input to perform a calculation"){ }
        public InsufficientDataException(string message) : base(message){ }
    }

    // Dispersion

    /// <summary>
    /// Exception thrown when a calculation is attempted on an empty set of data.
    /// </summary>
    public class EmptyDataSetException : Exception
    {
        public EmptyDataSetException() : base("Data set is empty") { }
        public EmptyDataSetException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when a frequency is negative.
    /// </summary>
    public class InvalidFrequencyException : Exception
    {
        public InvalidFrequencyException() : base("Frequency must be a positive number") { }
        public InvalidFrequencyException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when a class interval string is in an invalid format.
    /// </summary>
    public class InvalidClassIntervalFormatException : Exception
    {
        public InvalidClassIntervalFormatException() : base("Class interval string is in an invalid format") { }
        public InvalidClassIntervalFormatException(string message) : base(message) { }
    }



    ///// Mechanics

    /// <summary>
    /// Exception thrown when the mass is inputted as 0.
    /// </summary>
    public class NullMassException : Exception
    {
        public NullMassException() : base("Mass must be a positive number") { }
        public NullMassException(string message) : base(message) { }
    }
}
