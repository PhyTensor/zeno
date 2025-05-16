// namespace Zeno.Tests;
//
// using Lib.Vectors;
//
// public class TestVector3D
// {
//     [Fact]
//     public void DefaultConstructor_ShouldSetComponentsToZero()
//     {
//         var zeroVector = new Vector3D();
//
//         Assert.Equal(0, zeroVector.X);
//         Assert.Equal(0, zeroVector.Y);
//         Assert.Equal(0, zeroVector.Z);
//     }
//
//     [Theory]
//     [InlineData(0, 0, 0, 0)]
//     [InlineData(1, 0, 0, 1)]
//     [InlineData(0, 1, 0, 1)]
//     [InlineData(0, 0, 1, 1)]
//     [InlineData(1, 2, 3, 3.74165738677)]
//     [InlineData(-1, -2, -2, 3)]
//     public void ComputeNorm_ShouldReturnCorrectValue(
//         double x,
//         double y,
//         double z,
//         double expectedNorm
//     )
//     {
//         var vector = new Vector3D(x, y, z);
//         var norm = vector.Length;
//         norm = Math.Round(norm, 11, MidpointRounding.AwayFromZero);
//
//         Assert.Equal(expectedNorm, norm);
//     }
//
//     [Theory]
//     [InlineData(1, 1, 1, 2, 2, 2, 3, 3, 3)]
//     [InlineData(0, 1, 1, 1, 2, 0, 1, 3, 1)]
//     public void VectorAddition_ShouldReturnCorrectValue(
//         double ax,
//         double ay,
//         double az,
//         double bx,
//         double by,
//         double bz,
//         double cx,
//         double cy,
//         double cz
//     )
//     {
//         var vectora = new Vector3D(ax, ay, az);
//         var vectorb = new Vector3D(bx, by, bz);
//         var vectorc = new Vector3D(cx, cy, cz);
//         var expectedVector = vectora + vectorb;
//
//         Assert.Equal(expectedVector.X, vectorc.X);
//         Assert.Equal(expectedVector.Y, vectorc.Y);
//         Assert.Equal(expectedVector.Z, vectorc.Z);
//     }
//
//     [Fact]
//     public void Constructor_Default_ShouldSetXYZToZero()
//     {
//         var vector = new Vector3();
//         Assert.Equal(0, vector.X);
//         Assert.Equal(0, vector.Y);
//         Assert.Equal(0, vector.Z);
//     }
//
//     [Fact]
//     public void Constructor_WithParameters_ShouldSetXYZ()
//     {
//         var vector = new Vector3(1, 2, 3);
//         Assert.Equal(1, vector.X);
//         Assert.Equal(2, vector.Y);
//         Assert.Equal(3, vector.Z);
//     }
//
//     [Fact]
//     public void Length_ShouldReturnCorrectValue()
//     {
//         var vector = new Vector3(1, 2, 2);
//         Assert.Equal(3, vector.Length, precision: 5);
//     }
//
//     [Fact]
//     public void LengthSquared_ShouldReturnCorrectValue()
//     {
//         var vector = new Vector3(1, 2, 2);
//         Assert.Equal(9, vector.LengthSquared, precision: 5);
//     }
//
//     [Fact]
//     public void Dot_ShouldReturnCorrectValue()
//     {
//         var vector1 = new Vector3(1, 2, 3);
//         var vector2 = new Vector3(4, 5, 6);
//         Assert.Equal(32, vector1.Dot(vector2), precision: 5);
//     }
//
//     [Fact]
//     public void Cross_ShouldReturnCorrectValue()
//     {
//         var vector1 = new Vector3(1, 2, 3);
//         var vector2 = new Vector3(4, 5, 6);
//         var cross = vector1.Cross(vector2);
//         Assert.Equal(-3, cross.X);
//         Assert.Equal(6, cross.Y);
//         Assert.Equal(-3, cross.Z);
//     }
//
//     [Fact]
//     public void Normalize_ShouldReturnUnitVector()
//     {
//         var vector = new Vector3(1, 2, 2);
//         var unitVector = (Vector3)vector.Normalize();
//         Assert.Equal(1, unitVector.Length, precision: 5);
//     }
//
//     [Fact]
//     public void Reverse_ShouldReturnVectorInOppositeDirection()
//     {
//         var vector = new Vector3(1, 2, 3);
//         var reversed = (Vector3)vector.Reverse();
//         Assert.Equal(-1, reversed.X);
//         Assert.Equal(-2, reversed.Y);
//         Assert.Equal(-3, reversed.Z);
//     }
//
//     [Fact]
//     public void Scale_ShouldScaleVector()
//     {
//         var vector = new Vector3(1, 2, 3);
//         var scaled = (Vector3)vector.Scale(2);
//         Assert.Equal(2, scaled.X);
//         Assert.Equal(4, scaled.Y);
//         Assert.Equal(6, scaled.Z);
//     }
//
//     [Fact]
//     public void AngleBetween_ShouldReturnCorrectAngle()
//     {
//         var vector1 = new Vector3(1, 0, 0);
//         var vector2 = new Vector3(0, 1, 0);
//         Assert.Equal(Math.PI / 2, vector1.AngleBetween(vector2), precision: 5);
//     }
// }
