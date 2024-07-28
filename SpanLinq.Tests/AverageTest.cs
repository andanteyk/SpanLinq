namespace SpanLinq.Tests;

[TestClass]
public class AverageTest
{
    [TestMethod]
    public void Basic()
    {
        Assert.AreEqual(4.5, SpanEnumerable.Range(0, 10).Average());
        Assert.AreEqual(4.5, SpanEnumerable.Range(0, 10).Select(i => (long)i).Average());
        Assert.AreEqual(4.5f, SpanEnumerable.Range(0, 10).Select(i => (float)i).Average());
        Assert.AreEqual(4.5, SpanEnumerable.Range(0, 10).Select(i => (double)i).Average());
        Assert.AreEqual(4.5m, SpanEnumerable.Range(0, 10).Select(i => (decimal)i).Average());

        Assert.AreEqual(4.5, SpanEnumerable.Range(0, 10).Select(i => (int?)i).Append(null).Average());
        Assert.AreEqual(4.5, SpanEnumerable.Range(0, 10).Select(i => (long?)i).Append(null).Average());
        Assert.AreEqual(4.5f, SpanEnumerable.Range(0, 10).Select(i => (float?)i).Append(null).Average());
        Assert.AreEqual(4.5, SpanEnumerable.Range(0, 10).Select(i => (double?)i).Append(null).Average());
        Assert.AreEqual(4.5m, SpanEnumerable.Range(0, 10).Select(i => (decimal?)i).Append(null).Average());

        Assert.AreEqual(null, SpanEnumerable.Repeat((int?)null, 10).Average());
        Assert.AreEqual(null, SpanEnumerable.Repeat((long?)null, 10).Average());
        Assert.AreEqual(null, SpanEnumerable.Repeat((float?)null, 10).Average());
        Assert.AreEqual(null, SpanEnumerable.Repeat((double?)null, 10).Average());
        Assert.AreEqual(null, SpanEnumerable.Repeat((decimal?)null, 10).Average());


        Assert.AreEqual(45.0, SpanEnumerable.Range(0, 10).Average(i => i * 10));
        Assert.AreEqual(45.0, SpanEnumerable.Range(0, 10).Select(i => (long)i).Average(i => i * 10));
        Assert.AreEqual(45f, SpanEnumerable.Range(0, 10).Select(i => (float)i).Average(i => i * 10));
        Assert.AreEqual(45.0, SpanEnumerable.Range(0, 10).Select(i => (double)i).Average(i => i * 10));
        Assert.AreEqual(45m, SpanEnumerable.Range(0, 10).Select(i => (decimal)i).Average(i => i * 10));

        Assert.AreEqual(45.0, SpanEnumerable.Range(0, 10).Select(i => (int?)i).Append(null).Average(i => i * 10));
        Assert.AreEqual(45.0, SpanEnumerable.Range(0, 10).Select(i => (long?)i).Append(null).Average(i => i * 10));
        Assert.AreEqual(45f, SpanEnumerable.Range(0, 10).Select(i => (float?)i).Append(null).Average(i => i * 10));
        Assert.AreEqual(45.0, SpanEnumerable.Range(0, 10).Select(i => (double?)i).Append(null).Average(i => i * 10));
        Assert.AreEqual(45m, SpanEnumerable.Range(0, 10).Select(i => (decimal?)i).Append(null).Average(i => i * 10));
    }
}
