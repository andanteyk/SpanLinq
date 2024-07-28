namespace SpanLinq.Tests;

[TestClass]
public class FirstTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(1, SpanEnumerable.Range(1, 1).First());
        Assert.AreEqual(2, SpanEnumerable.Range(1, 10).First(i => i % 3 == 2));

        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<int>().First());
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Range(0, 10).First(i => i > 20));
    }
}
