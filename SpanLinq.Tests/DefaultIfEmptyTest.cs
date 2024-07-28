namespace SpanLinq.Tests;

[TestClass]
public class DefaultIfEmptyTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, SpanEnumerable.Range(1, 3).DefaultIfEmpty(-1).ToArray());
        CollectionAssert.AreEqual(new int[] { 0 }, SpanEnumerable.Empty<int>().DefaultIfEmpty().ToArray());
        CollectionAssert.AreEqual(new int[] { -1 }, SpanEnumerable.Empty<int>().DefaultIfEmpty(-1).ToArray());
    }
}
