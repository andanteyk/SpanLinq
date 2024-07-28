namespace SpanLinq.Tests;

[TestClass]
public class ToArrayTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(
            Enumerable.Range(0, 10).ToArray(),
            SpanEnumerable.Range(0, 10).ToArray());

        CollectionAssert.AreEqual(
            new int[0],
            SpanEnumerable.Empty<int>().ToArray());
    }
}
