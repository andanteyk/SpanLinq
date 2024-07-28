namespace SpanLinq.Tests;

[TestClass]
public class TakeLastTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 8, 9, 10 }, SpanEnumerable.Range(1, 10).TakeLast(3).ToArray());
        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, SpanEnumerable.Range(1, 10).TakeLast(10).ToArray());

        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Empty<int>().TakeLast(1).ToArray());
        CollectionAssert.AreEqual(new int[] { }, SpanEnumerable.Range(0, 10).TakeLast(-123).ToArray());
    }
}
