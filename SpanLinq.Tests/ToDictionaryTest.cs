namespace SpanLinq.Tests;

[TestClass]
public class ToDictionaryTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(
            Enumerable.Range(0, 10).ToDictionary(key => key, value => value * 2),
            SpanEnumerable.Range(0, 10).ToDictionary(key => key, value => value * 2));

        CollectionAssert.AreEqual(
            new Dictionary<int, int>(),
            SpanEnumerable.Empty<int>().ToDictionary(key => key, value => value * 2));

        Assert.ThrowsException<ArgumentException>(() => SpanEnumerable.Repeat(0, 10).ToDictionary(key => key));
    }
}
