# zeno

Linear Algebra library

## Vectors

```csharp
public interface IVector
{
    double this[int i] { get; set; }

    double[] Components { get; set; }
    int Dimensions { get; }
    double Length { get; }
    double LengthSquared { get; }
    Vector Unit { get; }

    double AngleBetween(Vector other);
    Vector Conjugate();
    double Dot(Vector other);
    Vector Normalize();
    double NormEuclidean();
    double NormEuclideanSquared();
    double NormManhattan();
    Vector Reverse();
    Vector Rotate(double radians);
    Vector Scale(double scalar);
    Vector TensorProduct(Vector other);
}
```

## Matrices

Complex valued matrices

```csharp
public interface ICMatrix
{
    Complex this[int row, int col] { get; set; }

    int Rows { get; }
    int Cols { get; }
    string Shape { get; }
    Complex[,] Elements { get; set; }

    CMatrix Conjugate();
    CMatrix ConjugateTranspose();
    Complex[] Flatten();
    bool IsHermitian();
    bool isSquare();
    bool IsUnitary();
    CMatrix TensorProduct(CMatrix matrix);
    Complex Trace();
    CMatrix Transpose();
}
```

Real valued matrices

```csharp
public interface IMatrix
{
    double this[int row, int col] { get; set; }

    int Rows { get; }
    int Cols { get; }
    string Shape { get; }
    double[,] Elements { get; set; }

    Matrix Conjugate();
    Matrix ConjugateTranspose();
    double[] Flatten();
    bool IsHermitian();
    bool isSquare();
    bool IsUnitary();
    Matrix TensorProduct(Matrix matrix);
    double Trace();
    Matrix Transpose();
}
```

## Applications

### Quantum Simulator

