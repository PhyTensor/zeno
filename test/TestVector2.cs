// namespace Zeno.Tests;
//
// using Lib.Vectors;
//
// public class TestVector2D
// {
//     [Fact]
//     public void Constructor_Default_ShouldSetXAndYToZero()
//     {
//         Vector2 vector = new();
//         Assert.Equal(0, vector.X);
//         Assert.Equal(0, vector.Y);
//     }
//
//     [Fact]
//     public void Constructor_WithParameters_ShouldSetXAndY()
//     {
//         Vector2 vector = new(3, 4);
//         Assert.Equal(3, vector.X);
//         Assert.Equal(4, vector.Y);
//     }
//
//     [Fact]
//     public void Length_ShouldReturnCorrectvalue()
//     {
//         Vector2 vector = new(3, 4);
//         Assert.Equal(5, vector.Length, precision: 5);
//     }
//
//     [Fact]
//     public void LengthSquared_ShouldReturnCorrectvalue()
//     {
//         Vector2 vector = new(3, 4);
//         Assert.Equal(25, vector.LengthSquared, precision: 5);
//     }
//
//     [Fact]
//     public void Dot_ShouldReturnCorrectValue()
//     {
//         var vector1 = new Vector2(1, 2);
//         var vector2 = new Vector2(3, 4);
//         Assert.Equal(11, vector1.Dot(vector2), precision: 5);
//     }
//
//     [Fact]
//     public void Normalize_ShouldReturnUnitVector()
//     {
//         Vector2 vector = new(3, 4);
//         Vector2 unitVector = (Vector2)vector.Normalize();
//         Assert.Equal(1, unitVector.Length, precision: 5);
//     }
//
//     [Fact]
//     public void Reverse_ShouldReturnVectorInOppositeDirection()
//     {
//         Vector2 vector = new(3, 4);
//         Vector2 reversed = (Vector2)vector.Reverse();
//         Assert.Equal(-3, reversed.X);
//         Assert.Equal(-4, reversed.Y);
//     }
//
//     [Fact]
//     public void Scale_ShouldScaleVector()
//     {
//         Vector2 vector = new(3, 4);
//         Vector2 scaled = (Vector2)vector.Scale(2);
//         Assert.Equal(6, scaled.X);
//         Assert.Equal(8, scaled.Y);
//     }
//
//     [Fact]
//     public void AngleBetween_ShouldReturnCorrectAngle()
//     {
//         var vector1 = new Vector2(1, 0);
//         var vector2 = new Vector2(0, 1);
//         Assert.Equal(Math.PI / 2, vector1.AngleBetween(vector2), precision: 5);
//     }
//
//     // [Fact]
//     // public void Rotate_ShouldRotateVectorByGivenRadians()
//     // {
//     //     var vector = new Vector2(1, 0);
//     //     Vector2 rotated = (Vector2)vector.Rotate(Math.PI / 2) ;
//     //     Assert.Equal(0, rotated.X, precision: 5);
//     //     Assert.Equal(1, rotated.Y, precision: 5);
//     // }
// }
