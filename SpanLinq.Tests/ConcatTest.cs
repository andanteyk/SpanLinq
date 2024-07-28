namespace SpanLinq.Tests;

[TestClass]
public class ConcatTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6 },
            SpanEnumerable.Range(1, 3).Concat(SpanEnumerable.Range(4, 3)).AsSpan().ToArray());

        CollectionAssert.AreEqual(new int[] { 1, 2, 3 },
            SpanEnumerable.Range(1, 3).Concat(SpanEnumerable.Empty<int>()).AsSpan().ToArray());

        //SpanEnumerable.Range(1, 3).Concat2(SpanEnumerable.Range(4, 3)).AsSpan();
    }
}
