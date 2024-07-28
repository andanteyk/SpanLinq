namespace SpanLinq.Tests;

[TestClass]
public class SequenceEqualTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.IsTrue(SpanEnumerable.Range(0, 10).SequenceEqual(SpanEnumerable.Range(0, 10)));
        Assert.IsFalse(SpanEnumerable.Range(0, 10).SequenceEqual(SpanEnumerable.Range(0, 10).Reverse()));
        Assert.IsFalse(SpanEnumerable.Range(0, 10).SequenceEqual(SpanEnumerable.Range(0, 9)));
        Assert.IsTrue(SpanEnumerable.Repeat("apple", 3).SequenceEqual(SpanEnumerable.Repeat("Apple", 3), StringComparer.OrdinalIgnoreCase));

        Assert.IsTrue(SpanEnumerable.Empty<string>().SequenceEqual(SpanEnumerable.Empty<string>()));
        Assert.IsTrue(Enumerable.Range(0, 10).ToArray().AsSpan().SequenceEqual(Enumerable.Range(0, 10).ToArray()));
    }
}
