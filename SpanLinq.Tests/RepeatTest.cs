namespace SpanLinq.Tests;

[TestClass]
public class RepeatTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new[] { 1, 1, 1, 1, 1 }, SpanEnumerable.Repeat(1, 5).ToArray());

        var guid = Guid.NewGuid();
        CollectionAssert.AreEqual(new[] { guid, guid, guid, guid, guid }, SpanEnumerable.Repeat(guid, 5).ToArray());

        CollectionAssert.AreEqual(new[] { "apple", "apple", "apple", "apple", "apple" }, SpanEnumerable.Repeat("apple", 5).ToArray());
    }
}
