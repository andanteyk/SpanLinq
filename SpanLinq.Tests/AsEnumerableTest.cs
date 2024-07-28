namespace SpanLinq.Tests;

[TestClass]
public class AsEnumerableTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4 }, SpanEnumerable.Range(0, 5).AsEnumerable().ToArray());
    }
}
