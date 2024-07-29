namespace SpanLinq.Tests;

[TestClass]
public class FromEnumerableTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(Enumerable.Range(1, 10).ToArray(),
            SpanEnumerable.FromEnumerable(Enumerable.Range(1, 10)).ToArray());


        static IEnumerable<string> test()
        {
            yield return "Alice";
            yield return "Barbara";
            yield return "Charlotte";
        }
        CollectionAssert.AreEqual(test().ToArray(),
            SpanEnumerable.FromEnumerable(test()).ToArray());
    }
}
