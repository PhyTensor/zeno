namespace Zeno.Core.Vectors;

/// <summary>
/// A class that represents a 3-dimensional Vector
/// </summary>
public class Vector3D
{
    // CONSTRUCTORS

    /// <summary>
    /// Creates a zero (0, 0, 0) vector
    /// </summary>
    public Vector3D()
        : this(0, 0, 0) { }

    /// <summary>
    /// Creates a vector from the x, y, and z coordinates
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public Vector3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// Creates a new vector that is a copy of the vector passed in as an argument
    /// </summary>
    /// <param name="vector"></param>
    public Vector3D(Vector3D vector)
        : this(vector.X, vector.Y, vector.Z) { }

    // PROPERTIES

    /// <summary>
    /// X coordinate
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Y coordinate
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Z coordinate
    /// </summary>
    public double Z { get; set; }

    /// <summary>
    /// Norm/Magnitude of the vector
    /// </summary>
    public double Length
    {
        get { return ComputeNorm(); }
    }

    public double LengthSquared
    {
        get { return ComputeNormSquared(); }
    }

    // Computational basis vectors for a 3-dimensional vector space
    public static Vector3D BasisX
    {
        get => new Vector3D(1, 0, 0);
    }

    public static Vector3D BasisY
    {
        get => new Vector3D(0, 1, 0);
    }

    public static Vector3D BasisZ
    {
        get => new Vector3D(0, 0, 1);
    }

    // indexer
    public double this[int i]
    {
        get
        {
            if (i == 0)
            {
                return X;
            }
            else if (i == 1)
            {
                return Y;
            }
            else if (i == 2)
            {
                return Z;
            }
            else
            {
                throw new System.IndexOutOfRangeException("Index must fall between 0 and 3");
            }
        }
        set
        {
            if (i == 0)
            {
                X = value;
            }
            else if (i == 1)
            {
                Y = value;
            }
            else if (i == 2)
            {
                Z = value;
            }
            else
            {
                throw new System.IndexOutOfRangeException("Index must fall between 0 and 3");
            }
        }
    }

    /// <summary>
    /// Compute the Euclidean norm/magnitude of a Vector
    /// </summary>
    public double ComputeNorm()
    {
        return Math.Sqrt(ComputeNormSquared());
    }

    private double ComputeNormSquared()
    {
        return (X * X) + (Y * Y) + (Z * Z);
    }

    /// <summary>
    /// Reverse the orientation of a vector. Similar to a 180 degree rotation of a vector
    /// </summary>
    public void Reverse()
    {
        X = -X;
        Y = -Y;
        Z = -Z;
    }

    /// <summary>
    /// Scale a vector by a factor or scalar. Scalar multiplication
    /// </summary>
    public void Scale(double factor)
    {
        X *= factor;
        Y *= factor;
        Z *= factor;
    }

    /// <summary>
    /// Normalize or Unitize a vector.
    /// </summary>
    public void Normalize()
    {
        double len = ComputeNorm();
        if (len <= 0)
            return;

        X = X / len;
        Y = Y / len;
        Z = Z / len;
    }

    public static Vector3D Normalize(Vector3D a)
    {
        double len = a.ComputeNorm();
        if (len <= 0)
            return a;
        return new Vector3D((a.X / len), (a.Y / len), (a.Z / len));
    }

    // Scalar multiplication
    public static Vector3D ScalarMultiplication(double a, Vector3D b)
    {
        return new Vector3D((a * b.X), (a * b.Y), (a * b.Z));
    }

    /// Returns a new vector that is the vector two vectors
    public static Vector3D Addition(Vector3D a, Vector3D b)
    {
        return new Vector3D((a.X + b.X), (a.Y + b.Y), (a.Z + b.Z));
    }

    /// Returns a new vector that is the subtraction of vector 'b' from 'a'
    public static Vector3D Subtract(Vector3D a, Vector3D b)
    {
        return new Vector3D((a.X - b.X), (a.Y - b.Y), (a.Z - b.Z));
    }

    /// <summary>
    /// Dot product of two vectors
    /// </summary>
    public static double DotProduct(Vector3D a, Vector3D b)
    {
        return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
    }

    /// <summary>
    /// Cross product of two vectors
    /// </summary>
    public static Vector3D CrossProduct(Vector3D a, Vector3D b)
    {
        return new Vector3D(
            ((a.Y * b.Z) - (a.Z * b.Y)),
            ((a.Z * b.X) - (a.X * b.Z)),
            ((a.X * b.Y) - (a.Y * b.X))
        );
    }

    // public override bool Equals(object? obj)
    // {
    //     return base.Equals(obj);
    // }
    //
    // public override int GetHashCode()
    // {
    //     return base.GetHashCode();
    // }
    //
    // public override string? ToString()
    // {
    //     // return base.ToString();
    //     return $"({X}, {Y}, {Z})";
    // }

    // operator overloads
    /// <summary>
    /// Vector addition operator
    /// </summary>
    public static Vector3D operator +(Vector3D a, Vector3D b)
    {
        return Addition(a, b);
    }

    /// <summary>
    /// Vector Subtraction operator
    /// </summary>
    public static Vector3D operator -(Vector3D a, Vector3D b)
    {
        return Subtract(a, b);
    }

    public static Vector3D operator +(Vector3D a)
    {
        return new Vector3D(a);
    }

    public static Vector3D operator -(Vector3D a)
    {
        return new Vector3D(-a.X, -a.Y, -a.Z);
    }

    public static Vector3D operator *(double a, Vector3D b)
    {
        return ScalarMultiplication(a, b);
    }

    // public static bool operator ==(Vector3D a, Vector3D b)
    // {
    //     if (a.X == b.X && a.Y == b.Y && a.Z == b.Z)
    //         return true;
    //     else
    //         return false;
    // }
    //
    // public static bool operator !=(Vector3D a, Vector3D b)
    // {
    //     if (!(a == b))
    //         return true;
    //     else
    //         return false;
    // }
}
