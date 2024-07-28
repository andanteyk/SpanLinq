namespace SpanLinq.Tests;

[TestClass]
public class ToLookupTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(
            Enumerable.Range(0, 10).ToLookup(i => i).SelectMany(i => i).ToList(),
            SpanEnumerable.Range(0, 10).ToLookup(i => i).SelectMany(i => i).ToList());

        CollectionAssert.AreEqual(
            Enumerable.Empty<int>().ToLookup(i => i).SelectMany(i => i).ToList(),
            SpanEnumerable.Empty<int>().ToLookup(i => i).SelectMany(i => i).ToList());
    }
}
