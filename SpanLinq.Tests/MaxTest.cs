namespace SpanLinq.Tests;

[TestClass]
public class MaxTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(9, SpanEnumerable.Range(0, 10).Max());
        Assert.AreEqual(9L, SpanEnumerable.Range(0, 10).Select(i => (long)i).Max());
        Assert.AreEqual(9f, SpanEnumerable.Range(0, 10).Select(i => (float)i).Max());
        Assert.AreEqual(9.0, SpanEnumerable.Range(0, 10).Select(i => (double)i).Max());
        Assert.AreEqual(9m, SpanEnumerable.Range(0, 10).Select(i => (decimal)i).Max());

        Assert.AreEqual(9, SpanEnumerable.Range(0, 10).Select(i => (int?)i).Append(null).Max());
        Assert.AreEqual(9L, SpanEnumerable.Range(0, 10).Select(i => (long?)i).Append(null).Max());
        Assert.AreEqual(9f, SpanEnumerable.Range(0, 10).Select(i => (float?)i).Append(null).Max());
        Assert.AreEqual(9.0, SpanEnumerable.Range(0, 10).Select(i => (double?)i).Append(null).Max());
        Assert.AreEqual(9m, SpanEnumerable.Range(0, 10).Select(i => (decimal?)i).Append(null).Max());

        Assert.AreEqual(null, SpanEnumerable.Repeat((int?)null, 10).Max());
        Assert.AreEqual(null, SpanEnumerable.Repeat((long?)null, 10).Max());
        Assert.AreEqual(null, SpanEnumerable.Repeat((float?)null, 10).Max());
        Assert.AreEqual(null, SpanEnumerable.Repeat((double?)null, 10).Max());
        Assert.AreEqual(null, SpanEnumerable.Repeat((decimal?)null, 10).Max());

        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<int>().Max());
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<long>().Max());
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<float>().Max());
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<double>().Max());
        Assert.ThrowsException<InvalidOperationException>(() => SpanEnumerable.Empty<decimal>().Max());

        Assert.AreEqual(null, SpanEnumerable.Empty<int?>().Max());
        Assert.AreEqual(null, SpanEnumerable.Empty<long?>().Max());
        Assert.AreEqual(null, SpanEnumerable.Empty<float?>().Max());
        Assert.AreEqual(null, SpanEnumerable.Empty<double?>().Max());
        Assert.AreEqual(null, SpanEnumerable.Empty<decimal?>().Max());

        Assert.AreEqual(90, SpanEnumerable.Range(0, 10).Max(i => i * 10));
        Assert.AreEqual(90L, SpanEnumerable.Range(0, 10).Select(i => (long)i).Max(i => i * 10));
        Assert.AreEqual(90f, SpanEnumerable.Range(0, 10).Select(i => (float)i).Max(i => i * 10));
        Assert.AreEqual(90.0, SpanEnumerable.Range(0, 10).Select(i => (double)i).Max(i => i * 10));
        Assert.AreEqual(90m, SpanEnumerable.Range(0, 10).Select(i => (decimal)i).Max(i => i * 10));

        Assert.AreEqual(90, SpanEnumerable.Range(0, 10).Select(i => (int?)i).Append(null).Max(i => i * 10));
        Assert.AreEqual(90L, SpanEnumerable.Range(0, 10).Select(i => (long?)i).Append(null).Max(i => i * 10));
        Assert.AreEqual(90f, SpanEnumerable.Range(0, 10).Select(i => (float?)i).Append(null).Max(i => i * 10));
        Assert.AreEqual(90.0, SpanEnumerable.Range(0, 10).Select(i => (double?)i).Append(null).Max(i => i * 10));
        Assert.AreEqual(90m, SpanEnumerable.Range(0, 10).Select(i => (decimal?)i).Append(null).Max(i => i * 10));
    }
}
