namespace SpanLinq.Tests;

[TestClass]
public class PrependTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 100, 0, 1, 2, 3, 4 }, SpanEnumerable.Range(0, 5).Prepend(100).ToArray());
        CollectionAssert.AreEqual(new int[] { -1 }, SpanEnumerable.Empty<int>().Prepend(-1).ToArray());
    }
}
