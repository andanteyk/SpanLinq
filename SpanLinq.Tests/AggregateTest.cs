namespace SpanLinq.Tests;

[TestClass]
public class AggregateTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(55, SpanEnumerable.Range(1, 10).Aggregate((current, next) => current + next));
        Assert.AreEqual(66, SpanEnumerable.Range(1, 10).Aggregate(11, (current, next) => current + next));
        Assert.AreEqual("66", SpanEnumerable.Range(1, 10).Aggregate(11, (current, next) => current + next, i => i.ToString()));

        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<int>().Aggregate((current, next) => current + next));
    }
}
