using SpanLinq;

Console.WriteLine(string.Join(", ", new int[] { 4, 8, 6, 2, 5, 1, 7, 3, 9, 0 }.AsSpan().OrderByDescending(i => i).ToArray()));

