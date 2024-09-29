using System.Numerics;
using Zeno.Core.Matrices;

namespace Zeno.Quantum;

/// <summary>
/// The evolution os an isolated quantum system is completely descrubed by a unitary operator.
/// A complex square matric U \in \mathcal{C}^{2x2} is unitary if and only if its inverse is the same as its
// Hermitian transpose, i.e. U^{-1} = U^\dagger.
/// </summary>
public static class Operators
{
    private static readonly Complex i = Complex.ImaginaryOne;
    private static readonly double InvSqrtTwo = 1.0 / Math.Sqrt(2);

    public static CMatrix Identity()
    {
        return new CMatrix(
            new Complex[,]
            {
                { 1, 0 },
                { 0, 1 }
            }
        );
    }

    public static CMatrix PauliX()
    {
        return new CMatrix(
            new Complex[,]
            {
                { 0, 1 },
                { 1, 0 }
            }
        );
    }

    public static CMatrix PauliZ()
    {
        return new CMatrix(
            new Complex[,]
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

    public static CMatrix Hadamard()
    {
        return new CMatrix(
                new Complex[,]
                {
                    { 1, 1 },
                    { 1, -1 }
                }
            ) * InvSqrtTwo;
    }

    public static CMatrix S()
    {
        return new CMatrix(
            new Complex[,]
            {
                { 1, 0 },
                { 0, i }
            }
        );
    }

    public static CMatrix SDagger()
    {
        return new CMatrix(
            new Complex[,]
            {
                { 1, 0 },
                { 0, i }
            }
        ).ConjugateTranspose();
    }

    public static CMatrix T()
    {
        return new CMatrix(
            new Complex[,]
            {
                { 1, 0 },
                { 0, Complex.Exp(i * Math.PI * 0.25) }
            }
        );
    }

    public static CMatrix TDagger()
    {
        return new CMatrix(
            new Complex[,]
            {
                { 1, 0 },
                { 0, Complex.Exp(i * Math.PI * 0.25) }
            }
        ).ConjugateTranspose();
    }
}
