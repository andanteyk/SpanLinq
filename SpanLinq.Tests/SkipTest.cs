namespace SpanLinq.Tests;

[TestClass]
public class SkipTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 4, 5, 6, 7, 8, 9, 10 }, SpanEnumerable.Range(1, 10).Skip(3).ToArray());
        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Range(1, 10).Skip(10).ToArray());

        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Empty<int>().Skip(1).ToArray());
        CollectionAssert.AreEqual(Enumerable.Range(0, 10).ToArray(), SpanEnumerable.Range(0, 10).Skip(-123).ToArray());
    }
}
