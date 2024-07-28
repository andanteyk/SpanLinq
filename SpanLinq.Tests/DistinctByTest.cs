namespace SpanLinq.Tests;

[TestClass]
public class DistinctByTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3, 4 },
            SpanEnumerable.Range(0, 60).DistinctBy(i => i % 5).ToArray());

        CollectionAssert.AreEqual(new int?[] { null, 0, 1 },
            new int?[] { null, null, 0, 5, 1 }.AsSpan().DistinctBy(i => i % 5).ToArray());
    }
}
