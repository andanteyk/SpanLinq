namespace SpanLinq.Tests;

[TestClass]
public class TakeWhileTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 1, 2 }, SpanEnumerable.Range(1, 10).TakeWhile(i => i < 3).ToArray());
        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, SpanEnumerable.Range(1, 10).TakeWhile(i => i <= 10).ToArray());

        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Empty<int>().TakeWhile(_ => true).ToArray());
        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Range(0, 10).TakeWhile(_ => false).ToArray());
    }
}
