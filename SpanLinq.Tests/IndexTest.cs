namespace SpanLinq.Tests;

[TestClass]
public class IndexTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new[] {
            (0, 0), (1, 1), (2, 2), (3, 3), (4, 4), (5, 5), (6, 6), (7, 7), (8, 8), (9, 9),
            }, SpanEnumerable.Range(0, 10).Index().ToArray());

        CollectionAssert.AreEqual(new[] {
            (0, "0"), (1, "1"), (2, "2"), (3, "3"), (4, "4"), (5, "5"), (6, "6"), (7, "7"), (8, "8"), (9, "9"),
            }, SpanEnumerable.Range(0, 10).Select(i => i.ToString()).Index().ToArray());
    }
}
