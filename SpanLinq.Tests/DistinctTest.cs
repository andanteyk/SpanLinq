namespace SpanLinq.Tests;

[TestClass]
public class DistinctTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3, 4 },
            SpanEnumerable.Range(0, 60).Select(i => i % 5).Distinct().ToArray());

        CollectionAssert.AreEqual(new int?[] { null, 0, 1 },
            new int?[] { null, null, 0, 0, 1 }.AsSpan().Distinct().ToArray());
    }
}
