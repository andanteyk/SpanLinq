namespace SpanLinq.Tests;

[TestClass]
public class LastOrDefaultTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(1, SpanEnumerable.Range(1, 1).LastOrDefault());
        Assert.AreEqual(8, SpanEnumerable.Range(1, 10).LastOrDefault(i => i % 3 == 2));

        Assert.AreEqual(-1, SpanEnumerable.Empty<int>().LastOrDefault(-1));
        Assert.AreEqual(-1, SpanEnumerable.Range(0, 10).LastOrDefault(i => i > 20, -1));
    }
}
