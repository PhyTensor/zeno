namespace Tests;

using Lib.Matrices;
using Lib.Vectors;
using static Lib.Transformations.Rotation;

public class TestMatrices
{
    [Fact]
    public void IdentityMatrix_ShouldCreateCorrectMatrix()
    {
        var identity = Matrix.Identity(3);

        var expected = new double[,]
        {
            { 1, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 }
        };

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                Assert.Equal(expected[i, j], identity[i, j]);
    }

    [Fact]
    public void MatrixAddition_ShouldAddCorrectly()
    {
        var a = new Matrix(
            new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            }
        );

        var b = new Matrix(
            new double[,]
            {
                { 5, 6 },
                { 7, 8 }
            }
        );

        var result = a + b;

        Assert.Equal(6, result[0, 0]);
        Assert.Equal(8, result[0, 1]);
        Assert.Equal(10, result[1, 0]);
        Assert.Equal(12, result[1, 1]);
    }

    [Fact]
    public void MatrixSubtraction_ShouldSubtractCorrectly()
    {
        var a = new Matrix(
            new double[,]
            {
                { 5, 6 },
                { 7, 8 }
            }
        );

        var b = new Matrix(
            new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            }
        );

        var result = a - b;

        Assert.Equal(4, result[0, 0]);
        Assert.Equal(4, result[0, 1]);
        Assert.Equal(4, result[1, 0]);
        Assert.Equal(4, result[1, 1]);
    }

    [Fact]
    public void MatrixMultiplication_ShouldMultiplyCorrectly()
    {
        var a = new Matrix(
            new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            }
        );

        var b = new Matrix(
            new double[,]
            {
                { 2, 0 },
                { 1, 2 }
            }
        );

        var result = a * b;

        Assert.Equal(4, result[0, 0]);
        Assert.Equal(4, result[0, 1]);
        Assert.Equal(10, result[1, 0]);
        Assert.Equal(8, result[1, 1]);
    }

    [Fact]
    public void MatrixTranspose_ShouldTransposeCorrectly()
    {
        var matrix = new Matrix(
            new double[,]
            {
                { 1, 2 },
                { 3, 4 },
                { 5, 6 }
            }
        );

        var transposed = matrix.Transpose();

        Assert.Equal(1, transposed[0, 0]);
        Assert.Equal(3, transposed[0, 1]);
        Assert.Equal(5, transposed[0, 2]);
        Assert.Equal(2, transposed[1, 0]);
        Assert.Equal(4, transposed[1, 1]);
        Assert.Equal(6, transposed[1, 2]);
    }


    [Fact]
    public void MatrixTensorProduct_ShouldTensorProductCorrectly()
    {
        var a = new Matrix(
            new double[,]
            {
                { 1, 2 },
                { 3, 4 }
            }
        );

        var b = new Matrix(
            new double[,]
            {
                { 5, 6 },
                { 7, 8 }
            }
        );

        Matrix result = a.TensorProduct(b);

        Assert.Equal(6, result[0, 1]);
        Assert.Equal(8, result[1, 1]);
        Assert.Equal(10, result[0, 2]);
        Assert.Equal(12, result[0, 3]);
        Assert.Equal(21, result[3, 0]);
        Assert.Equal(32, result[3, 3]);
    }

    [Fact]
    public void MatrixMultiplication_WithVector_ShouldMultiplyCorrectly()
    {
        var matrix = new Matrix(
            new double[,]
            {
                    { 2, 3 },
                    { 4, 5 }
            }
        );

        var vector = new Vector(1, 2);

        var result = matrix * vector;

        Assert.Equal(8, result[0]);
        Assert.Equal(14, result[1]);
    }
}

public class TransformationMatrixTests
{
    [Fact]
    public void RotationMatrix_ShouldRotateVectorCorrectly()
    {
        Matrix rotationMatrix = Rotation2(Math.PI / 2); // 90 degrees
        var vector = new Vector(1, 0);

        var result = rotationMatrix * vector;

        Assert.Equal(0, Math.Round(result[0], 2));
        Assert.Equal(1, Math.Round(result[1], 2));
    }

    [Theory]
    [InlineData(Math.PI / 2, 1, 0, 0, 1, 0, 0)]
    [InlineData(Math.PI / 2, 0, 0, 1, 0, -1, 0)]
    [InlineData(Math.PI / 2, 0, 1, 0, 0, 0, 1)]
    [InlineData(Math.PI, 0, 1, 0, 0, -1, 0)]
    public void RotationX_ShouldRotateVectorCorrectly(
        double theta,
        double ax,
        double ay,
        double az,
        double bx,
        double by,
        double bz
    )
    {
        Vector3 a = new(ax, ay, az);
        Vector3 b = new(bx, by, bz);
        Vector3 result = RotationX(theta) * a;

        Assert.Equal(b.X, result.X, precision: 5);
        Assert.Equal(b.Y, result.Y, precision: 5);
        Assert.Equal(b.Z, result.Z, precision: 5);
    }

    [Theory]
    [InlineData(Math.PI / 2, 0, 0, 1, 1, 0, 0)]
    [InlineData(Math.PI / 2, 0, 1, 0, 0, 1, 0)]
    [InlineData(Math.PI, 0, 0, 1, 0, 0, -1)]
    public void RotationY_ShouldRotateVectorCorrectly(
        double theta,
        double ax,
        double ay,
        double az,
        double bx,
        double by,
        double bz
    )
    {
        Vector3 a = new(ax, ay, az);
        Vector3 expected = new(bx, by, bz);

        Vector3 result = RotationY(theta) * a;

        Assert.Equal(expected.X, result.X, precision: 5);
        Assert.Equal(expected.Y, result.Y, precision: 5);
        Assert.Equal(expected.Z, result.Z, precision: 5);
    }

    [Theory]
    [InlineData(Math.PI / 2, 0, 1, 0, -1, 0, 0)]
    [InlineData(Math.PI / 2, 1, 0, 0, 0, 1, 0)]
    [InlineData(Math.PI, 1, 0, 0, -1, 0, 0)]
    public void RotationZ_ShouldRotateVectorCorrectly(
        double theta,
        double ax,
        double ay,
        double az,
        double bx,
        double by,
        double bz
    )
    {
        Vector3 a = new(ax, ay, az);
        Vector3 expected = new(bx, by, bz);

        Vector3 result = RotationZ(theta) * a;

        Assert.Equal(expected.X, result.X, precision: 5);
        Assert.Equal(expected.Y, result.Y, precision: 5);
        Assert.Equal(expected.Z, result.Z, precision: 5);
    }
}
