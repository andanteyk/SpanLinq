namespace SpanLinq.Tests;

[TestClass]
public class AggregateByTest
{
    [TestMethod]
    public void Basic()
    {
        var result = SpanEnumerable.Range(0, 10).AggregateBy(i => i % 3, 0, (current, next) => current + next).ToArray();
        // System.Diagnostics.Debug.WriteLine($"{string.Join(", ", result)}");
        CollectionAssert.AreEqual(new KeyValuePair<int, int>[] {
            new(0, 18),
            new(1, 12),
            new(2, 15),
        }, result);

        result = SpanEnumerable.Range(0, 10).AggregateBy(i => i % 3, i => i * 2, (current, next) => current + next).ToArray();
        // System.Diagnostics.Debug.WriteLine($"{string.Join(", ", result)}");
        CollectionAssert.AreEqual(new KeyValuePair<int, int>[] {
            new(0, 18),
            new(1, 13),
            new(2, 17),
        }, result);

    }
}
