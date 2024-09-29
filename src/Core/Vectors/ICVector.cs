using System.Numerics;

namespace Zeno.Core.Vectors;

/// <summary>
/// Interface for vector operations
/// </summary>
public interface ICVector
{
    Complex this[int i] { get; set; }

    /// <summary>
    /// Gets the dimension of the vector/the number of components
    /// </summary>
    int Dimensions { get; }

    /// <summary>
    /// Gets the Components of the vector
    /// </summary>
    Complex[] Components { get; set; }

    /// <summary>
    /// Gets the magnitude/norm of the vector
    /// </summary>
    double Length { get; }

    /// <summary>
    /// Gets the norm squared of the vector. Avoids the square-root operation
    /// </summary>
    double LengthSquared { get; }

    /// Unit vector
    ICVector Unit { get; }

    ICVector Normalize();
    ICVector Reverse();
    ICVector Scale(double scalar);
    ICVector Rotate(double radians);
}

public interface ICVector2 : ICVector
{
    Complex X { get; set; }
    Complex Y { get; set; }

    double Dot(ICVector2 other);
    double AngleBetween(ICVector2 other);
}

public interface ICVector3 : ICVector
{
    Complex X { get; set; }
    Complex Y { get; set; }
    Complex Z { get; set; }

    double Dot(ICVector3 other);
    double AngleBetween(ICVector3 other);
    ICVector3 Cross(ICVector3 other);
}

public interface ICVectorN : ICVector
{
    /// Defined as the sum of the absolute values of the comonents of a given vector.
    /// ||x|| = |x1| + |x2|
    double NormEuclidean();

    /// ||x||^2 = |x1|^2 + |x2|^2
    /*double NormEuclideanSquared();*/

    /// Defined as the root of the sum of the squares of the components of the vector.
    double NormManhattan();

    /// L_infinity/Max Norm. Defined as the absolute value of the largest component of the vector
    /*double NormMax();*/

    double AngleBetween(ICVectorN other);

    double Dot(IVectorN other);

    /// Tensor Product
    ICVector TensorProduct(ICVectorN other);
}
