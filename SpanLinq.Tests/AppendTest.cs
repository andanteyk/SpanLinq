namespace SpanLinq.Tests;

[TestClass]
public class AppendTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4, 100 }, SpanEnumerable.Range(0, 5).Append(100).ToArray());
    }
}
