using Lib.Vectors;

namespace Lib.Matrices;

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

    public string Shape
    {
        get => $"{Rows}x{Cols}";
    }

    public double[,] Elements
    {
        get => _elements;
        set => _elements = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Trace()
    {
        if (!isSquare())
            throw new ArgumentException("Matrix must be a square matrix to compute!");

        double trace = 0;
        for (int i = 0; i < Rows; i++)
            trace += _elements[i, i];

        return trace;
    }

    public Matrix Transpose()
    {
        Matrix matrixT = new(Cols, Rows);

        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Cols; j++)
                matrixT[j, i] = _elements[i, j];

        return matrixT;
    }

    public Matrix Conjugate()
    {
        return this;
    }

    /// <summary>
    /// Conjugate Tranpose operation
    /// </summary>
    public Matrix ConjugateTranspose()
    {
        return this.Conjugate().Transpose();
    }

    public Matrix TensorProduct(Matrix matrix)
    {
        return KroneckerProduct(this, matrix);
    }


    public double[] Flatten()
    {
        return _elements.Cast<double>().ToArray();
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

    public static Matrix Identity(int size)
    {
        Matrix matrix = new(size, size);

        for (int i = 0; i < size; i++)
            matrix[i, i] = 1;

        return matrix;
    }

    /// <summary>
    /// </summary>

    // create a static method to calculate the Kronecker product of two matrices
    // the Kronecker product is a matrix that is the product of two matrices
    // where the number of rows and columns of the resulting matrix is the product of the number of rows and columns of the two input matrices
    // for example, if A is a 2x2 matrix and B is a 3x3 matrix, then the Kronecker product of A and B is a 6x9 matrix
    // the Kronecker product of two matrices is calculated by taking the dot product of each row of the first matrix with each column of the second matrix
    // this is done by multiplying each element of the first matrix with each element of the second matrix and summing the results
    // the resulting matrix is then reshaped to have the same number of rows and columns as the original matrices
    // for example, if A is a 2x2 matrix and B is a 3x3 matrix, then the Kronecker product of A and B is a 6x9 matrix
    // the Kronecker product of two matrices is calculated by taking the dot product of each row of the first matrix with each column of the second matrix
    // this is done by multiplying each element of the first matrix with each element of the second matrix and summing the results
    // the resulting matrix is then reshaped to have the same number of rows and columns as the original matrices
    public static Matrix KroneckerProduct(Matrix a, Matrix b)
    {
        int newRows = b.Rows * a.Rows;
        int newCols = b.Cols * a.Cols;
        Matrix result = new(newRows, newCols);

        for (int am = 0; am < a.Rows; am++)
            for (int an = 0; an < a.Cols; an++)
                for (int bm = 0; bm < b.Rows; bm++)
                    for (int bn = 0; bn < b.Cols; bn++)
                        result[am * b.Rows + bm, an * b.Cols + bn] = a[am, an] * b[bm, bn];

        return result;
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

    public static Matrix operator *(Matrix a, double scalar)
    {
        Matrix result = new(a.Rows, a.Cols);

        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Cols; j++)
                result[i, j] = scalar * a[i, j];

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

        double[] result = new double[vector.Dimensions];

        for (int i = 0; i < matrix.Rows; i++)
            for (int j = 0; j < matrix.Cols; j++)
                result[i] += matrix[i, j] * vector[j];

        return new Vector(result);
    }

    public static Vector3 operator *(Matrix matrix, Vector3 vector)
    {
        if (matrix.Cols != vector.Dimensions)
            throw new ArgumentException("Matrix columns must match vector dimenions!");

        double[] result = new double[vector.Dimensions];

        for (int i = 0; i < matrix.Rows; i++)
            for (int j = 0; j < matrix.Cols; j++)
                result[i] += matrix[i, j] * vector[j];

        return new Vector3(result);
    }

    public static Vector2 operator *(Matrix matrix, Vector2 vector)
    {
        if (matrix.Cols != vector.Dimensions)
            throw new ArgumentException("Matrix columns must match vector dimenions!");

        double[] result = new double[vector.Dimensions];

        for (int i = 0; i < matrix.Rows; i++)
            for (int j = 0; j < matrix.Cols; j++)
                result[i] += matrix[i, j] * vector[j];

        return new Vector2(result);
    }
}
