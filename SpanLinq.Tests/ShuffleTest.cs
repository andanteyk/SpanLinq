namespace SpanLinq.Tests;

[TestClass]
public class ShuffleTest
{
    [TestMethod]
    public void Basic()
    {
        var random = new Random(0);

        var actual = SpanEnumerable.Range(0, 10).Shuffle(random).ToArray();
        CollectionAssert.AreEqual(new int[] { 9, 6, 7, 3, 1, 2, 8, 4, 5, 0 }, actual);

        actual = SpanEnumerable.Range(0, 10).Shuffle(random).ToArray();
        CollectionAssert.AreEqual(new int[] { 9, 2, 8, 6, 1, 0, 4, 5, 3, 7 }, actual);
    }
}
