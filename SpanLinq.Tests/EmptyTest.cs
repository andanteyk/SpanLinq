namespace SpanLinq.Tests;

[TestClass]
public class EmptyTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(0, SpanEnumerable.Empty<int>().ToArray().Length);
    }
}
