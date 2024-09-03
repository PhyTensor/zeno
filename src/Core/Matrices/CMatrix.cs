using System.Numerics;

namespace Zeno.Core.Matrices;

public class CMatrix : ICMatrix
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
        double real = 0,
            imaginary = 0;

        for (int i = 0; i < Rows; i++)
        {
            real += _elements[i, i].Real;
            imaginary += _elements[i, i].Imaginary;
        }

        return new Complex(real, imaginary);
    }

    public CMatrix Transpose()
    {
        CMatrix matrixT = new(Cols, Rows);

        for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Cols; j++)
            matrixT[j, i] = _elements[i, j];

        return matrixT;
    }

    public CMatrix Conjugate()
    {
        CMatrix matrix = new(Rows, Cols);

        for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Cols; j++)
            matrix[i, j] = Complex.Conjugate(_elements[i, j]);

        return matrix;
    }

    public CMatrix ConjugateTranspose()
    {
        CMatrix matrix = Conjugate();
        return matrix.Transpose();
    }

    public static CMatrix Identity(int size)
    {
        CMatrix matrix = new(size, size);

        for (int i = 0; i < size; i++)
            matrix[i, i] = Complex.One;

        return matrix;
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
