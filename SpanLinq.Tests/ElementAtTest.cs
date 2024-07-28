namespace SpanLinq.Tests;

[TestClass]
public class ElementAtTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(3, SpanEnumerable.Range(0, 10).ElementAt(3));
        Assert.AreEqual(3, SpanEnumerable.Range(0, 10).ElementAt(new Index(3)));
        Assert.AreEqual(7, SpanEnumerable.Range(0, 10).ElementAt(^3));

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => SpanEnumerable.Range(0, 10).ElementAt(-1));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => SpanEnumerable.Range(0, 10).ElementAt(10));
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => SpanEnumerable.Range(0, 10).ElementAt(^11));
    }
}
