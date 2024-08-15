using Zeno.Core.Vectors;

namespace Zeno.Core.Matrices;

public class Matrix
{
    private double[,] _elements;

    public Matrix(int rows, int cols)
    {
        if (rows <= 0 || cols <= 0)
            throw new ArgumentException("Rows and Columns must be greater than zero!");

        Rows = rows;
        Cols = cols;

        _elements = new double[rows, cols];
    }

    public Matrix(double[,] elements)
    {
        Rows = elements.GetLength(0);
        Cols = elements.GetLength(1);
        _elements = (double[,])elements.Clone();
    }

    public Matrix(Matrix matrix)
    {
        _elements = (double[,])matrix.Elements.Clone();
    }

    public double this[int row, int col]
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
    public String Shape
    {
        get => $"{Rows}x{Cols}";
    }
    public double[,] Elements
    {
        get => _elements;
        set => _elements = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Matrix Transpose()
    {
        Matrix matrixT = new(Cols, Rows);

        for (int i = 0; i < Rows; i++)
        for (int j = 0; j < Cols; j++)
            matrixT[j, i] = _elements[i, j];

        return matrixT;
    }

    public static Matrix Identity(int size)
    {
        Matrix matrix = new(size, size);

        for (int i = 0; i < size; i++)
            matrix[i, i] = 1;

        return matrix;
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (!a.Shape.Equals(b.Shape))
            throw new ArgumentException(
                "Matrix addition requires that Matrices must have the same dimensions!"
            );

        Matrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
        for (int j = 0; j < a.Cols; j++)
            result[i, j] = a[i, j] + b[i, j];

        return result;
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (!a.Shape.Equals(b.Shape))
            throw new ArgumentException(
                "Matrix subtration requires that Matrices must have the same dimensions!"
            );

        Matrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
        for (int j = 0; j < a.Cols; j++)
            result[i, j] = a[i, j] - b[i, j];

        return result;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (!a.Shape.Equals(b.Shape))
            throw new ArgumentException(
                "Matrix multiplication requires that Matrices must have the same dimensions!"
            );

        Matrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
        for (int j = 0; j < a.Cols; j++)
        for (int k = 0; k < a.Cols; k++)
            result[i, j] += a[i, k] * b[k, j];

        return result;
    }

    public static Vector operator *(Matrix matrix, Vector vector)
    {
        if (matrix.Cols != vector.Dimensions)
            throw new ArgumentException("Matrix columns must match vector dimenions!");

        double[] result = new double[matrix.Rows];

        for (int i = 0; i < matrix.Rows; i++)
        for (int j = 0; j < matrix.Cols; j++)
            result[i] += matrix[i, j] * vector[j];

        return new Vector(result);
    }
}
