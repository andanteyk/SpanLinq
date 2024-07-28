namespace SpanLinq.Tests;

[TestClass]
public class AnyTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(true, SpanEnumerable.Range(0, 10).Any(i => i == 2));
        Assert.AreEqual(false, SpanEnumerable.Range(0, 10).Any(i => i < 0));

        Assert.AreEqual(false, SpanEnumerable.Empty<int>().Any(i => true));
    }
}
