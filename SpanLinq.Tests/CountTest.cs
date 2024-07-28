namespace SpanLinq.Tests;

[TestClass]
public class CountTest
{
    [TestMethod]
    public void Basic()
    {
        int count = 5;
        var source = (stackalloc int[count]);
        Assert.AreEqual(count, source.Count());
        Assert.AreEqual(count, SpanEnumerable.Range(0, count).Count());

        Assert.AreEqual(5, SpanEnumerable.Range(0, 10).Count(i => i % 2 == 0));
    }
}
