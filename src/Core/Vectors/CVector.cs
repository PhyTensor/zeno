using System.Numerics;

namespace Zeno.Core.Vectors;

public sealed class CVector : ICVectorN
{
    public Complex[] _components;

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

    public double Length => NormEuclidean();

    public double LengthSquared => NormEuclideanSquared();

    public ICVector Unit => Normalize();

    public double AngleBetween(ICVectorN other) => AngleBetween(this, other);

    public ICVector Normalize()
    {
        double len = Length;
        if (len <= 0)
            return this;

        return new CVector(Components.Select(c => (c / len)).ToArray());
    }

    public double NormEuclidean() => Math.Sqrt(NormEuclideanSquared());

    public double NormEuclideanSquared() => Components.Sum(c => Math.Pow(Complex.Abs(c), 2));

    public double NormManhattan() => Components.Sum(c => Complex.Abs(c));

    /*public double NormMax() => Components.Max();*/

    public ICVector Reverse() => new CVector(Components.Select(c => -c).ToArray());

    public ICVector Rotate(double radians) => throw new NotImplementedException();

    public ICVector Scale(double scalar) =>
        new CVector(Components.Select(c => (scalar * c)).ToArray());

    public double Dot(ICVectorN other) => throw new NotImplementedException();

    public ICVector TensorProduct(ICVectorN other) => TensorProduct(this, other);

    // Static Methods
    /*public static double AngleBetween(ICVectorN a, ICVectorN b) => Math.Acos();*/
    public static double DotProduct(ICVectorN a, ICVectorN b)
    {
        if (a.Dimensions != b.Dimensions)
            throw new ArgumentException(
                "vector DotProduct/Inner product vectors must have the same dimesions"
            );
    }
}
