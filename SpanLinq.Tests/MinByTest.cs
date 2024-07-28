namespace SpanLinq.Tests;

[TestClass]
public class MinByTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual((Rank: 0, Name: "Test"), SpanEnumerable.Range(0, 10).Select(i => (Rank: i, Name: "Test")).MinBy(i => i.Rank));
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<int>().MinBy(i => i));
    }
}
