namespace SpanLinq.Tests;

[TestClass]
public class ConcatTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6 },
            SpanEnumerable.Range(1, 3).Concat(SpanEnumerable.Range(4, 3)).ToArray());

        CollectionAssert.AreEqual(new int[] { 1, 2, 3 },
            SpanEnumerable.Range(1, 3).Concat(SpanEnumerable.Empty<int>()).ToArray());

        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6 },
            SpanEnumerable.Range(1, 3).ToArray().AsSpan().Concat(SpanEnumerable.Range(4, 3).ToArray()).ToArray());
    }
}
