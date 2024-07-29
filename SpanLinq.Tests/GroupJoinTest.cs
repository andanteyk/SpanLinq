namespace SpanLinq.Tests;

[TestClass]
public class GroupJoinTest
{
    [TestMethod]
    public void Basic()
    {
        var actual = SpanEnumerable.GroupJoin(
            new[] { (Name: "Alice", Age: 17), (Name: "Barbara", Age: 15), (Name: "Caroline", Age: 16) },
            new[] { (Name: "Apple", Owner: "Alice"), (Name: "Banana", Owner: "Alice"), (Name: "Carrot", Owner: "Barbara") },
            ((string Name, int Age) x) => x.Name,
            ((string Name, string Owner) x) => x.Owner,
            (outer, items) => $"{outer.Name} has {string.Join(", ", items.Select(i => i.Name))}").ToEnumerator().ToArray();

        CollectionAssert.AreEqual(new[] { "Alice has Apple, Banana", "Barbara has Carrot", "Caroline has " }, actual);
    }
}
