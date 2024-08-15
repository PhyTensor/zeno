namespace Zeno.Core.Vectors;

public sealed class Vector3 : IVector3
{
    private double[] _components;

    public Vector3()
        : this(0, 0, 0) { }

    public Vector3(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;

        _components = new double[] { x, y, z };
    }

    public Vector3(Vector3 vector)
        : this(vector.X, vector.Y, vector.Z) { }

    public Vector3(params double[] components)
    {
        if (components.Length > Dimensions)
            throw new ArgumentOutOfRangeException(
                "Vector3 allows only 3 elements to compose a 3-dimensional vector!"
            );

        _components = components ?? throw new ArgumentNullException(nameof(components));
    }

    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    public int Dimensions => 3;

    public double Length => ComputeNorm();

    public double LengthSquared => ComputeNormSquared();

    public double[] Components
    {
        get => _components;
        set => _components = value ?? throw new ArgumentNullException(nameof(value));
    }

    // Computational/Standard bais vectors for a 3D vector space
    public static Vector3 StandardBasisX => new Vector3(1, 0, 0);
    public static Vector3 StandardBasisY => new Vector3(0, 1, 0);
    public static Vector3 StandardBasisZ => new Vector3(0, 0, 1);

    public IVector Unit => Normalize();

    private double ComputeNormSquared() => (X * X) + (Y * Y) + (Z * Z);

    private double ComputeNorm() => Math.Sqrt(ComputeNormSquared());

    public IVector Normalize()
    {
        double len = ComputeNorm();
        if (len <= 0)
            return this;

        return new Vector3(X / len, Y / len, Z / len);
    }

    public IVector Reverse()
    {
        return new Vector3(-X, -Y, -Z);
    }

    public IVector Scale(double scalar)
    {
        return new Vector3(X * scalar, Y * scalar, Z * scalar);
    }

    public double Dot(IVector3 other)
    {
        return (X * other.X) + (Y * other.Y) + (Z * other.Z);
    }

    public double AngleBetween(IVector3 other)
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

    public IVector3 Cross(IVector3 other)
    {
        return new Vector3(
            (Y * other.Z - Z * other.Y),
            (Z * other.X - X * other.Z),
            (X * other.Y - Y * other.X)
        );
    }
}
