namespace SpanLinq.Tests;

[TestClass]
public class ToListTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(
            Enumerable.Range(0, 10).ToList(),
            SpanEnumerable.Range(0, 10).ToList());

        CollectionAssert.AreEqual(
            new List<int>(),
            SpanEnumerable.Empty<int>().ToList());
    }
}
