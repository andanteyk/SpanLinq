namespace SpanLinq.Tests;

[TestClass]
public class OfTypeTest
{
    [TestMethod]
    public void Basic()
    {
        var source = new object[] { 1, "2", 3.0, new List<int>(), null! };

        CollectionAssert.AreEqual(new int[] { 1 }, source.AsSpan().OfType<object, int>().ToArray());
        CollectionAssert.AreEqual(new string[] { "2" }, source.AsSpan().OfType<object, string>().ToArray());
        CollectionAssert.AreEqual(new decimal[] { }, source.AsSpan().OfType<object, decimal>().ToArray());
    }


    [TestMethod]
    public void CrossTest()
    {
        static void Test<T1, T2>(T1[] a)
        {
            bool expectedException = false;
            Type? expectedType = null;
            try
            {
                var result = Enumerable.OfType<T2>(a);
                expectedType = result.ElementAtOrDefault(0)?.GetType();
            }
            catch (InvalidCastException)
            {
                expectedException = true;
            }

            bool actualException = false;
            Type? actualType = null;
            try
            {
                var result = a.AsSpan().OfType<T1, T2>();
                actualType = result.ElementAtOrDefault(0)?.GetType();
            }
            catch (InvalidCastException)
            {
                actualException = true;
            }

            Assert.AreEqual(expectedException, actualException);
            Assert.AreEqual(expectedType, actualType);
        }

        Test<StructA, ISomeInterface>(new[] { new StructA("a") });
        Test<StructA, StructA>(new[] { new StructA("a") });
        Test<StructA, StructB>(new[] { new StructA("a") });
        Test<StructA, StructC>(new[] { new StructA("a") });
        Test<StructA, StructD>(new[] { new StructA("a") });
        Test<StructA, StructE>(new[] { new StructA("a") });
        Test<StructA, StructA?>(new[] { new StructA("a") });
        Test<StructA, StructB?>(new[] { new StructA("a") });
        Test<StructA, StructC?>(new[] { new StructA("a") });
        Test<StructA, StructD?>(new[] { new StructA("a") });
        Test<StructA, StructE?>(new[] { new StructA("a") });
        Test<StructA, ClassA>(new[] { new StructA("a") });
        Test<StructA, ClassB>(new[] { new StructA("a") });
        Test<StructA, ClassC>(new[] { new StructA("a") });
        Test<StructA, ClassD>(new[] { new StructA("a") });
        Test<StructA, ClassE>(new[] { new StructA("a") });

        Test<StructB, ISomeInterface>(new[] { new StructB("a") });
        Test<StructB, StructA>(new[] { new StructB("a") });
        Test<StructB, StructB>(new[] { new StructB("a") });
        Test<StructB, StructC>(new[] { new StructB("a") });
        Test<StructB, StructD>(new[] { new StructB("a") });
        Test<StructB, StructE>(new[] { new StructB("a") });
        Test<StructB, StructA?>(new[] { new StructB("a") });
        Test<StructB, StructB?>(new[] { new StructB("a") });
        Test<StructB, StructC?>(new[] { new StructB("a") });
        Test<StructB, StructD?>(new[] { new StructB("a") });
        Test<StructB, StructE?>(new[] { new StructB("a") });
        Test<StructB, ClassA>(new[] { new StructB("a") });
        Test<StructB, ClassB>(new[] { new StructB("a") });
        Test<StructB, ClassC>(new[] { new StructB("a") });
        Test<StructB, ClassD>(new[] { new StructB("a") });
        Test<StructB, ClassE>(new[] { new StructB("a") });

        Test<StructC, ISomeInterface>(new[] { new StructC("a") });
        Test<StructC, StructA>(new[] { new StructC("a") });
        Test<StructC, StructB>(new[] { new StructC("a") });
        Test<StructC, StructC>(new[] { new StructC("a") });
        Test<StructC, StructD>(new[] { new StructC("a") });
        Test<StructC, StructE>(new[] { new StructC("a") });
        Test<StructC, StructA?>(new[] { new StructC("a") });
        Test<StructC, StructB?>(new[] { new StructC("a") });
        Test<StructC, StructC?>(new[] { new StructC("a") });
        Test<StructC, StructD?>(new[] { new StructC("a") });
        Test<StructC, StructE?>(new[] { new StructC("a") });
        Test<StructC, ClassA>(new[] { new StructC("a") });
        Test<StructC, ClassB>(new[] { new StructC("a") });
        Test<StructC, ClassC>(new[] { new StructC("a") });
        Test<StructC, ClassD>(new[] { new StructC("a") });
        Test<StructC, ClassE>(new[] { new StructC("a") });

        Test<StructD, ISomeInterface>(new[] { new StructD("a") });
        Test<StructD, StructA>(new[] { new StructD("a") });
        Test<StructD, StructB>(new[] { new StructD("a") });
        Test<StructD, StructC>(new[] { new StructD("a") });
        Test<StructD, StructD>(new[] { new StructD("a") });
        Test<StructD, StructE>(new[] { new StructD("a") });
        Test<StructD, StructA?>(new[] { new StructD("a") });
        Test<StructD, StructB?>(new[] { new StructD("a") });
        Test<StructD, StructC?>(new[] { new StructD("a") });
        Test<StructD, StructD?>(new[] { new StructD("a") });
        Test<StructD, StructE?>(new[] { new StructD("a") });
        Test<StructD, ClassA>(new[] { new StructD("a") });
        Test<StructD, ClassB>(new[] { new StructD("a") });
        Test<StructD, ClassC>(new[] { new StructD("a") });
        Test<StructD, ClassD>(new[] { new StructD("a") });
        Test<StructD, ClassE>(new[] { new StructD("a") });

        Test<StructE, ISomeInterface>(new[] { new StructE() });
        Test<StructE, StructA>(new[] { new StructE() });
        Test<StructE, StructB>(new[] { new StructE() });
        Test<StructE, StructC>(new[] { new StructE() });
        Test<StructE, StructD>(new[] { new StructE() });
        Test<StructE, StructE>(new[] { new StructE() });
        Test<StructE, StructA?>(new[] { new StructE() });
        Test<StructE, StructB?>(new[] { new StructE() });
        Test<StructE, StructC?>(new[] { new StructE() });
        Test<StructE, StructD?>(new[] { new StructE() });
        Test<StructE, StructE?>(new[] { new StructE() });
        Test<StructE, ClassA>(new[] { new StructE() });
        Test<StructE, ClassB>(new[] { new StructE() });
        Test<StructE, ClassC>(new[] { new StructE() });
        Test<StructE, ClassD>(new[] { new StructE() });
        Test<StructE, ClassE>(new[] { new StructE() });

        Test<StructA?, ISomeInterface>(new StructA?[] { new StructA("a") });
        Test<StructA?, StructA>(new StructA?[] { new StructA("a") });
        Test<StructA?, StructB>(new StructA?[] { new StructA("a") });
        Test<StructA?, StructC>(new StructA?[] { new StructA("a") });
        Test<StructA?, StructD>(new StructA?[] { new StructA("a") });
        Test<StructA?, StructE>(new StructA?[] { new StructA("a") });
        Test<StructA?, StructA?>(new StructA?[] { new StructA("a") });
        Test<StructA?, StructB?>(new StructA?[] { new StructA("a") });
        Test<StructA?, StructC?>(new StructA?[] { new StructA("a") });
        Test<StructA?, StructD?>(new StructA?[] { new StructA("a") });
        Test<StructA?, StructE?>(new StructA?[] { new StructA("a") });
        Test<StructA?, ClassA>(new StructA?[] { new StructA("a") });
        Test<StructA?, ClassB>(new StructA?[] { new StructA("a") });
        Test<StructA?, ClassC>(new StructA?[] { new StructA("a") });
        Test<StructA?, ClassD>(new StructA?[] { new StructA("a") });
        Test<StructA?, ClassE>(new StructA?[] { new StructA("a") });

        Test<StructB?, ISomeInterface>(new StructB?[] { new StructB("a") });
        Test<StructB?, StructA>(new StructB?[] { new StructB("a") });
        Test<StructB?, StructB>(new StructB?[] { new StructB("a") });
        Test<StructB?, StructC>(new StructB?[] { new StructB("a") });
        Test<StructB?, StructD>(new StructB?[] { new StructB("a") });
        Test<StructB?, StructE>(new StructB?[] { new StructB("a") });
        Test<StructB?, StructA?>(new StructB?[] { new StructB("a") });
        Test<StructB?, StructB?>(new StructB?[] { new StructB("a") });
        Test<StructB?, StructC?>(new StructB?[] { new StructB("a") });
        Test<StructB?, StructD?>(new StructB?[] { new StructB("a") });
        Test<StructB?, StructE?>(new StructB?[] { new StructB("a") });
        Test<StructB?, ClassA>(new StructB?[] { new StructB("a") });
        Test<StructB?, ClassB>(new StructB?[] { new StructB("a") });
        Test<StructB?, ClassC>(new StructB?[] { new StructB("a") });
        Test<StructB?, ClassD>(new StructB?[] { new StructB("a") });
        Test<StructB?, ClassE>(new StructB?[] { new StructB("a") });

        Test<StructC?, ISomeInterface>(new StructC?[] { new StructC("a") });
        Test<StructC?, StructA>(new StructC?[] { new StructC("a") });
        Test<StructC?, StructB>(new StructC?[] { new StructC("a") });
        Test<StructC?, StructC>(new StructC?[] { new StructC("a") });
        Test<StructC?, StructD>(new StructC?[] { new StructC("a") });
        Test<StructC?, StructE>(new StructC?[] { new StructC("a") });
        Test<StructC?, StructA?>(new StructC?[] { new StructC("a") });
        Test<StructC?, StructB?>(new StructC?[] { new StructC("a") });
        Test<StructC?, StructC?>(new StructC?[] { new StructC("a") });
        Test<StructC?, StructD?>(new StructC?[] { new StructC("a") });
        Test<StructC?, StructE?>(new StructC?[] { new StructC("a") });
        Test<StructC?, ClassA>(new StructC?[] { new StructC("a") });
        Test<StructC?, ClassB>(new StructC?[] { new StructC("a") });
        Test<StructC?, ClassC>(new StructC?[] { new StructC("a") });
        Test<StructC?, ClassD>(new StructC?[] { new StructC("a") });
        Test<StructC?, ClassE>(new StructC?[] { new StructC("a") });

        Test<StructD?, ISomeInterface>(new StructD?[] { new StructD("a") });
        Test<StructD?, StructA>(new StructD?[] { new StructD("a") });
        Test<StructD?, StructB>(new StructD?[] { new StructD("a") });
        Test<StructD?, StructC>(new StructD?[] { new StructD("a") });
        Test<StructD?, StructD>(new StructD?[] { new StructD("a") });
        Test<StructD?, StructE>(new StructD?[] { new StructD("a") });
        Test<StructD?, StructA?>(new StructD?[] { new StructD("a") });
        Test<StructD?, StructB?>(new StructD?[] { new StructD("a") });
        Test<StructD?, StructC?>(new StructD?[] { new StructD("a") });
        Test<StructD?, StructD?>(new StructD?[] { new StructD("a") });
        Test<StructD?, StructE?>(new StructD?[] { new StructD("a") });
        Test<StructD?, ClassA>(new StructD?[] { new StructD("a") });
        Test<StructD?, ClassB>(new StructD?[] { new StructD("a") });
        Test<StructD?, ClassC>(new StructD?[] { new StructD("a") });
        Test<StructD?, ClassD>(new StructD?[] { new StructD("a") });
        Test<StructD?, ClassE>(new StructD?[] { new StructD("a") });

        Test<StructE?, ISomeInterface>(new StructE?[] { new StructE() });
        Test<StructE?, StructA>(new StructE?[] { new StructE() });
        Test<StructE?, StructB>(new StructE?[] { new StructE() });
        Test<StructE?, StructC>(new StructE?[] { new StructE() });
        Test<StructE?, StructD>(new StructE?[] { new StructE() });
        Test<StructE?, StructE>(new StructE?[] { new StructE() });
        Test<StructE?, StructA?>(new StructE?[] { new StructE() });
        Test<StructE?, StructB?>(new StructE?[] { new StructE() });
        Test<StructE?, StructC?>(new StructE?[] { new StructE() });
        Test<StructE?, StructD?>(new StructE?[] { new StructE() });
        Test<StructE?, StructE?>(new StructE?[] { new StructE() });
        Test<StructE?, ClassA>(new StructE?[] { new StructE() });
        Test<StructE?, ClassB>(new StructE?[] { new StructE() });
        Test<StructE?, ClassC>(new StructE?[] { new StructE() });
        Test<StructE?, ClassD>(new StructE?[] { new StructE() });
        Test<StructE?, ClassE>(new StructE?[] { new StructE() });

        Test<ClassA, ISomeInterface>(new[] { new ClassA("a") });
        Test<ClassA, StructA>(new[] { new ClassA("a") });
        Test<ClassA, StructB>(new[] { new ClassA("a") });
        Test<ClassA, StructC>(new[] { new ClassA("a") });
        Test<ClassA, StructD>(new[] { new ClassA("a") });
        Test<ClassA, StructE>(new[] { new ClassA("a") });
        Test<ClassA, StructA?>(new[] { new ClassA("a") });
        Test<ClassA, StructB?>(new[] { new ClassA("a") });
        Test<ClassA, StructC?>(new[] { new ClassA("a") });
        Test<ClassA, StructD?>(new[] { new ClassA("a") });
        Test<ClassA, StructE?>(new[] { new ClassA("a") });
        Test<ClassA, ClassA>(new[] { new ClassA("a") });
        Test<ClassA, ClassB>(new[] { new ClassA("a") });
        Test<ClassA, ClassC>(new[] { new ClassA("a") });
        Test<ClassA, ClassD>(new[] { new ClassA("a") });
        Test<ClassA, ClassE>(new[] { new ClassA("a") });

        Test<ClassB, ISomeInterface>(new[] { new ClassB("a") });
        Test<ClassB, StructA>(new[] { new ClassB("a") });
        Test<ClassB, StructB>(new[] { new ClassB("a") });
        Test<ClassB, StructC>(new[] { new ClassB("a") });
        Test<ClassB, StructD>(new[] { new ClassB("a") });
        Test<ClassB, StructE>(new[] { new ClassB("a") });
        Test<ClassB, StructA?>(new[] { new ClassB("a") });
        Test<ClassB, StructB?>(new[] { new ClassB("a") });
        Test<ClassB, StructC?>(new[] { new ClassB("a") });
        Test<ClassB, StructD?>(new[] { new ClassB("a") });
        Test<ClassB, StructE?>(new[] { new ClassB("a") });
        Test<ClassB, ClassA>(new[] { new ClassB("a") });
        Test<ClassB, ClassB>(new[] { new ClassB("a") });
        Test<ClassB, ClassC>(new[] { new ClassB("a") });
        Test<ClassB, ClassD>(new[] { new ClassB("a") });
        Test<ClassB, ClassE>(new[] { new ClassB("a") });

        Test<ClassC, ISomeInterface>(new[] { new ClassC("a") });
        Test<ClassC, StructA>(new[] { new ClassC("a") });
        Test<ClassC, StructB>(new[] { new ClassC("a") });
        Test<ClassC, StructC>(new[] { new ClassC("a") });
        Test<ClassC, StructD>(new[] { new ClassC("a") });
        Test<ClassC, StructE>(new[] { new ClassC("a") });
        Test<ClassC, StructA?>(new[] { new ClassC("a") });
        Test<ClassC, StructB?>(new[] { new ClassC("a") });
        Test<ClassC, StructC?>(new[] { new ClassC("a") });
        Test<ClassC, StructD?>(new[] { new ClassC("a") });
        Test<ClassC, StructE?>(new[] { new ClassC("a") });
        Test<ClassC, ClassA>(new[] { new ClassC("a") });
        Test<ClassC, ClassB>(new[] { new ClassC("a") });
        Test<ClassC, ClassC>(new[] { new ClassC("a") });
        Test<ClassC, ClassD>(new[] { new ClassC("a") });
        Test<ClassC, ClassE>(new[] { new ClassC("a") });

        Test<ClassD, ISomeInterface>(new[] { new ClassD("a") });
        Test<ClassD, StructA>(new[] { new ClassD("a") });
        Test<ClassD, StructB>(new[] { new ClassD("a") });
        Test<ClassD, StructC>(new[] { new ClassD("a") });
        Test<ClassD, StructD>(new[] { new ClassD("a") });
        Test<ClassD, StructE>(new[] { new ClassD("a") });
        Test<ClassD, StructA?>(new[] { new ClassD("a") });
        Test<ClassD, StructB?>(new[] { new ClassD("a") });
        Test<ClassD, StructC?>(new[] { new ClassD("a") });
        Test<ClassD, StructD?>(new[] { new ClassD("a") });
        Test<ClassD, StructE?>(new[] { new ClassD("a") });
        Test<ClassD, ClassA>(new[] { new ClassD("a") });
        Test<ClassD, ClassB>(new[] { new ClassD("a") });
        Test<ClassD, ClassC>(new[] { new ClassD("a") });
        Test<ClassD, ClassD>(new[] { new ClassD("a") });
        Test<ClassD, ClassE>(new[] { new ClassD("a") });

        Test<ClassE, ISomeInterface>(new[] { new ClassE() });
        Test<ClassE, StructA>(new[] { new ClassE() });
        Test<ClassE, StructB>(new[] { new ClassE() });
        Test<ClassE, StructC>(new[] { new ClassE() });
        Test<ClassE, StructD>(new[] { new ClassE() });
        Test<ClassE, StructE>(new[] { new ClassE() });
        Test<ClassE, StructA?>(new[] { new ClassE() });
        Test<ClassE, StructB?>(new[] { new ClassE() });
        Test<ClassE, StructC?>(new[] { new ClassE() });
        Test<ClassE, StructD?>(new[] { new ClassE() });
        Test<ClassE, StructE?>(new[] { new ClassE() });
        Test<ClassE, ClassA>(new[] { new ClassE() });
        Test<ClassE, ClassB>(new[] { new ClassE() });
        Test<ClassE, ClassC>(new[] { new ClassE() });
        Test<ClassE, ClassD>(new[] { new ClassE() });
        Test<ClassE, ClassE>(new[] { new ClassE() });
    }

    public interface ISomeInterface { string Name { get; } }

    public record struct StructA(string Name) : ISomeInterface { }
    public record struct StructB(string Name) : ISomeInterface { }
    public record struct StructC(string Name);
    public record struct StructD(string Name);
    public record struct StructE()
    {
        public static explicit operator StructA(StructE hoge) => new StructA("from E");
        public static explicit operator StructB?(StructE hoge) => new StructB("from E");
        public static implicit operator StructC(StructE hoge) => new StructC("from E");
        public static implicit operator StructD?(StructE hoge) => new StructD("from E");
        public static explicit operator ClassE(StructE hoge) => new ClassE();
    }

    public record class ClassA(string Name) : ISomeInterface { }
    public record class ClassB(string Name) : ClassA(Name) { }
    public record class ClassC(string Name);
    public record class ClassD(string Name) : ClassC(Name) { };
    public record class ClassE()
    {
        public static explicit operator ClassA(ClassE hoge) => new ClassA("from E");
        public static implicit operator ClassC(ClassE hoge) => new ClassC("from E");
        public static explicit operator StructE(ClassE hoge) => new StructE();
    }
}
