namespace SpanLinq.Tests;

[TestClass]
public class LastTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(1, SpanEnumerable.Range(1, 1).Last());
        Assert.AreEqual(8, SpanEnumerable.Range(1, 10).Last(i => i % 3 == 2));

        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<int>().Last());
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Range(0, 10).Last(i => i > 20));
    }
}
