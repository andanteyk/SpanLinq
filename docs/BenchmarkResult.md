## Performance benchmarks

This document provides an overview of performance benchmarks for various operations. The benchmarks compare different implementations to help you understand the performance characteristics of each approach.
In the following benchmarks:

- Span*** refers to SpanLinq.SpanEnumerable.***
  System*** refers to System.Linq.Enumerable.***
  Handcrafted*** refers to optimized code that uses Span<T> directly.

These comparisons will help you evaluate the performance differences between standard LINQ operations, SpanLinq implementations, and hand-optimized code using Span<T>.

- [Performance benchmarks](#performance-benchmarks)
- [System settings](#system-settings)
- [Results](#results)
  - [Aggregate](#aggregate)
  - [AggregateBy](#aggregateby)
  - [All](#all)
  - [Any](#any)
  - [Append](#append)
  - [AsEnumerable](#asenumerable)
  - [Average](#average)
  - [Cast](#cast)
  - [Chunk](#chunk)
  - [Concat](#concat)
  - [Contains](#contains)
  - [Count](#count)
  - [CountBy](#countby)
  - [DefaultIfEmpty](#defaultifempty)
  - [Distinct](#distinct)
  - [DistinctBy](#distinctby)
  - [ElementAt](#elementat)
  - [ElementAtOrDefault](#elementatordefault)
  - [Except](#except)
  - [ExceptBy](#exceptby)
  - [First](#first)
  - [FirstOrDefault](#firstordefault)
  - [ForEach](#foreach)
  - [GroupBy](#groupby)
  - [GroupJoin](#groupjoin)
  - [Index](#index)
  - [Intersect](#intersect)
  - [IntersectBy](#intersectby)
  - [Join](#join)
  - [Last](#last)
  - [LastOrDefault](#lastordefault)
  - [LongCount](#longcount)
  - [Max](#max)
  - [MaxBy](#maxby)
  - [Min](#min)
  - [MinBy](#minby)
  - [OfType](#oftype)
  - [Order](#order)
  - [OrderBy](#orderby)
  - [Prepend](#prepend)
  - [Range](#range)
  - [Repeat](#repeat)
  - [Reverse](#reverse)
  - [Select](#select)
  - [SelectMany](#selectmany)
  - [SequenceEqual](#sequenceequal)
  - [Shuffle](#shuffle)
  - [Single](#single)
  - [SingleOrDefault](#singleordefault)
  - [Skip](#skip)
  - [SkipWhile](#skipwhile)
  - [SkipWhile](#skipwhile-1)
  - [Sum](#sum)
  - [Take](#take)
  - [TakeLast](#takelast)
  - [TakeWhile](#takewhile)
  - [ThenBy](#thenby)
  - [ToArray](#toarray)
  - [ToDictionary](#todictionary)
  - [ToHashSet](#tohashset)
  - [ToList](#tolist)
  - [ToLookup](#tolookup)
  - [TryGetNonEnumeratedCount](#trygetnonenumeratedcount)
  - [Union](#union)
  - [UnionBy](#unionby)
  - [Where](#where)
  - [Zip](#zip)


## System settings

System settings provide crucial information about the environment in which benchmarks or tests are run. These details are essential for understanding the context of performance measurements and ensuring reproducibility of results.
In this case, the system settings are as follows:

```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.4317/23H2/2023Update/SunValley3)
13th Gen Intel Core i9-13905H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.100-rc.2.24474.11
  [Host]     : .NET 9.0.0 (9.0.24.47305), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.47305), X64 RyuJIT AVX2
```

When reviewing benchmarks or performance data, always consider these system settings to make informed decisions about your software's performance characteristics.

## Results

### Aggregate

| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Aggregate                | SystemAggregate                |       263.7590 ns |      1.2553 ns |      1.1128 ns |      - |      - |         - |
| Aggregate                | SpanAggregate                  |       619.7651 ns |      1.4326 ns |      1.3400 ns |      - |      - |         - |

### AggregateBy
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| AggregateBy              | SystemAggregateBy              |     3,057.8180 ns |     20.8334 ns |     19.4875 ns | 0.0267 |      - |     368 B |
| AggregateBy              | SpanAggregateBy                |     5,989.4566 ns |     21.3168 ns |     19.9398 ns |      - |      - |         - |

### All
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| All                      | SystemAll                      |       203.8615 ns |      0.2724 ns |      0.2548 ns |      - |      - |         - |
| All                      | SpanAll                        |       518.0548 ns |      2.1874 ns |      1.9391 ns |      - |      - |         - |

### Any
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Any                      | SystemAny                      |       205.5439 ns |      0.1604 ns |      0.1339 ns |      - |      - |         - |
| Any                      | SpanAny                        |       516.7499 ns |      1.6940 ns |      1.5016 ns |      - |      - |         - |

### Append
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Append                   | SpanAppend                     |       532.3850 ns |      9.4246 ns |      8.8158 ns |      - |      - |         - |
| Append                   | SystemAppend                   |     1,502.3679 ns |     13.0312 ns |     12.1894 ns | 0.0057 |      - |      88 B |

### AsEnumerable
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| AsEnumerable             | SystemAsEnumerable             |       546.0603 ns |      2.0265 ns |      1.8956 ns | 0.0019 |      - |      32 B |
| AsEnumerable             | SpanAsEnumerable               |     1,301.6000 ns |      9.9575 ns |      9.3143 ns | 0.0019 |      - |      32 B |

### Average
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Average                  | SystemAverage                  |        77.6144 ns |      0.0706 ns |      0.0589 ns |      - |      - |         - |
| Average                  | SpanAverage                    |       669.5447 ns |      2.5918 ns |      2.2975 ns |      - |      - |         - |

### Cast
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Cast                     | SpanCastIntToNullableInt       |     1,004.6952 ns |      2.3091 ns |      2.1599 ns |      - |      - |         - |
| Cast                     | SpanCastClass                  |     1,204.0367 ns |      2.5576 ns |      2.3924 ns |      - |      - |         - |
| Cast                     | SpanCastIntToObject            |     2,871.0990 ns |     24.2749 ns |     20.2707 ns | 1.9569 |      - |   24576 B |
| Cast                     | SystemCastClass                |     2,945.3580 ns |      6.1851 ns |      4.8290 ns |      - |      - |      32 B |
| Cast                     | SystemCastIntToNullableInt     |    17,648.1809 ns |     49.0119 ns |     40.9271 ns | 1.9531 |      - |   24656 B |
| Cast                     | SystemCastIntToObject          |    19,376.9764 ns |    175.7687 ns |    155.8143 ns | 1.9531 |      - |   24656 B |

### Chunk
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Chunk                    | SystemChunk                    |       704.1107 ns |      2.3762 ns |      1.9843 ns | 0.5283 |      - |    6632 B |
| Chunk                    | HandcraftedChunk               |       853.0973 ns |      7.8673 ns |      7.3591 ns | 0.5922 | 0.0019 |    7440 B |
| Chunk                    | SpanChunk                      |     1,136.6704 ns |     12.9198 ns |     12.0852 ns | 0.5283 |      - |    6632 B |

### Concat
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Concat                   | SystemConcat                   |     3,456.7250 ns |     18.5042 ns |     17.3088 ns | 0.0076 |      - |     120 B |
| Concat                   | SpanConcat                     |     6,078.0059 ns |     18.3870 ns |     17.1992 ns |      - |      - |         - |
| Contains                 | SpanContains                   |        47.2104 ns |      0.2871 ns |      0.2685 ns |      - |      - |         - |

### Contains
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Contains                 | SystemContains                 |        48.7280 ns |      0.1415 ns |      0.1323 ns |      - |      - |         - |
| Contains                 | HandcraftedContains            |        51.6118 ns |      0.3134 ns |      0.2931 ns |      - |      - |         - |

### Count
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Count                    | SpanCount                      |         1.0380 ns |      0.0112 ns |      0.0099 ns |      - |      - |         - |
| Count                    | SystemCount                    |         1.6181 ns |      0.0098 ns |      0.0082 ns |      - |      - |         - |
| Count                    | SystemCountPredicate           |       461.9095 ns |      0.5679 ns |      0.4742 ns |      - |      - |         - |
| Count                    | SpanCountPredicate             |       776.3301 ns |      3.2094 ns |      3.0021 ns |      - |      - |         - |

### CountBy
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| CountBy                  | SystemCountBy                  |     3,026.6075 ns |     52.5966 ns |     46.6255 ns | 0.0267 |      - |     344 B |
| CountBy                  | SpanCountBy                    |     5,955.2957 ns |     49.7902 ns |     46.5738 ns |      - |      - |         - |

### DefaultIfEmpty
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| DefaultIfEmpty           | SpanDefaultIfEmpty             |         2.1175 ns |      0.0185 ns |      0.0173 ns |      - |      - |         - |
| DefaultIfEmpty           | SystemDefaultIfEmpty           |         9.1914 ns |      0.1522 ns |      0.1424 ns | 0.0038 |      - |      48 B |

### Distinct
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Distinct                 | SpanDistinct                   |     4,711.3708 ns |     26.0185 ns |     24.3377 ns |      - |      - |         - |
| Distinct                 | SystemDistinct                 |     7,984.9707 ns |     71.5405 ns |     66.9190 ns | 4.6692 | 0.7629 |   58656 B |

### DistinctBy
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| DistinctBy               | SpanDistinctBy                 |     3,426.4758 ns |     10.6587 ns |      9.9702 ns |      - |      - |         - |
| DistinctBy               | SystemDistinctBy               |     3,501.2782 ns |     17.2963 ns |     16.1789 ns | 0.0267 |      - |     360 B |

### ElementAt
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| ElementAt                | SpanElementAt                  |         5.6168 ns |      0.0093 ns |      0.0087 ns |      - |      - |         - |
| ElementAt                | SystemElementAt                |         8.1542 ns |      0.0250 ns |      0.0222 ns |      - |      - |         - |

### ElementAtOrDefault
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| ElementAtOrDefault       | SpanElementAtOrDefault         |         5.6363 ns |      0.0101 ns |      0.0094 ns |      - |      - |         - |
| ElementAtOrDefault       | SystemElementAtOrDefault       |         9.1710 ns |      0.0744 ns |      0.0696 ns |      - |      - |         - |

### Except
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Except                   | SystemExcept                   |     6,760.1889 ns |     23.0700 ns |     21.5797 ns | 1.4267 | 0.0839 |   17928 B |
| Except                   | SpanExcept                     |     9,173.2855 ns |     67.3236 ns |     59.6806 ns |      - |      - |         - |

### ExceptBy
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| ExceptBy                 | SystemExceptBy                 |     7,120.8045 ns |     30.3109 ns |     28.3528 ns | 1.4267 | 0.0839 |   17944 B |
| ExceptBy                 | SpanExceptBy                   |     9,713.0089 ns |     43.3841 ns |     38.4589 ns |      - |      - |         - |

### First
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| First                    | SystemFirst                    |       202.1929 ns |      1.0632 ns |      0.9945 ns |      - |      - |         - |
| First                    | SpanFirst                      |       538.0269 ns |      4.5352 ns |      4.2422 ns |      - |      - |         - |

### FirstOrDefault
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| FirstOrDefault           | SystemFirstOrDefault           |       201.5848 ns |      0.8736 ns |      0.8172 ns |      - |      - |         - |
| FirstOrDefault           | SpanFirstOrDefault             |       536.8293 ns |      3.0228 ns |      2.8275 ns |      - |      - |         - |

### ForEach
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| ForEach                  | SpanForEach                    |       286.7086 ns |      1.3312 ns |      1.2452 ns |      - |      - |         - |

### GroupBy
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| GroupBy                  | SystemGroupBy                  |     5,417.7638 ns |     40.4992 ns |     35.9015 ns | 2.2736 | 0.1221 |   28536 B |
| GroupBy                  | SpanGroupBy                    |     7,010.1171 ns |     36.6301 ns |     34.2638 ns | 0.6104 |      - |    7680 B |

### GroupJoin
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| GroupJoin                | SystemGroupJoin                |    18,069.7385 ns |    353.5799 ns |    447.1654 ns | 9.7961 | 3.2349 |  123216 B |
| GroupJoin                | SpanGroupJoin                  |   366,121.8164 ns |  4,961.3019 ns |  4,640.8049 ns |      - |      - |       1 B |

### Index
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Index                    | SpanIndex                      |       992.5626 ns |      6.4616 ns |      6.0441 ns |      - |      - |         - |
| Index                    | SystemIndex                    |     4,984.6546 ns |     19.4658 ns |     17.2559 ns | 0.0076 |      - |      96 B |

### Intersect
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Intersect                | SystemIntersect                |     8,071.1188 ns |     26.4233 ns |     23.4235 ns | 1.4191 | 0.0763 |   17928 B |
| Intersect                | SpanIntersect                  |    12,262.3406 ns |     51.8240 ns |     48.4762 ns |      - |      - |         - |

### IntersectBy
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| IntersectBy              | SystemIntersectBy              |     8,180.2696 ns |     23.7984 ns |     22.2610 ns | 1.4191 | 0.0763 |   17944 B |
| IntersectBy              | SpanIntersectBy                |    12,323.0880 ns |     62.9273 ns |     58.8622 ns |      - |      - |         - |

### Join
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Join                     | SystemJoin                     |    19,863.5886 ns |    363.5899 ns |    322.3130 ns | 9.7961 | 3.2349 |  123232 B |
| Join                     | SpanJoin                       |   366,218.0176 ns |  3,916.5341 ns |  3,471.9054 ns |      - |      - |       1 B |

### Last
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Last                     | SpanLast                       |       540.5032 ns |      5.1719 ns |      4.8378 ns |      - |      - |         - |
| Last                     | SystemLast                     |     1,549.1517 ns |      9.2850 ns |      8.6852 ns |      - |      - |         - |

### LastOrDefault
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| LastOrDefault            | SpanLastOrDefault              |       552.7688 ns |      5.2571 ns |      4.9175 ns |      - |      - |         - |
| LastOrDefault            | SystemLastOrDefault            |     1,544.6631 ns |      1.5835 ns |      1.3223 ns |      - |      - |         - |

### LongCount
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| LongCount                | SpanLongCount                  |         1.0552 ns |      0.0148 ns |      0.0131 ns |      - |      - |         - |
| LongCount                | SystemLongCount                |       327.4581 ns |      1.0545 ns |      0.9864 ns | 0.0024 |      - |      32 B |
| LongCount                | SpanLongCountPredicate         |       780.7307 ns |      4.5959 ns |      4.2990 ns |      - |      - |         - |
| LongCount                | SystemLongCountPredicate       |       883.7892 ns |      1.7051 ns |      1.5950 ns | 0.0019 |      - |      32 B |

### Max
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Max                      | SystemMax                      |        31.3130 ns |      0.1012 ns |      0.0897 ns |      - |      - |         - |
| Max                      | SpanMax                        |       676.7271 ns |      1.5084 ns |      1.3372 ns |      - |      - |         - |

### MaxBy
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| MaxBy                    | SystemMaxBy                    |       551.1732 ns |      1.2848 ns |      1.2018 ns | 0.0019 |      - |      32 B |
| MaxBy                    | SpanMaxBy                      |       904.5342 ns |      4.1002 ns |      3.8353 ns |      - |      - |         - |

### Min
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Min                      | SystemMin                      |        31.0749 ns |      0.0478 ns |      0.0423 ns |      - |      - |         - |
| Min                      | SpanMin                        |       720.0131 ns |      2.9890 ns |      2.7959 ns |      - |      - |         - |

### MinBy
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| MinBy                    | SystemMinBy                    |       503.8157 ns |      2.9883 ns |      2.6490 ns | 0.0019 |      - |      32 B |
| MinBy                    | SpanMinBy                      |       880.3269 ns |      5.0001 ns |      4.1753 ns |      - |      - |         - |

### OfType
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| OfType                   | SpanOfTypeIntToNullableInt     |     1,008.5285 ns |      4.3652 ns |      3.6452 ns |      - |      - |         - |
| OfType                   | SpanOfTypeClass                |     1,546.2598 ns |     10.3828 ns |      9.7121 ns |      - |      - |         - |
| OfType                   | SpanOfTypeIntToObject          |     3,057.9873 ns |     18.0221 ns |     15.9761 ns | 1.9569 |      - |   24576 B |
| OfType                   | SystemOfTypeClass              |     4,606.9921 ns |     35.0832 ns |     32.8168 ns |      - |      - |      80 B |
| OfType                   | SystemOfTypeIntToObject        |    19,414.6761 ns |     73.7471 ns |     65.3749 ns | 1.9531 |      - |   24656 B |
| OfType                   | SystemOfTypeIntToNullableInt   |    20,383.4671 ns |     86.0605 ns |     76.2904 ns | 1.9531 |      - |   24656 B |

### Order
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Order                    | SystemOrder                    |     3,030.4275 ns |     57.3146 ns |     66.0035 ns | 0.3319 |      - |    4176 B |
| Order                    | SystemOrderDescending          |     8,017.2544 ns |     34.4015 ns |     30.4960 ns | 0.3204 |      - |    4176 B |
| Order                    | SpanOrder                      |    29,761.6776 ns |    150.7767 ns |    141.0367 ns |      - |      - |         - |
| Order                    | SpanOrderDescending            |    31,051.3485 ns |    168.7872 ns |    157.8836 ns |      - |      - |         - |

### OrderBy
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| OrderBy                  | SystemOrderBy                  |     7,615.4615 ns |     27.2201 ns |     24.1299 ns | 0.9918 | 0.0305 |   12568 B |
| OrderBy                  | SystemOrderByDescending        |    12,569.8716 ns |     99.9335 ns |     93.4778 ns | 0.9918 | 0.0305 |   12568 B |
| OrderBy                  | SpanOrderBy                    |    29,029.4724 ns |    145.1164 ns |    135.7420 ns |      - |      - |         - |
| OrderBy                  | SpanOrderByDescending          |    31,094.9064 ns |    168.6357 ns |    157.7419 ns |      - |      - |         - |

### Prepend
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Prepend                  | SpanPrepend                    |       489.8280 ns |      5.0062 ns |      4.6828 ns |      - |      - |         - |
| Prepend                  | SystemPrepend                  |     1,483.7582 ns |     11.7768 ns |     11.0161 ns | 0.0057 |      - |      88 B |

### Range
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Range                    | SpanRange                      |       201.6353 ns |      0.7508 ns |      0.7023 ns |      - |      - |         - |
| Range                    | HandcraftedRange               |       304.5505 ns |      2.7191 ns |      2.5435 ns | 0.3281 |      - |    4120 B |
| Range                    | SystemRange                    |       420.9398 ns |      1.3013 ns |      1.1536 ns | 0.0029 |      - |      40 B |

### Repeat
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Repeat                   | SpanRepeat                     |       201.6920 ns |      0.6525 ns |      0.5784 ns |      - |      - |         - |
| Repeat                   | SystemRepeat                   |       435.2726 ns |      3.3130 ns |      3.0990 ns | 0.0024 |      - |      32 B |

### Reverse
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Reverse                  | HandcraftedReverse             |       397.4128 ns |      3.1328 ns |      2.9304 ns | 0.3281 |      - |    4120 B |
| Reverse                  | SystemReverse                  |       840.4237 ns |      6.5786 ns |      6.1537 ns | 0.3319 |      - |    4168 B |
| Reverse                  | SpanReverse                    |     1,513.4816 ns |     23.7059 ns |     22.1745 ns |      - |      - |         - |

### Select
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Select                   | SpanSelect                     |       596.0356 ns |      3.5300 ns |      3.3019 ns |      - |      - |         - |
| Select                   | SystemSelect                   |       690.0395 ns |      4.4146 ns |      4.1294 ns | 0.0038 |      - |      48 B |

### SelectMany
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| SelectMany               | SystemSelectMany               | 1,677,120.1172 ns |  5,617.6069 ns |  4,979.8622 ns | 1.9531 |      - |   41057 B |
| SelectMany               | SpanSelectMany                 | 2,526,526.1719 ns | 15,733.4421 ns | 14,717.0715 ns |      - |      - |       3 B |

### SequenceEqual
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| SequenceEqual            | SystemSequenceEqual            |         1.6329 ns |      0.0076 ns |      0.0071 ns |      - |      - |         - |
| SequenceEqual            | SpanSequenceEqual              |         1.8938 ns |      0.0065 ns |      0.0058 ns |      - |      - |         - |
| SequenceEqual            | SystemSequenceEqualSequence    |       487.2647 ns |      2.3494 ns |      1.9619 ns | 0.0057 |      - |      80 B |
| SequenceEqual            | SpanSequenceEqualSequence      |       502.7118 ns |      1.3745 ns |      1.2184 ns |      - |      - |         - |

### Shuffle
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Shuffle                  | HandcraftedShuffle             |     1,996.9715 ns |      5.5126 ns |      4.8868 ns |      - |      - |         - |
| Shuffle                  | SpanShuffle                    |     4,411.9480 ns |     12.3245 ns |     10.9254 ns |      - |      - |         - |

### Single
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Single                   | SystemSingle                   |       212.9015 ns |      2.5639 ns |      2.3982 ns |      - |      - |         - |
| Single                   | SpanSingle                     |       520.0386 ns |      1.5505 ns |      1.4503 ns |      - |      - |         - |

### SingleOrDefault
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| SingleOrDefault          | SystemSingleOrDefault          |       201.7537 ns |      0.2671 ns |      0.2085 ns |      - |      - |         - |
| SingleOrDefault          | SpanSingleOrDefault            |       512.0498 ns |      5.2074 ns |      4.3484 ns |      - |      - |         - |

### Skip
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Skip                     | SpanSkip                       |         4.3893 ns |      0.0312 ns |      0.0292 ns |      - |      - |         - |
| Skip                     | SystemSkip                     |        15.2481 ns |      0.1693 ns |      0.1583 ns | 0.0038 |      - |      48 B |

### SkipWhile
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| SkipLast                 | SpanSkipLast                   |         3.8173 ns |      0.0213 ns |      0.0199 ns |      - |      - |         - |
| SkipLast                 | SystemSkipLast                 |        30.5432 ns |      0.1212 ns |      0.1074 ns | 0.0108 |      - |     136 B |

### SkipWhile
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| SkipWhile                | SystemSkipWhile                |       889.5269 ns |      2.5934 ns |      2.4259 ns | 0.0076 |      - |     104 B |
| SkipWhile                | SpanSkipWhile                  |     1,018.9567 ns |      2.9049 ns |      2.7172 ns |      - |      - |         - |

### Sum
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Sum                      | SystemSum                      |        59.8201 ns |      0.2753 ns |      0.2575 ns |      - |      - |         - |
| Sum                      | SpanSum                        |       669.4016 ns |      9.2260 ns |      8.6300 ns |      - |      - |         - |

### Take
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Take                     | SpanTake                       |       493.7533 ns |      1.4328 ns |      1.2702 ns |      - |      - |         - |
| Take                     | SystemTake                     |     3,472.1362 ns |     19.6271 ns |     18.3592 ns | 0.0038 |      - |      48 B |

### TakeLast
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| TakeLast                 | SpanTakeLast                   |     1,234.4180 ns |     10.2318 ns |      9.0702 ns |      - |      - |         - |
| TakeLast                 | SystemTakeLast                 |     5,347.0905 ns |     61.0954 ns |     57.1486 ns | 0.0076 |      - |     136 B |

### TakeWhile
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| TakeWhile                | SpanTakeWhile                  |     2,045.9239 ns |     18.9414 ns |     16.7910 ns |      - |      - |         - |
| TakeWhile                | SystemTakeWhile                |     2,327.1187 ns |     13.3748 ns |     11.8564 ns | 0.0076 |      - |     104 B |

### ThenBy
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| ThenBy                   | SystemThenByDescending         |    14,537.3040 ns |    119.0894 ns |    111.3963 ns | 1.6632 | 0.0916 |   20928 B |
| ThenBy                   | SystemThenBy                   |    14,588.9819 ns |     82.5623 ns |     77.2288 ns | 1.6632 | 0.0916 |   20928 B |
| ThenBy                   | SpanThenBy                     |    47,443.0465 ns |    292.1843 ns |    273.3094 ns |      - |      - |         - |
| ThenBy                   | SpanThenByDescending           |    48,341.7570 ns |    317.5585 ns |    297.0444 ns |      - |      - |         - |

### ToArray
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| ToArray                  | SystemToArray                  |       158.4132 ns |      1.7688 ns |      1.6545 ns | 0.3314 |      - |    4160 B |
| ToArray                  | SpanToArray                    |       516.0287 ns |      4.3198 ns |      4.0408 ns | 0.3281 |      - |    4120 B |

### ToDictionary
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| ToDictionary             | SystemToDictionary             |     3,373.3929 ns |     22.4903 ns |     21.0374 ns | 1.7662 | 0.1335 |   22192 B |
| ToDictionary             | SpanToDictionary               |     3,529.4652 ns |     14.7830 ns |     13.8280 ns | 1.7662 | 0.1335 |   22192 B |

### ToHashSet
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| ToHashSet                | SpanToHashSet                  |     3,103.9075 ns |     13.1026 ns |     11.6151 ns | 1.4153 |      - |   17768 B |
| ToHashSet                | SystemToHashSet                |     3,789.1108 ns |     14.6475 ns |     12.9846 ns | 1.4153 | 0.0877 |   17800 B |

### ToList
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| ToList                   | SpanToList                     |       133.3044 ns |      1.4048 ns |      1.2453 ns | 0.3307 |      - |    4152 B |
| ToList                   | SystemToList                   |       134.0427 ns |      1.3452 ns |      1.2583 ns | 0.3307 |      - |    4152 B |

### ToLookup
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| ToLookup                 | SystemToLookup                 |    15,101.9338 ns |    180.3529 ns |    140.8077 ns | 9.7961 | 2.5024 |  123040 B |
| ToLookup                 | SpanToLookup                   |    19,453.4567 ns |    371.3411 ns |    412.7447 ns | 9.7961 | 2.4719 |  123056 B |

### TryGetNonEnumeratedCount
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| TryGetNonEnumeratedCount | SpanTryGetNonEnumeratedCount   |         0.0116 ns |      0.0052 ns |      0.0043 ns |      - |      - |         - |
| TryGetNonEnumeratedCount | SystemTryGetNonEnumeratedCount |         2.4207 ns |      0.0244 ns |      0.0229 ns |      - |      - |         - |

### Union
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Union                    | SystemUnion                    |    10,866.0875 ns |     87.5037 ns |     73.0695 ns | 4.6692 | 0.7629 |   58696 B |
| Union                    | SpanUnion                      |    12,573.6170 ns |     21.2408 ns |     19.8687 ns |      - |      - |         - |

### UnionBy
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| UnionBy                  | SystemUnionBy                  |    11,812.2918 ns |     91.7217 ns |     81.3089 ns | 4.6692 | 0.7629 |   58736 B |
| UnionBy                  | SpanUnionBy                    |    14,351.1039 ns |     58.7057 ns |     54.9134 ns |      - |      - |         - |

### Where
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Where                    | HandcraftedWhere               |       302.4339 ns |      1.8610 ns |      1.7408 ns | 0.1650 |      - |    2072 B |
| Where                    | SystemWhere                    |       811.7876 ns |      3.1324 ns |      2.7768 ns | 0.0038 |      - |      48 B |
| Where                    | SpanWhere                      |       841.1094 ns |      5.1144 ns |      4.7840 ns |      - |      - |         - |

### Zip
| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| Zip                      | SystemZip                      |     5,031.0802 ns |     34.9817 ns |     32.7219 ns | 0.0076 |      - |     144 B |
| Zip                      | SpanZip                        |     5,829.9393 ns |     38.1152 ns |     33.7882 ns |      - |      - |         - |