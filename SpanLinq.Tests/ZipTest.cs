namespace SpanLinq.Tests;

[TestClass]
public class ZipTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(
            Enumerable.Range(0, 10).Zip(Enumerable.Range(0, 10), (First, Second) => (First, Second)).ToArray(),
            SpanEnumerable.Range(0, 10).Zip(SpanEnumerable.Range(0, 10)).ToArray());

#if NET6_0_OR_GREATER
        CollectionAssert.AreEqual(
            Enumerable.Range(0, 10).Zip(Enumerable.Range(0, 10), Enumerable.Range(0, 10)).ToArray(),
            SpanEnumerable.Range(0, 10).Zip(SpanEnumerable.Range(0, 10), SpanEnumerable.Range(0, 10)).ToArray());
#endif
    }
}
