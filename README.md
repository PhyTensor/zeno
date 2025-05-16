# zeno

Linear Algebra library

## Vectors


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

## Applications

### Quantum Simulator

