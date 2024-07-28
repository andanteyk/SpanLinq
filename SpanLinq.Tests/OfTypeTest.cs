namespace SpanLinq.Tests;

[TestClass]
public class OfTypeTest
{
    [TestMethod]
    public void Basic()
    {
        var source = new object[] { 1, "2", 3.0, new List<int>(), null! };

        CollectionAssert.AreEqual(new int[] { 1 }, source.AsSpan().OfType<object, int>().ToArray());
        CollectionAssert.AreEqual(new string[] { "2" }, source.AsSpan().OfType<object, string>().ToArray());
        CollectionAssert.AreEqual(new decimal[] { }, source.AsSpan().OfType<object, decimal>().ToArray());
    }
}
