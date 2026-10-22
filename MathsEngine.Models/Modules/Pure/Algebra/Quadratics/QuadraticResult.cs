using System.Text;

namespace MathsEngine.Core.Modules.Pure.Algebra.Quadratics;

public class QuadraticResult
{
    public QuadraticRootType RootType { get; }
    public double Discriminant { get; }
    public double? Root1  { get; }
    public double? Root2 { get; }
    public string ExactRepresentation { get; }
    
    public QuadraticResult(QuadraticRootType rootType, double discriminant, double? root1, double? root2, string exactRepresentation)
    {
        RootType = rootType;
        Discriminant = discriminant;
        Root1 = root1;
        Root2 = root2;
        ExactRepresentation = exactRepresentation;
    }
    public QuadraticResult(QuadraticRootType rootType, double discriminant, string exactRepresentation)
    {
        RootType = rootType;
        Discriminant = discriminant;
        ExactRepresentation = exactRepresentation;
    }
    public QuadraticResult(QuadraticRootType rootType, double discriminant, double? root1, string exactRepresentation)
    {
        RootType = rootType;
        Discriminant = discriminant;
        Root1 = root1;
        ExactRepresentation = exactRepresentation;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine($"Root Type: {RootType}");
        sb.AppendLine($"Discriminant: {Discriminant}");
        
        if (Root1.HasValue)
            sb.AppendLine($"Root 1: {Root1.Value}");
        
        if (Root2.HasValue)
            sb.AppendLine($"Root 2: {Root2.Value}");
        
        sb.AppendLine($"Exact Representation: {ExactRepresentation}");
        
        return sb.ToString();
    }
}