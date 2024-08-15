namespace Zeno.Core.Vectors;

/// <summary>
/// Represents a 2D (2-dimensional) Vector
/// <summary>
public sealed class Vector2 : IVector2
{
    private double[] _components;

    public Vector2()
        : this(0, 0) { }

    public Vector2(double x, double y)
    {
        X = x;
        Y = y;

        _components = new double[] { x, y };
    }

    public Vector2(Vector2 vector)
        : this(vector.X, vector.Y) { }

    public Vector2(params double[] components)
    {
        if (components.Length > Dimensions)
            throw new ArgumentOutOfRangeException(
                "Vector2 allows only 2 elements to compose a 2-dimensional vector!"
            );

        _components = components ?? throw new ArgumentNullException(nameof(components));
    }

    public double X { get; set; }
    public double Y { get; set; }

    public int Dimensions => 2;

    public double Length => ComputeNorm();

    public double LengthSquared => ComputeNormSquared();

    public double[] Components
    {
        get => _components;
        set => _components = value ?? throw new ArgumentNullException(nameof(value));
    }

    // Computational/Standard basis vectors for a 2D vector space
    public static Vector2 StandardBasisX => new Vector2(1, 0);
    public static Vector2 StandardBasisY => new Vector2(0, 1);

    public IVector Unit => Normalize();

    private double ComputeNorm() => Math.Sqrt(ComputeNormSquared());

    private double ComputeNormSquared() => (X * X) + (Y * Y);

    public double Dot(IVector2 other)
    {
        return (X * other.X) + (Y * other.Y);
    }

    public IVector Normalize()
    {
        double len = ComputeNorm();
        if (len <= 0)
            return this;

        return new Vector2(X / len, Y / len);
    }

    public IVector Reverse()
    {
        return new Vector2(-X, -Y);
    }

    public IVector Scale(double scalar)
    {
        return new Vector2(X * scalar, Y * scalar);
    }

    public double AngleBetween(IVector2 other)
    {
        double magnitudes = Length * other.Length;

        if (magnitudes <= 0)
            throw new InvalidOperationException(
                "Cannot calculate the angle with a zero-length vector!"
            );

        return Math.Acos(Dot(other) / magnitudes);
    }

    public IVector Rotate(double radians)
    {
        throw new NotImplementedException();
    }
}
