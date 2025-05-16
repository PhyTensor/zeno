namespace Lib.Vectors;

/// <summary>
/// A 2D vector in a real 2D vector space, using floating-point numbers
/// A 2-element structure that can be used to represent 2D coordinates or any other
/// pair of numeric values.
///
/// </summary>
public sealed class Vector2
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

        X = components[0];
        Y = components[1];

        _components = components ?? throw new ArgumentNullException(nameof(components));
    }

    // INDEXER
    public double this[int i]
    {
        get
        {
            if (i < 0 || i >= Dimensions)
                throw new IndexOutOfRangeException(
                    "Index must fall within the range of the vector's dimension."
                );
            return Components[i];
        }
        set
        {
            if (i < 0 || i >= Dimensions)
                throw new IndexOutOfRangeException(
                    "Index must fall within the range of the vector's dimension."
                );
            Components[i] = value;
        }
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

    public Vector2 Unit => Normalize();

    private double ComputeNorm() => Math.Sqrt(ComputeNormSquared());

    private double ComputeNormSquared() => (X * X) + (Y * Y);

    public double Dot(Vector2 other)
    {
        return (X * other.X) + (Y * other.Y);
    }

    public Vector2 Normalize()
    {
        double len = ComputeNorm();
        if (len <= 0)
            return this;

        return new Vector2(X / len, Y / len);
    }

    public Vector2 Reverse()
    {
        return new Vector2(-X, -Y);
    }

    public Vector2 Scale(double scalar)
    {
        return new Vector2(X * scalar, Y * scalar);
    }

    public double AngleBetween(Vector2 other)
    {
        double magnitudes = Length * other.Length;

        if (magnitudes <= 0)
            throw new InvalidOperationException(
                "Cannot calculate the angle with a zero-length vector!"
            );

        return Math.Acos(Dot(other) / magnitudes);
    }

    public Vector2 Rotate(double radians)
    {
        throw new NotImplementedException();
    }
}
