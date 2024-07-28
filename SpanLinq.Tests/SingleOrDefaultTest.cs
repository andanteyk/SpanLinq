namespace SpanLinq.Tests;

[TestClass]
public class SingleOrDefaultTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(1, SpanEnumerable.Range(1, 1).SingleOrDefault());
        Assert.AreEqual(5, SpanEnumerable.Range(1, 10).SingleOrDefault(i => i == 5));

        Assert.AreEqual(0, SpanEnumerable.Empty<int>().SingleOrDefault());
        Assert.AreEqual(-1, SpanEnumerable.Range(0, 10).SingleOrDefault(-1));
    }
}
