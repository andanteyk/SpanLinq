namespace SpanLinq.Tests;

[TestClass]
public class SumTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(1024 / 2 * (1024 + 1), SpanEnumerable.Range(1, 1024).Sum());
        Assert.AreEqual(1024L / 2 * (1024 + 1), SpanEnumerable.Range(1, 1024).Select(i => (long)i).Sum());
        Assert.AreEqual(1024f / 2 * (1024 + 1), SpanEnumerable.Range(1, 1024).Select(i => (float)i).Sum());
        Assert.AreEqual(1024.0 / 2 * (1024 + 1), SpanEnumerable.Range(1, 1024).Select(i => (double)i).Sum());
        Assert.AreEqual(1024m / 2 * (1024 + 1), SpanEnumerable.Range(1, 1024).Select(i => (decimal)i).Sum());

        Assert.ThrowsException<OverflowException>(() => SpanEnumerable.Range(1 << 30, 8).Sum());

        Assert.AreEqual(1024 * (1024 + 1), SpanEnumerable.Range(1, 1024).Sum(i => i * 2));
        Assert.AreEqual(1024L * (1024 + 1), SpanEnumerable.Range(1, 1024).Select(i => (long)i).Sum(i => i * 2));
        Assert.AreEqual(1024f * (1024 + 1), SpanEnumerable.Range(1, 1024).Select(i => (float)i).Sum(i => i * 2));
        Assert.AreEqual(1024.0 * (1024 + 1), SpanEnumerable.Range(1, 1024).Select(i => (double)i).Sum(i => i * 2));
        Assert.AreEqual(1024m * (1024 + 1), SpanEnumerable.Range(1, 1024).Select(i => (decimal)i).Sum(i => i * 2));

        Assert.AreEqual(0, SpanEnumerable.Range(1, 1024).Sum(i => null));
        Assert.AreEqual(0L, SpanEnumerable.Range(1, 1024).Select(i => (long)i).Sum(i => (long?)null));
        Assert.AreEqual(0f, SpanEnumerable.Range(1, 1024).Select(i => (float)i).Sum(i => (float?)null));
        Assert.AreEqual(0.0, SpanEnumerable.Range(1, 1024).Select(i => (double)i).Sum(i => (double?)null));
        Assert.AreEqual(0m, SpanEnumerable.Range(1, 1024).Select(i => (decimal)i).Sum(i => (decimal?)null));
    }
}
