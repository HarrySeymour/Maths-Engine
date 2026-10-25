using Core.Utils.Exceptions;

namespace Core.Modules.Pure.Trigonometry
{
    public static class TrigonometryCalculator
    {
        public static double CalculateMissingSide(double? knownSideLength, double? angle, SideType knownSideType, SideType sideToFind)
        {
            if (knownSideLength is null || angle is null)
                throw new NullInputException();

            if (knownSideLength <= 0)
                throw new NegativeSideLengthException();

            if (angle <= 0.0 || angle >= 90.0)
                throw new AcuteAngleException();

            if (sideToFind == knownSideType)
                throw new DuplicateSideException();

            double angleInRadians = angle.Value * (Math.PI / 180.0);
            double result = 0;

            // SOH
            if ((knownSideType == SideType.Opposite && sideToFind == SideType.Hypotenuse) ||
                (knownSideType == SideType.Hypotenuse && sideToFind == SideType.Opposite))
            {
                result = (sideToFind == SideType.Hypotenuse)
                    ? knownSideLength.Value / Math.Sin(angleInRadians)
                    : knownSideLength.Value * Math.Sin(angleInRadians);
            }

            // CAH
            if ((knownSideType == SideType.Adjacent && sideToFind == SideType.Hypotenuse) ||
                (knownSideType == SideType.Hypotenuse && sideToFind == SideType.Adjacent))
            {
                result = (sideToFind == SideType.Hypotenuse)
                    ? knownSideLength.Value / Math.Cos(angleInRadians)
                    : knownSideLength.Value * Math.Cos(angleInRadians);
            }

            // TOA
            if ((knownSideType == SideType.Opposite && sideToFind == SideType.Adjacent) ||
                (knownSideType == SideType.Adjacent && sideToFind == SideType.Opposite))
            {
                result = (sideToFind == SideType.Adjacent)
                    ? knownSideLength.Value / Math.Tan(angleInRadians)
                    : knownSideLength.Value * Math.Tan(angleInRadians);
            }

            return result;
        }

        public static double CalculateMissingAngle(double? side1Length, SideType side1Type, double? side2Length, SideType side2Type)
        {
            if (side1Length is null || side2Length is null)
                throw new NullInputException();

            if (side1Length <= 0 || side2Length <= 0)
                throw new NegativeSideLengthException();

            if (side1Type == side2Type)
                throw new DuplicateSideException();

            if (side1Type == SideType.Hypotenuse && side1Length <= side2Length)
                throw new HypotenuseNotLongestSideException();
            if (side2Type == SideType.Hypotenuse && side2Length <= side1Length)
                throw new HypotenuseNotLongestSideException();

            double opposite = 0, adjacent = 0, hypotenuse = 0;
            double angleInRadians = 0;

            if ((side1Type == SideType.Opposite && side2Type == SideType.Hypotenuse) ||
                (side1Type == SideType.Hypotenuse && side2Type == SideType.Opposite))
            {
                opposite = (side1Type == SideType.Opposite) ? side1Length.Value : side2Length.Value;
                hypotenuse = (side1Type == SideType.Hypotenuse) ? side1Length.Value : side2Length.Value;
                angleInRadians = Math.Asin(opposite / hypotenuse);
            }

            if ((side1Type == SideType.Adjacent && side2Type == SideType.Hypotenuse) ||
                (side1Type == SideType.Hypotenuse && side2Type == SideType.Adjacent))
            {
                adjacent = (side1Type == SideType.Adjacent) ? side1Length.Value : side2Length.Value;
                hypotenuse = (side1Type == SideType.Hypotenuse) ? side1Length.Value : side2Length.Value;
                angleInRadians = Math.Acos(adjacent / hypotenuse);
            }

            if ((side1Type == SideType.Opposite && side2Type == SideType.Adjacent) ||
                (side1Type == SideType.Adjacent && side2Type == SideType.Opposite))
            {
                opposite = (side1Type == SideType.Opposite) ? side1Length.Value : side2Length.Value;
                adjacent = (side1Type == SideType.Adjacent) ? side1Length.Value : side2Length.Value;
                angleInRadians = Math.Atan(opposite / adjacent);
            }

            return angleInRadians * (180.0 / Math.PI);
        }

        public static bool IsValidTriangle(double? hypotenuse, double? opposite, double? adjacent, double? angle)
        {
            if (hypotenuse is null || opposite is null || adjacent is null || angle is null)
                throw new NullInputException();

            if (hypotenuse <= 0 || opposite <= 0 || adjacent <= 0 || angle <= 0 || angle >= 90)
                return false;

            if (hypotenuse <= opposite || hypotenuse <= adjacent)
                return false;

            double tolerance = 0.001;
            double radians = angle.Value * (Math.PI / 180.0);

            if (Math.Abs((opposite.Value / hypotenuse.Value) - Math.Sin(radians)) > tolerance) return false;
            if (Math.Abs((adjacent.Value / hypotenuse.Value) - Math.Cos(radians)) > tolerance) return false;
            if (Math.Abs((opposite.Value / adjacent.Value) - Math.Tan(radians)) > tolerance) return false;

            double hypotenuseSquared = hypotenuse.Value * hypotenuse.Value;
            double otherSideSquared = (opposite.Value * opposite.Value) + (adjacent.Value * adjacent.Value);

            if (Math.Abs(hypotenuseSquared - otherSideSquared) > tolerance) return false;

            return true;
        }
    }
}