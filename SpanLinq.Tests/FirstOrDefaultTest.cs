namespace SpanLinq.Tests;

[TestClass]
public class FirstOrDefaultTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(1, SpanEnumerable.Range(1, 1).FirstOrDefault());
        Assert.AreEqual(2, SpanEnumerable.Range(1, 10).FirstOrDefault(i => i % 3 == 2));

        Assert.AreEqual(0, SpanEnumerable.Empty<int>().FirstOrDefault());
        Assert.AreEqual(-1, SpanEnumerable.Range(0, 10).FirstOrDefault(i => i > 20, -1));
    }
}
