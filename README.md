# SpanLinq

Lightweight, Zero Allocation LINQ Implementation on `Span<T>`

## Usage

It's almost the same as LINQ, but it's implemented as an extension method on `Span<T>` and can also be accessed starting from a `SpanEnumerable`.

```cs
using SpanLinq;

string[] array =
    SpanEnumerable.Range(0, 10)
        .Skip(2)
        .Where(i => i % 2 == 0)
        .Select(i => i.ToString())
        .ToArray();

string largestString = array.AsSpan()
    .Union(new[] { "apple", "banana" })
    .MaxBy(s => s.Length);
```

## Install

// TODO.

### Fork

#### Build

```
dotnet build
```

#### Run tests

```
dotnet test
```

#### Run benchmarks

```
dotnet run -c Release --project SpanLinq.Benchmarks
```

## Feature

### Pros.

* It covers **ALL LINQ methods** implemented up to .NET 9 Preview 6.
    If you're tied to the old .NET you can still benefit from the new methods.
* It produces **no GC garbage**, reducing pressure on the garbage collector and improving performance.
* This requires **.NET Standard 2.1**, which means **it can be used in Unity**.
* Like LINQ, **it supports deferred execution**, although it is somewhat limited by the nature of a `Span<T>`.

### Cons.

* No GC garbage is not magic. It utilizes memory pools, so memory consumption during execution can be relatively high. (TODO: citation needed)
* Some methods are not fully optimized and may result in slower performance than LINQ.
    * Of course it depends on the method. Some are twice as fast, some are twice as slow. See [Performance](#Performance).

## Performance

// TODO.

## Specific differences between `System.Linq.Enumerable`

`SpanLinq` is designed to be a nearly complete replacement for `System.Linq`, but there are some differences in behavior and implementation.

### Cannot be enumerated more than once

Queries cannot be cached, for example:

```cs
var query = SpanEnumrable.Range(0, 10).Where(i => i % 2 == 0);

int min = query.Min();

// NG: Cannot use a query twice, results are undefined
int max = query.Max();
```

To avoid this, materialize query using `ToArray()` or `CopyTo()` etc.

### `AsEnumerable()`

`AsEnumerable()` is a method that is almost meaningless in `System.Linq`, but since `Span<T>` is not `IEnumerable<T>`, this method converts `Span<T>` into a class that implements `IEnumerable<T>` and returns it.

### `CopyTo()`

This method copies the current sequence to an existing span, similar to `Span<T>.CopyTo()`.

`ToArray()` inherently causes allocation, but this method does not.

### `ForEach()`

This method does not exist in LINQ. This is the original implementation.

This method calls `Action<T>` on every element of a sequence. This method executes immediately.

### `SpanEnumerable.FromEnumerable()`

This method converts an `IEnumerable<T>` into a `SpanEnumerator<>`.

This allows sequences implemented with `yield return` to be handled by a `SpanEnumerator<>`.

```cs
static IEnumerable<string> Sample()
{
    yield return "Alice";
    yield return "Barbara";
    yield return "Charlotte";
}

var spanEnumerable = SpanEnumerable.FromEnumerable(Sample());
```

### `Shuffle()`

This method does not exist in LINQ. This is the original implementation.

`Shuffle()` randomly shuffles the order of the elements of a sequence.
If you need reproducibility, call it as `Shuffle(random)`.

### `Sum()`

It returns `int`/`double`/etc. instead of `int?`/`double?`.

### `ToArrayPool()`

This method gets a shared array via `ArrayPool<T>.Shared.Rent()` and returns the array and a span.

When you're done with the data, you must return the array via `ArrayPool<T>.Shared.Return()`.

