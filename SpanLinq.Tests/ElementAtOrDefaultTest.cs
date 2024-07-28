namespace SpanLinq.Tests;

[TestClass]
public class ElementAtOrDefaultTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(3, SpanEnumerable.Range(0, 10).ElementAtOrDefault(3));
        Assert.AreEqual(3, SpanEnumerable.Range(0, 10).ElementAtOrDefault(new Index(3)));
        Assert.AreEqual(7, SpanEnumerable.Range(0, 10).ElementAtOrDefault(^3));

        Assert.AreEqual(0, SpanEnumerable.Range(0, 10).ElementAtOrDefault(-1));
        Assert.AreEqual(0, SpanEnumerable.Range(0, 10).ElementAtOrDefault(10));
        Assert.AreEqual(0, SpanEnumerable.Range(0, 10).ElementAtOrDefault(^11));
    }
}
