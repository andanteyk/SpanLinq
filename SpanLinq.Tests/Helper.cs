namespace SpanLinq.Tests;

public static class Helper
{

}


/// <summary>
/// <see cref="EqualityComparer{T}.Create"/> is not supported at netstandard2.1 
/// </summary>
public class TestEqualityComparer<T> : IEqualityComparer<T>
{
    private readonly Func<T?, T?, bool> FuncEquals;
    private readonly Func<T?, int> FuncGetHashCode;

    private TestEqualityComparer(Func<T?, T?, bool> equals, Func<T?, int>? getHashCode = null)
    {
        FuncEquals = equals;
        FuncGetHashCode = getHashCode ?? (x => x == null ? 0 : x.GetHashCode());
    }

    public static TestEqualityComparer<T> Create(Func<T?, T?, bool> equals, Func<T?, int>? getHashCode = null)
    {
        return new TestEqualityComparer<T>(equals, getHashCode);
    }

    public bool Equals(T? x, T? y)
    {
        return FuncEquals(x, y);
    }

    public int GetHashCode(T? obj)
    {
        return FuncGetHashCode(obj);
    }
}