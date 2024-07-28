namespace SpanLinq.Tests;

[TestClass]
public class SkipLastTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7 }, SpanEnumerable.Range(1, 10).SkipLast(3).ToArray());
        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Range(1, 10).SkipLast(10).ToArray());

        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Empty<int>().SkipLast(1).ToArray());
        CollectionAssert.AreEqual(Enumerable.Range(0, 10).ToArray(), SpanEnumerable.Range(0, 10).SkipLast(-123).ToArray());
    }
}
