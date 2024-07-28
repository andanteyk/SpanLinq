namespace SpanLinq.Tests;

[TestClass]
public class MaxByTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual((Rank: 9, Name: "Test"), SpanEnumerable.Range(0, 10).Select(i => (Rank: i, Name: "Test")).MaxBy(i => i.Rank));
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<int>().MaxBy(i => i));
    }
}
