using System.Numerics;
using Zeno.Core.Matrices;

namespace Zeno.Quantum;

public static class Operators
{
    private static readonly Complex i = Complex.ImaginaryOne;
    private static readonly double InvSqrtTwo = 1.0 / Math.Sqrt(2);

    public static Matrix PauliX()
    {
        return new Matrix(
            new double[,]
            {
                { 0, 1 },
                { 1, 0 }
            }
        );
    }

    public static Matrix PauliZ()
    {
        return new Matrix(
            new double[,]
            {
                { 1, 0 },
                { 0, -1 }
            }
        );
    }

    public static CMatrix PauliY()
    {
        return new CMatrix(
            new Complex[,]
            {
                { 0, -i },
                { i, 0 }
            }
        );
    }

    public static Matrix Hadamard()
    {
        return new Matrix(
                new double[,]
                {
                    { 1, 1 },
                    { 1, -1 }
                }
            ) * InvSqrtTwo;
    }
}
