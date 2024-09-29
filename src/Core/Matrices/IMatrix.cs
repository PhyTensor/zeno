using System.Numerics;

namespace Zeno.Core.Matrices;

/// Matrices in Real number elements
public interface IMatrix
{
    int Rows { get; }
    int Cols { get; }
    string Shape { get; }
    double[,] Elements { get; set; }

    double Trace();
    Matrix Transpose();

    /// <summary>
    /// Maps the 2D array as a sequence of elements in a 1D array
    /// </summary>
    double[] Flatten();
}

/// Matrices with Complex number elements
public interface ICMatrix
{
    int Rows { get; }
    int Cols { get; }
    string Shape { get; }
    Complex[,] Elements { get; set; }

    Complex Trace();
    CMatrix Transpose();
    CMatrix Conjugate();

    /// Conjugate Transpose or Hermitian Transpose.
    CMatrix ConjugateTranspose();

    bool IsHermitian();
    bool IsUnitary();
}
