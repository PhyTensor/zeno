namespace Zeno.Tests;

using Zeno.Core.Matrices;
using Zeno.Core.Transformations;
using Zeno.Core.Vectors;

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
        var rotationMatrix = TransformationMatrix.Rotation2(Math.PI / 2); // 90 degrees
        var vector = new Vector(1, 0);

        var result = rotationMatrix * vector;

        Assert.Equal(0, Math.Round(result[0], 2));
        Assert.Equal(1, Math.Round(result[1], 2));
    }
}
