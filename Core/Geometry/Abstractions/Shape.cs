namespace Core.Geometry.Abstractions;

public abstract class Shape
{
    public abstract string Name { get; }
    public abstract string DisplayName { get; }
    public abstract string? Description { get;}
    
    public abstract bool Validate();
}