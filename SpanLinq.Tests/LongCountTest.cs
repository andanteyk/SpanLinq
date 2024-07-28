namespace SpanLinq.Tests;

[TestClass]
public class LongCountTest
{
    [TestMethod]
    public void Basic()
    {
        int count = 5;
        var source = (stackalloc int[count]);
        Assert.AreEqual(count, source.LongCount());
        Assert.AreEqual(count, SpanEnumerable.Range(0, count).LongCount());

        Assert.AreEqual(5, SpanEnumerable.Range(0, 10).LongCount(i => i % 2 == 0));
    }
}
