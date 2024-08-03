namespace SpanLinq.Tests;

[TestClass]
public class ContainsTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(true, SpanEnumerable.Range(0, 10).Contains(4));
        Assert.AreEqual(false, SpanEnumerable.Range(0, 10).Contains(10));

        Assert.AreEqual(false, SpanEnumerable.Empty<int>().Contains(2));

        Assert.AreEqual(true, SpanEnumerable.Range(0, 10).Contains(12, TestEqualityComparer<int>.Create((a, b) => a % 6 == b % 6)));
    }
}
