namespace Lib.Vectors;

public sealed class Vector3
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

        X = components[0];
        Y = components[1];
        Z = components[2];

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

    public Vector3 Unit => Normalize();

    private double ComputeNormSquared() => (X * X) + (Y * Y) + (Z * Z);

    private double ComputeNorm() => Math.Sqrt(ComputeNormSquared());

    public Vector3 Normalize()
    {
        double len = ComputeNorm();
        if (len <= 0)
            return this;

        return new Vector3(X / len, Y / len, Z / len);
    }

    public Vector3 Reverse()
    {
        return new Vector3(-X, -Y, -Z);
    }

    public Vector3 Scale(double scalar)
    {
        return new Vector3(X * scalar, Y * scalar, Z * scalar);
    }

    public double Dot(Vector3 other)
    {
        return (X * other.X) + (Y * other.Y) + (Z * other.Z);
    }

    public double AngleBetween(Vector3 other)
    {
        double magnitudes = Length * other.Length;

        if (magnitudes <= 0)
            throw new InvalidOperationException(
                "Cannot calculate the angle with a zero-length vector!"
            );

        return Math.Acos(Dot(other) / magnitudes);
    }

    public Vector Rotate(double radians)
    {
        throw new NotImplementedException();
    }

    public Vector3 Cross(Vector3 other)
    {
        return new Vector3(
            (Y * other.Z - Z * other.Y),
            (Z * other.X - X * other.Z),
            (X * other.Y - Y * other.X)
        );
    }
}
