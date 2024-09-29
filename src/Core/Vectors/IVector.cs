namespace Zeno.Core.Vectors;

/// <summary>
/// Interface for vector operations
/// </summary>
public interface IVector
{
    double this[int i] { get; set; }

    /// <summary>
    /// Gets the dimension of the vector/the number of components
    /// </summary>
    int Dimensions { get; }

    /// <summary>
    /// Gets the Components of the vector
    /// </summary>
    double[] Components { get; set; }

    /// <summary>
    /// Gets the magnitude/norm of the vector
    /// </summary>
    double Length { get; }

    /// <summary>
    /// Gets the norm squared of the vector. Avoids the square-root operation
    /// </summary>
    double LengthSquared { get; }

    /// Unit vector
    IVector Unit { get; }

    IVector Normalize();
    IVector Reverse();
    IVector Scale(double scalar);
    IVector Rotate(double radians);
}

public interface IVector2 : IVector
{
    double X { get; set; }
    double Y { get; set; }

    double Dot(IVector2 other);
    double AngleBetween(IVector2 other);
}

public interface IVector3 : IVector
{
    double X { get; set; }
    double Y { get; set; }
    double Z { get; set; }

    double Dot(IVector3 other);
    double AngleBetween(IVector3 other);
    IVector3 Cross(IVector3 other);
}

public interface IVectorN : IVector
{
    /// <summary>
    /// L2 = Euclidean distance
    /// Defined as the root of the sum of the squares of the components of the vector.
    /// ||x||^2 = sqrt( |x1|^2 + |x2|^2 )
    /// </summary>
    double NormEuclidean();

    /// <summary>
    /// ||x||^2 = |x1|^2 + |x2|^2
    /// </summary>
    double NormEuclideanSquared();

    /// <summary>
    /// L1 = Manhattan distance
    /// Defined as the sum of the absolute values of the comonents of a given vector.
    /// ||x|| = |x1| + |x2|
    /// </summary>
    double NormManhattan();

    /// <summary>
    /// L_infinity/Max Norm. Defined as the absolute value of the largest component of the vector
    /// </summary>
    double NormMax();

    double AngleBetween(IVectorN other);

    double Dot(IVectorN other);

    /// Tensor Product
    IVector TensorProduct(IVectorN other);
}
