namespace SpanLinq.Tests;

[TestClass]
public class IntersectTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 6, 7 },
            SpanEnumerable.Range(0, 10).Intersect(SpanEnumerable.Range(3, 5)).ToArray());

        CollectionAssert.AreEqual(new string[] { null!, "a" },
            new string[] { null!, null!, "a", "a", "b" }.AsSpan().Intersect(new string[] { null!, "a", "a" }).ToArray());
    }
}
