using System.Numerics;

namespace Lib.Matrices;

public class CMatrix
{
    private Complex[,] _elements;

    public CMatrix(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0)
            throw new ArgumentException("Rows and Columns must be greater than zero");

        Rows = rows;
        Cols = cols;

        _elements = new Complex[rows, cols];
    }

    public CMatrix(Complex[,] elements)
    {
        Rows = elements.GetLength(0);
        Cols = elements.GetLength(1);
        _elements = (Complex[,])elements.Clone();
    }

    public CMatrix(CMatrix matrix)
    {
        _elements = (Complex[,])matrix.Elements.Clone();
    }

    public Complex this[int row, int col]
    {
        get
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                throw new IndexOutOfRangeException("Index is out of range!");

            return _elements[row, col];
        }
        set
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Cols)
                throw new IndexOutOfRangeException("Index is out of range!");

            _elements[row, col] = value;
        }
    }

    public int Rows { get; }

    public int Cols { get; }

    public string Shape
    {
        get => $"{Rows}x{Cols}";
    }

    public Complex[,] Elements
    {
        get => _elements;
        set => _elements = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Complex Trace()
    {
        if (!isSquare())
            throw new ArgumentException("Matrix must be a square matrix to compute!");

        double real = 0, imaginary = 0;
        for (int i = 0; i < Rows; i++)
        {
            real += _elements[i, i].Real;
            imaginary += _elements[i, i].Imaginary;
        }

        return new Complex(real, imaginary);
    }

    /// <summary>
    /// Tranpose operation
    /// </summary>
    public CMatrix Transpose()
    {
        CMatrix matrixT = new(Cols, Rows);

        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                matrixT[j, i] = _elements[i, j];

        return matrixT;
    }

    /// <summary>
    /// Complex conjugation operation
    /// </summary>
    public CMatrix Conjugate()
    {
        CMatrix matrix = new(Rows, Cols);

        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                matrix[i, j] = Complex.Conjugate(_elements[i, j]);

        return matrix;
    }

    /// <summary>
    /// Conjugate Tranpose operation
    /// </summary>
    public CMatrix ConjugateTranspose()
    {
        return this.Conjugate().Transpose();
    }

    public CMatrix TensorProduct(CMatrix matrix)
    {
        return KroneckerProduct(this, matrix);
    }

    public Complex[] Flatten()
    {
        return _elements.Cast<Complex>().ToArray();
    }

    public bool isSquare()
    {
        if (Rows != Cols) return false; else return true;
    }

    public bool IsHermitian()
    {
        throw new NotImplementedException();
    }

    public bool IsUnitary()
    {
        throw new NotImplementedException();
    }

    public static CMatrix Identity(int size)
    {
        CMatrix matrix = new(size, size);

        for (int i = 0; i < size; i++)
            matrix[i, i] = Complex.One;

        return matrix;
    }

    public static CMatrix KroneckerProduct(CMatrix a, CMatrix b)
    {
        int newRows = b.Rows * a.Rows;
        int newCols = b.Cols * a.Cols;
        CMatrix result = new(newRows, newCols);

        for (int am = 0; am < a.Rows; am++)
            for (int an = 0; an < a.Cols; an++)
                for (int bm = 0; bm < b.Rows; bm++)
                    for (int bn = 0; bn < b.Cols; bn++)
                        result[am * b.Rows + bm, an * b.Cols + bn] = a[am, an] * b[bm, bn];

        return result;
    }

    public static CMatrix operator +(CMatrix a, CMatrix b)
    {
        if (!a.Shape.Equals(b.Shape))
            throw new ArgumentException(
                "Matrix addition requires that Matrices must have the same dimensions!"
            );

        CMatrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = Complex.Add(a[i, j], b[i, j]);

        return result;
    }

    public static CMatrix operator +(CMatrix a, Matrix b)
    {
        if (!a.Shape.Equals(b.Shape))
            throw new ArgumentException(
                "Matrix addition requires that Matrices must have the same dimensions!"
            );

        CMatrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = Complex.Add(a[i, j], b[i, j]);

        return result;
    }

    public static CMatrix operator -(CMatrix a, CMatrix b)
    {
        if (!a.Shape.Equals(b.Shape))
            throw new ArgumentException(
                "Matrix subtraction requires that Matrices must have the same dimensions!"
            );

        CMatrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = Complex.Subtract(a[i, j], b[i, j]);

        return result;
    }

    public static CMatrix operator -(CMatrix a, Matrix b)
    {
        if (!a.Shape.Equals(b.Shape))
            throw new ArgumentException(
                "Matrix subtraction requires that Matrices must have the same dimensions!"
            );

        CMatrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = Complex.Subtract(a[i, j], b[i, j]);

        return result;
    }

    public static CMatrix operator *(CMatrix a, double scalar)
    {
        CMatrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = scalar * a[i, j];

        return result;
    }

    public static CMatrix operator *(CMatrix a, CMatrix b)
    {
        if (!a.Shape.Equals(b.Shape))
            throw new ArgumentException(
                "Matrix multiplication requires that Matrices must have the same dimensions!"
            );

        CMatrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                for (int k = 0; k < a.Cols; k++)
                    result[i, j] += Complex.Multiply(a[i, k], b[k, j]);

        return result;
    }

    public static CMatrix operator *(CMatrix a, Matrix b)
    {
        if (!a.Shape.Equals(b.Shape))
            throw new ArgumentException(
                "Matrix multiplication requires that Matrices must have the same dimensions!"
            );

        CMatrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                for (int k = 0; k < a.Cols; k++)
                    result[i, j] += Complex.Multiply(a[i, k], b[k, j]);

        return result;
    }
}
