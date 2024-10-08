namespace SpanLinq.Tests;

[TestClass]
public class GroupByTest
{
    [TestMethod]
    public void Basic()
    {
        var expected = new[] {
            new GroupList<int, int>(0, new int[] {0, 3, 6, 9} ),
            new GroupList<int, int>(1, new int[] {1, 4, 7} ),
            new GroupList<int, int>(2, new int[] {2, 5, 8} ),
        };
        var actual = SpanEnumerable.Range(0, 10).GroupBy(x => x % 3).ToArray();

        /*
        foreach (var elem in actual)
        {
            System.Diagnostics.Debug.WriteLine($"{elem.Key}: [{string.Join(", ", elem)}]");
        }
        */

        foreach (var (First, Second) in expected.Zip(actual, (First, Second) => (First, Second)))
        {
            Assert.AreEqual(First.Key, Second.Key);
            CollectionAssert.AreEqual(First, Second);
        }
    }
}
