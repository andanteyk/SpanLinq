namespace SpanLinq.Tests;

[TestClass]
public class UnionTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
            SpanEnumerable.Range(0, 10).Union(SpanEnumerable.Range(8, 5)).AsSpan().ToArray());

        CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            SpanEnumerable.Range(0, 10).Union(SpanEnumerable.Range(3, 5)).AsSpan().ToArray());

        CollectionAssert.AreEqual(new string[] { null!, "a", "b" },
            new string[] { null!, null!, "a", "a", "b" }.AsSpan().Union(new string[] { null!, "a", "a" }).AsSpan().ToArray());
    }
}
