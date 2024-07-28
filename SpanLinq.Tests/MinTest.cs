namespace SpanLinq.Tests;

[TestClass]
public class MinTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(0, SpanEnumerable.Range(0, 10).Min());
        Assert.AreEqual(0L, SpanEnumerable.Range(0, 10).Select(i => (long)i).Min());
        Assert.AreEqual(0f, SpanEnumerable.Range(0, 10).Select(i => (float)i).Min());
        Assert.AreEqual(0.0, SpanEnumerable.Range(0, 10).Select(i => (double)i).Min());
        Assert.AreEqual(0m, SpanEnumerable.Range(0, 10).Select(i => (decimal)i).Min());

        Assert.AreEqual(0, SpanEnumerable.Range(0, 10).Select(i => (int?)i).Append(null).Min());
        Assert.AreEqual(0L, SpanEnumerable.Range(0, 10).Select(i => (long?)i).Append(null).Min());
        Assert.AreEqual(0f, SpanEnumerable.Range(0, 10).Select(i => (float?)i).Append(null).Min());
        Assert.AreEqual(0.0, SpanEnumerable.Range(0, 10).Select(i => (double?)i).Append(null).Min());
        Assert.AreEqual(0m, SpanEnumerable.Range(0, 10).Select(i => (decimal?)i).Append(null).Min());

        Assert.AreEqual(null, SpanEnumerable.Repeat((int?)null, 10).Min());
        Assert.AreEqual(null, SpanEnumerable.Repeat((long?)null, 10).Min());
        Assert.AreEqual(null, SpanEnumerable.Repeat((float?)null, 10).Min());
        Assert.AreEqual(null, SpanEnumerable.Repeat((double?)null, 10).Min());
        Assert.AreEqual(null, SpanEnumerable.Repeat((decimal?)null, 10).Min());

        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<int>().Min());
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<long>().Min());
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<float>().Min());
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<double>().Min());
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<decimal>().Min());

        Assert.AreEqual(null, SpanEnumerable.Empty<int?>().Min());
        Assert.AreEqual(null, SpanEnumerable.Empty<long?>().Min());
        Assert.AreEqual(null, SpanEnumerable.Empty<float?>().Min());
        Assert.AreEqual(null, SpanEnumerable.Empty<double?>().Min());
        Assert.AreEqual(null, SpanEnumerable.Empty<decimal?>().Min());

        Assert.AreEqual(0, SpanEnumerable.Range(0, 10).Min(i => i * 10));
        Assert.AreEqual(0L, SpanEnumerable.Range(0, 10).Select(i => (long)i).Min(i => i * 10));
        Assert.AreEqual(0f, SpanEnumerable.Range(0, 10).Select(i => (float)i).Min(i => i * 10));
        Assert.AreEqual(0.0, SpanEnumerable.Range(0, 10).Select(i => (double)i).Min(i => i * 10));
        Assert.AreEqual(0m, SpanEnumerable.Range(0, 10).Select(i => (decimal)i).Min(i => i * 10));

        Assert.AreEqual(0, SpanEnumerable.Range(0, 10).Select(i => (int?)i).Append(null).Min(i => i * 10));
        Assert.AreEqual(0L, SpanEnumerable.Range(0, 10).Select(i => (long?)i).Append(null).Min(i => i * 10));
        Assert.AreEqual(0f, SpanEnumerable.Range(0, 10).Select(i => (float?)i).Append(null).Min(i => i * 10));
        Assert.AreEqual(0.0, SpanEnumerable.Range(0, 10).Select(i => (double?)i).Append(null).Min(i => i * 10));
        Assert.AreEqual(0m, SpanEnumerable.Range(0, 10).Select(i => (decimal?)i).Append(null).Min(i => i * 10));
    }
}
