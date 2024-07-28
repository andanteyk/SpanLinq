namespace SpanLinq.Tests;

[TestClass]
public class TakeTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, SpanEnumerable.Range(1, 10).Take(3).ToArray());
        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, SpanEnumerable.Range(1, 10).Take(10).ToArray());

        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Empty<int>().Take(1).ToArray());
        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Range(0, 10).Take(-123).ToArray());
    }
}
