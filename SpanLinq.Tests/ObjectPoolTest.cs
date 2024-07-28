namespace SpanLinq.Tests;

[TestClass]
public class ObjectPoolTest
{
    [TestMethod]
    public void Basic()
    {
        var list = new List<ArrayPoolDictionary<int, int>>();

        for (int i = 0; i < 32; i++)
        {
            list.Add(ObjectPool<ArrayPoolDictionary<int, int>>.Shared.Rent());
        }

        for (int i = 0; i < 32; i++)
        {
            ObjectPool<ArrayPoolDictionary<int, int>>.Shared.Return(list[i]);
        }
    }
}
