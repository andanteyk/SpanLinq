namespace SpanLinq.Tests;

[TestClass]
public class TryGetNonEnumeratedCountTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.IsTrue(new int[10].AsSpan().TryGetNonEnumeratedCount(out int length));
        Assert.AreEqual(10, length);

        Assert.IsTrue(SpanEnumerable.Range(0, 10).TryGetNonEnumeratedCount(out length));
        Assert.AreEqual(10, length);

        Assert.IsFalse(SpanEnumerable.Range(0, 10).Where(i => i < 5).TryGetNonEnumeratedCount(out length));
    }
}
