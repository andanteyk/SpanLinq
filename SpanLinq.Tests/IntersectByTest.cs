using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SpanLinq.Tests;

[TestClass]
public class IntersectByTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 6, 7 },
            SpanEnumerable.Range(0, 10).IntersectBy(SpanEnumerable.Range(3, 5), i => i).AsSpan().ToArray());

        CollectionAssert.AreEqual(new[] { (Name: "Alice", Age: 17), (Name: "Charlotte", Age: 18) },
            new[] { (Name: "Alice", Age: 17), (Name: "Barbara", Age: 16), (Name: "Charlotte", Age: 18) }.AsSpan()
                .IntersectBy(new string[] { "Alice", "Charlotte" }, x => x.Name).AsSpan().ToArray());
    }
}
