namespace SpanLinq.Tests;

[TestClass]
public class CountByTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new KeyValuePair<int, int>[] {
            new(0, 4),
            new(1, 3),
            new(2, 3)
        }, SpanEnumerable.Range(0, 10).CountBy(i => i % 3).ToArray());

        /*
        CollectionAssert.AreEqual(new KeyValuePair<int, int>[] {
            new(0, 4),
            new(1, 3),
            new(2, 3)
        }, SpanEnumerable.Range(0, 10).CountBy(i => i, EqualityComparer<int>.Create((a, b) => a % 3 == b % 3, a => a % 3)).ToArray());
        //*/

        // NOTE: If `EqualityComparer<int>.Create` 's getHashCode is null, it throws  
    }
}
