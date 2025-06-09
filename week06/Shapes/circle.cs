// Circle.cs
public class Circle : Shape
{
    private float _radius;

    public Circle(string color, float radius) : base(color)
    {
        _radius = radius;
    }

    public override float GetArea()
    {
        return (float)(Math.PI * _radius * _radius); // Area of a circle = π * radius^2
    }
}
