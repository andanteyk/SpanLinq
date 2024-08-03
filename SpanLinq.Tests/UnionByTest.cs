namespace SpanLinq.Tests;

[TestClass]
public class UnionByTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
            SpanEnumerable.Range(0, 10).UnionBy(SpanEnumerable.Range(8, 5), i => i).ToArray());

        CollectionAssert.AreEqual(new[] { (Name: "Alice", Age: 17), (Name: "Barbara", Age: 16), (Name: "Charlotte", Age: 18), (Name: "Diona", Age: 11) },
            new[] { (Name: "Alice", Age: 17), (Name: "Barbara", Age: 16), (Name: "Charlotte", Age: 18) }.AsSpan()
                .UnionBy(new[] { (Name: "Charlotte", Age: 19), (Name: "Diona", Age: 11) }, x => x.Name).ToArray());
    }
}
