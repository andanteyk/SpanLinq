namespace SpanLinq.Tests;

[TestClass]
public class ForEachTest
{
    [TestMethod]
    public void Basic()
    {
        int count = 0;
        SpanEnumerable.Range(0, 10).ForEach(x => count++);
        Assert.AreEqual(10, count);
    }

    [TestMethod]
    public void ForEach()
    {
        int index = 0;
        foreach (int i in SpanEnumerable.Range(0, 10))
        {
            Assert.AreEqual(index++, i);
        }
    }
}
