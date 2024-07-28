namespace SpanLinq.Tests;

[TestClass]
public class ExceptTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 5, 6, 7, 8, 9 }, SpanEnumerable.Range(0, 10).Except(SpanEnumerable.Range(0, 5)).AsSpan().ToArray());
        CollectionAssert.AreEqual(new int[] { 0, 1, 2, 5 }, new int[] { 0, 0, 1, 2, 3, 4, 4, 5 }.AsSpan().Except(new int[] { 3, 4 }).AsSpan().ToArray());
    }
}
