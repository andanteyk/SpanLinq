namespace SpanLinq.Tests;

[TestClass]
public class ChunkTest
{
    [TestMethod]
    public void Basic()
    {
        var result = SpanEnumerable.Range(0, 10).Chunk(3).ToArray();

        Assert.AreEqual(4, result.Length);
        CollectionAssert.AreEqual(new[] { 0, 1, 2 }, result[0]);
        CollectionAssert.AreEqual(new[] { 3, 4, 5 }, result[1]);
        CollectionAssert.AreEqual(new[] { 6, 7, 8 }, result[2]);
        CollectionAssert.AreEqual(new[] { 9 }, result[3]);

        result = SpanEnumerable.Empty<int>().Chunk(3).ToArray();
        Assert.AreEqual(0, result.Length);

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => SpanEnumerable.Range(0, 10).Chunk(-1));
    }
}
