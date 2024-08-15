namespace Zeno.Core.Matrices;

public interface IMatrix
{
    int Rows { get; }
    int Columns { get; }
    String Shape { get; }
}

public interface IMatrix2 : IMatrix { }

public interface IMatrix3 : IMatrix { }

public interface IMatrix4 : IMatrix { }
