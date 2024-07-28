namespace SpanLinq.Tests;

[TestClass]
public class SkipWhileTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 6, 7, 8, 9, 10 }, SpanEnumerable.Range(1, 10).SkipWhile(i => i < 3).ToArray());
        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Range(1, 10).SkipWhile(i => i <= 10).ToArray());

        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Empty<int>().SkipWhile(_ => true).ToArray());
        CollectionAssert.AreEqual(Enumerable.Range(0, 10).ToArray(), SpanEnumerable.Range(0, 10).SkipWhile(_ => false).ToArray());
    }
}
