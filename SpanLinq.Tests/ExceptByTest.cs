namespace SpanLinq.Tests;

[TestClass]
public class ExceptByTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 5 }, SpanEnumerable.Range(0, 10).ExceptBy(SpanEnumerable.Range(0, 5), i => i % 6).ToArray());
        CollectionAssert.AreEqual(new int[] { 0, 1, 2, 5 }, new int[] { 0, 0, 1, 2, 3, 4, 4, 5, 9 }.AsSpan().ExceptBy(new int[] { 3, 4 }, i => i % 6).ToArray());
    }
}
