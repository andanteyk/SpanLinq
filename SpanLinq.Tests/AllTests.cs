namespace SpanLinq.Tests;

[TestClass]
public class AllTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(true, SpanEnumerable.Range(0, 10).All(i => i >= 0));
        Assert.AreEqual(false, SpanEnumerable.Range(0, 10).All(i => i <= 5));

        Assert.AreEqual(true, SpanEnumerable.Empty<int>().All(i => false));
    }
}
