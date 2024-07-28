namespace SpanLinq.Tests;

[TestClass]
public class RangeTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            SpanEnumerable.Range(1, 10).ToArray());

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => { SpanEnumerable.Range(0, -1); });
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => { SpanEnumerable.Range(int.MaxValue, 2); });
    }
}
