namespace Lib.Vectors;

/// <summary>
/// n-dimensional (real-valued) Vector
/// </summary>
public sealed class Vector
{
    private double[] _components;

    public Vector(params double[] components)
    {
        _components = components ?? throw new ArgumentNullException(nameof(components));
    }

    public Vector(int dimensions)
    {
        if (dimensions <= 0)
            throw new ArgumentException("Dimensions must be greater than zero", nameof(dimensions));

        _components = new double[dimensions];
    }

    public Vector(Vector vector)
    {
        _components = (double[])vector.Components.Clone();
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

    /// <summary>
    /// Gets the Components of the vector
    /// </summary>
    public double[] Components
    {
        get => _components;
        set => _components = value ?? throw new ArgumentNullException(nameof(value));
    }

    /// <summary>
    /// Gets the dimension of the vector/the number of components
    /// </summary>
    public int Dimensions => Components.Length;

    /// <summary>
    /// Gets the magnitude/norm of the vector
    /// </summary>
    public double Length => NormEuclidean();

    /// <summary>
    /// Gets the norm squared of the vector. Avoids the square-root operation
    /// </summary>
    public double LengthSquared => NormEuclideanSquared();

    /// <summary>
    /// Unit vector
    /// </summary>
    public Vector Unit => Normalize();

    public Vector Normalize()
    {
        double len = Length;
        if (len <= 0)
            // return this;
            throw new Exception("Vector magnitude should be equal to or greater than 1.");

        return new Vector(Components.Select(c => (c / len)).ToArray());
    }

    public Vector Conjugate() => this;

    public Vector Reverse() => new Vector(Components.Select(c => -c).ToArray());

    public Vector Scale(double scalar) =>
        new Vector(Components.Select(c => (scalar * c)).ToArray());

    public double Dot(Vector other) => DotProduct(this, other);

    public Vector TensorProduct(Vector other) => TensorProduct(this, other);

    /// <summary>
    /// ||x||^2 = |x1|^2 + |x2|^2
    /// </summary>
    public double NormEuclideanSquared() => Components.Sum(c => c * c);

    /// <summary>
    /// L2 = Euclidean distance
    /// Defined as the root of the sum of the squares of the components of the vector.
    /// ||x||^2 = sqrt( |x1|^2 + |x2|^2 )
    /// </summary>
    public double NormEuclidean() => Math.Sqrt(NormEuclideanSquared());

    /// <summary>
    /// L1 = Manhattan distance
    /// Defined as the sum of the absolute values of the comonents of a given vector.
    /// ||x|| = |x1| + |x2|
    /// </summary>
    public double NormManhattan() => Components.Sum(c => Math.Abs(c));

    /// <summary>
    /// L_infinity/Max Norm. Defined as the absolute value of the largest component of the vector
    /// </summary>
    // public double NormMax() => Components.Max();

    public double AngleBetween(Vector other) => AngleBetween(this, other);

    public Vector Rotate(double radians) => throw new NotImplementedException();

    // STATIC METHODS

    /// <summary>
    /// Creates a composite quantum mechanical system.
    /// The state space of a composite physical system us the tensor product of the state spaces of the component physical system.
    /// </summary>
    public static Vector TensorProduct(Vector a, Vector b)
    {
        int dim = a.Dimensions * b.Dimensions;
        Vector result = new(dim);

        int index = 0;
        for (int i = 0; i < a.Dimensions; i++)
        {
            for (int j = 0; j < b.Dimensions; j++)
            {
                result[index] = a[i] * b[j];
                index += 1;
            }
        }

        return result;
    }

    public static double AngleBetween(Vector a, Vector b) =>
        Math.Acos(DotProduct(a, b) / (a.Length * b.Length));

    public static Vector Addition(Vector a, Vector b)
    {
        if (a.Dimensions != b.Dimensions)
            throw new ArgumentException(
                "Vector Addition requires vectors have the same dimensions."
            );

        return new Vector(a.Components.Zip(b.Components, (c1, c2) => c1 + c2).ToArray());
    }

    public static Vector Subtraction(Vector a, Vector b)
    {
        if (a.Dimensions != b.Dimensions)
            throw new ArgumentException(
                "Vector Subtraction requires vectors have the same dimensions."
            );

        return new Vector(a.Components.Zip(b.Components, (c1, c2) => c1 - c2).ToArray());
    }

    public static double DotProduct(Vector a, Vector b)
    {
        if (a.Dimensions != b.Dimensions)
            throw new ArgumentException(
                "Vector DotProduct/Inner Product vectors must have same dimensions."
            );

        return a.Components.Zip(b.Components, (c1, c2) => c1 * c2).Sum();
    }

    // OPERATOR OVERLOADS
    public static Vector operator +(Vector a, Vector b) => Addition(a, b);

    public static Vector operator -(Vector a, Vector b) => Subtraction(a, b);

    public static Vector operator +(Vector a) => a;

    public static Vector operator -(Vector a) =>
        new Vector(a.Components.Select(c => -c).ToArray());

    public static Vector operator *(double scalar, Vector a) =>
        new Vector(a.Components.Select(c => (scalar * c)).ToArray());

    public static Vector operator /(double scalar, Vector a) =>
        new Vector(a.Components.Select(c => ((1 / scalar) * c)).ToArray());

    public static Vector operator *(Vector a, Vector b) => TensorProduct(a, b);
}
