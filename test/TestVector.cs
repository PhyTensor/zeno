namespace Zeno.Tests;

using Zeno.Core.Vectors;

public class TestVector
{
    [Fact]
    public void DefaultContructor_ShouldSetComponentsToZero()
    {
        var vector = new Vector(2);
        Assert.Equal(0, vector.Components[0]);
        Assert.Equal(0, vector.Components[1]);
    }

    [Fact]
    public void Constructor_Params_ShouldSetComponents()
    {
        var vector = new Vector(1, 2, 3);
        Assert.Equal(3, vector.Dimensions);
        Assert.Equal(1, vector[0]);
        Assert.Equal(2, vector[1]);
        Assert.Equal(3, vector[2]);
    }

    [Fact]
    public void Constructor_Dimensions_ShouldInitializeWithZeros()
    {
        var vector = new Vector(3);
        Assert.Equal(3, vector.Dimensions);
        Assert.All(vector.Components, c => Assert.Equal(0, c));
    }

    [Fact]
    public void Constructor_Copy_ShouldCopyComponents()
    {
        var original = new Vector(1, 2, 3);
        var copy = new Vector(original);
        Assert.Equal(original.Components, copy.Components);
    }

    [Fact]
    public void Length_ShouldReturnCorrectValue()
    {
        var vector = new Vector(3, 4);
        Assert.Equal(5, vector.Length, precision: 5);
    }

    [Fact]
    public void LengthSquared_ShouldReturnCorrectValue()
    {
        var vector = new Vector(1, 2, 2);
        Assert.Equal(9, vector.LengthSquared, precision: 5);
    }

    [Fact]
    public void NormManhattan_ShouldReturnCorrectValue()
    {
        var vector = new Vector(1, -2, 3);
        Assert.Equal(6, vector.NormManhattan());
    }

    [Fact]
    public void NormMax_ShouldReturnCorrectValue()
    {
        var vector = new Vector(1, -5, 3);
        Assert.Equal(3, vector.NormMax());
    }

    [Fact]
    public void Normalize_ShouldReturnUnitVector()
    {
        Vector vector = new(3, 4);
        Vector unitVector = (Vector)vector.Normalize();
        Assert.Equal(1, unitVector.Length, precision: 5);
    }

    [Fact]
    public void Reverse_ShouldReturnVectorInOppositeDirection()
    {
        var vector = new Vector(1, -2, 3);
        var reversed = (Vector)vector.Reverse();
        Assert.Equal(-1, reversed[0]);
        Assert.Equal(2, reversed[1]);
        Assert.Equal(-3, reversed[2]);
    }

    [Fact]
    public void Scale_ShouldScaleVector()
    {
        var vector = new Vector(1, 2, 3);
        var scaled = (Vector)vector.Scale(2);
        Assert.Equal(2, scaled[0]);
        Assert.Equal(4, scaled[1]);
        Assert.Equal(6, scaled[2]);
    }

    [Fact]
    public void Dot_ShouldReturnCorrectValue()
    {
        var vector1 = new Vector(1, 2, 3);
        var vector2 = new Vector(4, 5, 6);
        Assert.Equal(32, vector1.Dot(vector2), precision: 5);
    }

    [Fact]
    public void AngleBetween_ShouldReturnCorrectAngle()
    {
        var vector1 = new Vector(1, 0, 0);
        var vector2 = new Vector(0, 1, 0);
        Assert.Equal(Math.PI / 2, vector1.AngleBetween(vector2), precision: 5);
    }

    [Fact]
    public void Addition_ShouldAddTwoVectors()
    {
        var vector1 = new Vector(1, 2, 3);
        var vector2 = new Vector(4, 5, 6);
        var sum = Vector.Addition(vector1, vector2);
        Assert.Equal(new Vector(5, 7, 9).Components, sum.Components);
    }

    [Fact]
    public void Subtraction_ShouldSubtractTwoVectors()
    {
        var vector1 = new Vector(4, 5, 6);
        var vector2 = new Vector(1, 2, 3);
        var difference = Vector.Subtraction(vector1, vector2);
        Assert.Equal(new Vector(3, 3, 3).Components, difference.Components);
    }

    [Fact]
    public void Indexer_Get_ShouldReturnComponentAtIndex()
    {
        var vector = new Vector(1, 2, 3);
        Assert.Equal(2, vector[1]);
    }

    [Fact]
    public void Indexer_Set_ShouldUpdateComponentAtIndex()
    {
        Vector vector = new(1, 2, 3);
        vector[1] = 5;
        Assert.Equal(5, vector[1]);
    }

    [Fact]
    public void Operator_Addition_ShouldAddTwoVectors()
    {
        var vector1 = new Vector(1, 2, 3);
        var vector2 = new Vector(4, 5, 6);
        var sum = vector1 + vector2;
        Assert.Equal(new Vector(5, 7, 9).Components, sum.Components);
    }

    [Fact]
    public void Operator_Subtraction_ShouldSubtractTwoVectors()
    {
        var vector1 = new Vector(4, 5, 6);
        var vector2 = new Vector(1, 2, 3);
        var difference = vector1 - vector2;
        Assert.Equal(new Vector(3, 3, 3).Components, difference.Components);
    }

    [Fact]
    public void Operator_Negation_ShouldReturnNegativeVector()
    {
        var vector = new Vector(1, 2, 3);
        var negated = -vector;
        Assert.Equal(new Vector(-1, -2, -3).Components, negated.Components);
    }

    [Fact]
    public void Operator_Multiplication_ShouldScaleVector()
    {
        var vector = new Vector(1, 2, 3);
        var scaled = 2 * vector;
        Assert.Equal(new Vector(2, 4, 6).Components, scaled.Components);
    }
}
