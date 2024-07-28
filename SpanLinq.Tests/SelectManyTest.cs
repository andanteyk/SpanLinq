namespace SpanLinq.Tests;

[TestClass]
public class SelectManyTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(Enumerable.Range(0, 10).SelectMany((input, i) => Enumerable.Range(0, 10)).ToArray(),
            SpanEnumerable.Range(0, 10).SelectMany((input, i) => SpanEnumerable.Range(0, 10)).ToArray());
    }
}
