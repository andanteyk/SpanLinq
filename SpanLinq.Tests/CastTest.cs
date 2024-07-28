namespace SpanLinq.Tests;

[TestClass]
public class CastTest
{
    [TestMethod]
    public void Basic()
    {
        object[] objects = { 1, 2, 3 };
        CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, objects.Cast<int>().ToArray());

        object?[] nullableObjects = { 1, 2, 3, null };
        CollectionAssert.AreEqual(new int?[] { 1, 2, 3, null }, nullableObjects.Cast<int?>().ToArray());

        Assert.ThrowsException<InvalidCastException>(() => SpanEnumerable.Range(0, 10).Cast<double>().ToArray());
    }
}
