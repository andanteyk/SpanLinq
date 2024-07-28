namespace SpanLinq.Tests;

[TestClass]
public class WhereTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 2, 4, 6, 8, 10 },
            SpanEnumerable.Range(1, 10).Where(x => x % 2 == 0).ToArray());
    }
}
