namespace SpanLinq.Tests;

[TestClass]
public class ReverseTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new[] { 4, 3, 2, 1, 0 }, SpanEnumerable.Range(0, 5).Reverse().ToArray());
        CollectionAssert.AreEqual(new int[0], SpanEnumerable.Empty<int>().Reverse().ToArray());
    }
}
