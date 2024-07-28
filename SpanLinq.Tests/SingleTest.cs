namespace SpanLinq.Tests;

[TestClass]
public class SingleTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(1, SpanEnumerable.Range(1, 1).Single());
        Assert.AreEqual(5, SpanEnumerable.Range(1, 10).Single(i => i == 5));

        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<int>().Single());
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Range(0, 10).Single());
    }
}
