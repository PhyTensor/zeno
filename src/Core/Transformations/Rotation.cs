namespace Zeno.Core.Transformations;

using Zeno.Core.Matrices;

public static class Rotation
{
    // Basic 2D Rotation
    /// <summary>
    /// Performs rotation in Euclidean space of points in xy plane counterclockwise
    /// through an angle theta (in radians) about the origin of a 2D Cartesian coordinate system.
    /// The direction of vector rotation is counterclockwise if theta is positive
    /// and clockwise if theta is negative.
    /// </summary>
    /// <param name="theta">radians</param>
    public static Matrix Rotation2(double theta)
    {
        double sin = Math.Sin(theta);
        double cos = Math.Cos(theta);

        return new Matrix(
            new double[,]
            {
                { cos, -sin },
                { sin, cos }
            }
        );
    }

    // Basic 3D Rotation
    /// <summary>
    /// Rotation of a vector by an angle theta (in radians) about the x-axis.
    /// Use the right-hand-rule.
    /// Corresponds to a Roll rotation
    /// </summary>
    /// param name="theta"></param>
    public static Matrix RotationX(double theta)
    {
        double sin = Math.Sin(theta);
        double cos = Math.Cos(theta);

        return new Matrix(
            new double[,]
            {
                { 1, 0, 0 },
                { 0, cos, -sin },
                { 0, sin, cos }
            }
        );
    }

    /// <summary>
    /// Rotation of a vector by an angle theta (in radians) about the y-axis.
    /// Use the right-hand-rule.
    /// Corresponds to a Pitch rotation
    /// </summary>
    /// param name="theta"></param>
    public static Matrix RotationY(double theta)
    {
        double sin = Math.Sin(theta);
        double cos = Math.Cos(theta);

        return new Matrix(
            new double[,]
            {
                { cos, 0, sin },
                { 0, 1, 0 },
                { -sin, 0, cos }
            }
        );
    }

    /// <summary>
    /// Rotation of a vector by an angle theta (in radians) about the z-axis.
    /// Use the right-hand-rule.
    /// Corresponds to Yaw rotation
    /// </summary>
    /// param name="theta"></param>
    public static Matrix RotationZ(double theta)
    {
        double sin = Math.Sin(theta);
        double cos = Math.Cos(theta);

        return new Matrix(
            new double[,]
            {
                { cos, -sin, 0 },
                { sin, cos, 0 },
                { 0, 0, 1 }
            }
        );
    }

    /// <summary>
    /// Represents a rotation whose yaw, pitch and roll angles are alpha, beta
    /// and gamma. It is an intrinsic rotation whose whose Tait–Bryan angles
    /// are α, β, γ, about axes z, y, x, respectively.
    /// </summary>
    /// <param name="alpha"></param>
    /// <param name="beta"></param>
    /// <param name="gamma"></param>
    public static Matrix GeneralIntrinsic3DRotation(double alpha, double beta, double gamma)
    {
        Matrix rotationZ = RotationZ(alpha);
        Matrix rotationY = RotationY(beta);
        Matrix rotationX = RotationX(gamma);

        return (Matrix)(rotationZ * rotationY * rotationX);
    }

    /// <summary>
    /// Represents a rotation whose yaw, pitch and roll angles are alpha, beta
    /// and gamma.
    /// Represents an extrinsic rotation whose (improper) Euler angles are α, β, γ, about axes x, y, z.
    /// </summary>
    /// <param name="alpha"></param>
    /// <param name="beta"></param>
    /// <param name="gamma"></param>
    public static Matrix GeneralExtrinsic3DRotation(double alpha, double beta, double gamma)
    {
        Matrix rotationX = RotationX(alpha);
        Matrix rotationY = RotationY(beta);
        Matrix rotationZ = RotationZ(gamma);

        return (Matrix)(rotationZ * rotationY * rotationX);
    }
}
