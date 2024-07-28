namespace SpanLinq.Tests;

[TestClass]
public class ToHashSetTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(
            Enumerable.Range(0, 10).ToHashSet().ToArray(),
            SpanEnumerable.Range(0, 10).ToHashSet().ToArray());

        CollectionAssert.AreEqual(
            new HashSet<int>().ToArray(),
            SpanEnumerable.Empty<int>().ToHashSet().ToArray());

        CollectionAssert.AreEqual(
            new HashSet<int>() { 0 }.ToArray(),
            SpanEnumerable.Repeat(0, 10).ToHashSet().ToArray());
    }
}
