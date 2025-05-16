using System.Numerics;

namespace Lib.Vectors;

public sealed class CVector
{
    private Complex[] _components;

    public CVector(params Complex[] components)
    {
        _components = components ?? throw new ArgumentNullException(nameof(components));
    }

    public CVector(int dimensions)
    {
        if (dimensions <= 0)
            throw new ArgumentException("Dimensions must be greater than zero", nameof(dimensions));

        _components = new Complex[dimensions];
    }

    public CVector(CVector vector)
    {
        _components = (Complex[])vector.Components.Clone();
    }

    // INDEXER
    public Complex this[int i]
    {
        get
        {
            if (i < 0 || i >= Dimensions)
                throw new IndexOutOfRangeException(
                    "Index must fall within range of the vector's dimensions"
                );

            return Components[i];
        }
        set
        {
            if (i < 0 || i >= Dimensions)
                throw new IndexOutOfRangeException(
                    "Index must fall within the range of the vector's dimensions"
                );

            Components[i] = value;
        }
    }

    public Complex[] Components
    {
        get => _components;
        set => _components = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Dimensions => Components.Length;

    /// <summary>
    /// Gets the magnitude/norm of the vector
    /// </summary>
    public double Length => NormEuclidean();

    public double LengthSquared => NormEuclideanSquared();

    public CVector Unit => Normalize();

    public CVector Normalize()
    {
        double len = Length;
        if (len <= 0)
            return this;

        return new CVector(Components.Select(c => (Complex.Multiply(1 / len, c))).ToArray());
    }

    public CVector Conjugate() => new CVector(Components.Select(c => Complex.Conjugate(c)).ToArray());

    public CVector Reverse() => new CVector(Components.Select(c => Complex.Multiply(-1, c)).ToArray());

    public CVector Scale(double scalar) =>
        new CVector(Components.Select(c => Complex.Multiply(scalar, c)).ToArray());

    public Complex Dot(CVector other) => DotProduct(this, other);

    public CVector TensorProduct(CVector other) => TensorProduct(this, other);

    public double NormEuclideanSquared() => Components.Sum(c => Math.Pow(Complex.Abs(c), 2));

    public double NormEuclidean() => Math.Sqrt(NormEuclideanSquared());

    public double NormManhattan() => Components.Sum(c => Complex.Abs(c));

    // public double NormMax() => Components.Max();

    public double AngleBetween(CVector other) => AngleBetween(this, other);

    public CVector Rotate(double radians) => throw new NotImplementedException();

    // STATIC METHODS

    /// <summary>
    /// Creates a composite quantum mechanical system.
    /// The state space of a composite physical system us the tensor product of the state spaces of the component physical system.
    /// </summary>
    public static CVector TensorProduct(CVector a, CVector b)
    {
        int dim = a.Dimensions * b.Dimensions;
        CVector result = new(dim);

        int index = 0;
        for (int i = 0; i < a.Dimensions; i++)
        {
            for (int j = 0; j < b.Dimensions; j++)
            {
                result[index] = Complex.Multiply(a[i], b[j]);
                index += 1;
            }
        }

        return result;
    }

    public static double AngleBetween(CVector a, CVector b) => Math.Acos(DotProduct(a, b).Real / (a.Length * b.Length));

    public static CVector Addition(CVector a, CVector b)
    {
        if (a.Dimensions != b.Dimensions)
            throw new ArgumentException("Vector Addition requires vectors have the same dimensions.");

        return new CVector(a.Components.Zip(b.Components, (c1, c2) => Complex.Add(c1, c2)).ToArray());
    }

    public static CVector Subtraction(CVector a, CVector b)
    {
        if (a.Dimensions != b.Dimensions)
            throw new ArgumentException("Vector Subtraction requires vectors have the same dimensions.");

        return new CVector(a.Components.Zip(b.Components, (c1, c2) => Complex.Subtract(c1, c2)).ToArray());
    }

    public static Complex DotProduct(CVector a, CVector b)
    {
        if (a.Dimensions != b.Dimensions)
            throw new ArgumentException(
                "Vector DotProduct/Inner product vectors must have the same dimesions"
            );

        IEnumerable<Complex> componentProducts = a.Components.Zip(b.Conjugate().Components, (c1, c2) => Complex.Multiply(c1, c2));

        Complex result = Complex.Zero;
        foreach (var component in componentProducts)
        {
            result = Complex.Add(result, component);
        }
        return result;
    }

    // OPERATOR OVERLOADS
    public static CVector operator +(CVector a, CVector b) => Addition(a, b);

    public static CVector operator -(CVector a, CVector b) => Subtraction(a, b);

    public static CVector operator +(CVector a) => a;

    public static CVector operator -(CVector a) =>
        new CVector(a.Components.Select(c => Complex.Multiply(-1, c)).ToArray());

    public static CVector operator *(double scalar, CVector a) =>
        new CVector(a.Components.Select(c => Complex.Multiply(scalar, c)).ToArray());

    public static CVector operator /(double scalar, CVector a) =>
        new CVector(a.Components.Select(c => Complex.Multiply((1 / scalar), c)).ToArray());

    public static CVector operator *(CVector a, CVector b) => TensorProduct(a, b);
}
