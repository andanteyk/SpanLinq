namespace SpanLinq.Tests;

[TestClass]
public class SelectTest
{
    [TestMethod]
    public void Basic()
    {
        CollectionAssert.AreEqual(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" },
            SpanEnumerable.Range(1, 10).Select(i => i.ToString()).ToArray());
    }
}
