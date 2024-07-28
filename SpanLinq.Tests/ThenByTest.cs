namespace SpanLinq.Tests;

[TestClass]
public class ThenByTest
{
    [TestMethod]
    public void Basic()
    {
        var testcase = new (int Height, int Age, int Attack, string Name)[] {
            (165, 23, 456, "Alice"),
            (167, 17, 334, "Barbara"),
            (167, 17, 334, "Charlotte"),
            (145, 11, 248, "Diona"),
            (170, 17, 456, "Eula"),
            (165, 17, 456, "Furina"),
        };

        var expected = testcase.OrderBy(i => i.Height).ThenBy(i => i.Age).Select(i => i.Name).ToArray();
        var actual = testcase.AsSpan().OrderBy(i => i.Height).ThenBy(i => i.Age).Select(i => i.Name).ToArray();
        CollectionAssert.AreEqual(new string[] { "Diona", "Furina", "Alice", "Barbara", "Charlotte", "Eula" }, actual);

        actual = testcase.AsSpan().OrderByDescending(i => i.Age).ThenByDescending(i => i.Attack).ThenBy(i => i.Age).Select(i => i.Name).ToArray();
        CollectionAssert.AreEqual(new string[] { "Alice", "Eula", "Furina", "Barbara", "Charlotte", "Diona" }, actual);
    }
}
