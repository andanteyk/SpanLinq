namespace SpanLinq.Tests;

[TestClass]
public class JoinTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 6, 7 },
            SpanEnumerable.Range(0, 10).Join(SpanEnumerable.Range(3, 5), i => i, i => i, (a, b) => a).ToArray());
    }
}
