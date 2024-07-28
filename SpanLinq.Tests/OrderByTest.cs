namespace SpanLinq.Tests;

[TestClass]
public class OrderByTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            new int[] { 4, 8, 6, 2, 5, 1, 7, 3, 9, 0 }.AsSpan().OrderBy(i => i).ToArray());

        CollectionAssert.AreEqual(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 },
            new int[] { 4, 8, 6, 2, 5, 1, 7, 3, 9, 0 }.AsSpan().OrderByDescending(i => i).ToArray());



        CollectionAssert.AreEqual(Enumerable.Range(0, 1024).ToArray(),
            SpanEnumerable.Range(0, 1024).Shuffle(new Random(0)).OrderBy(i => i).ToArray());
    }
}
