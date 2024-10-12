## Performance benchmarks

This document provides an overview of performance benchmarks for various operations. The benchmarks compare different implementations to help you understand the performance characteristics of each approach.
In the following benchmarks:

- Span*** refers to SpanLinq.SpanEnumerable.***
  System*** refers to System.Linq.Enumerable.***
  Handcrafted*** refers to optimized code that uses Span<T> directly.

These comparisons will help you evaluate the performance differences between standard LINQ operations, SpanLinq implementations, and hand-optimized code using Span<T>.

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

| Type                          | Method                         |              Mean |          Error |         StdDev |   Gen0 |   Gen1 | Allocated |
|-------------------------------|--------------------------------|------------------:|---------------:|---------------:|-------:|-------:|----------:|
| TryGetNonEnumeratedCountBench | SpanTryGetNonEnumeratedCount   |         0.0116 ns |      0.0052 ns |      0.0043 ns |      - |      - |         - |
| CountBench                    | SpanCount                      |         1.0380 ns |      0.0112 ns |      0.0099 ns |      - |      - |         - |
| LongCountBench                | SpanLongCount                  |         1.0552 ns |      0.0148 ns |      0.0131 ns |      - |      - |         - |
| CountBench                    | SystemCount                    |         1.6181 ns |      0.0098 ns |      0.0082 ns |      - |      - |         - |
| SequenceEqualBench            | SystemSequenceEqual            |         1.6329 ns |      0.0076 ns |      0.0071 ns |      - |      - |         - |
| SequenceEqualBench            | SpanSequenceEqual              |         1.8938 ns |      0.0065 ns |      0.0058 ns |      - |      - |         - |
| DefaultIfEmptyBench           | SpanDefaultIfEmpty             |         2.1175 ns |      0.0185 ns |      0.0173 ns |      - |      - |         - |
| TryGetNonEnumeratedCountBench | SystemTryGetNonEnumeratedCount |         2.4207 ns |      0.0244 ns |      0.0229 ns |      - |      - |         - |
| SkipLastBench                 | SpanSkipLast                   |         3.8173 ns |      0.0213 ns |      0.0199 ns |      - |      - |         - |
| SkipBench                     | SpanSkip                       |         4.3893 ns |      0.0312 ns |      0.0292 ns |      - |      - |         - |
| ElementAtBench                | SpanElementAt                  |         5.6168 ns |      0.0093 ns |      0.0087 ns |      - |      - |         - |
| ElementAtOrDefaultBench       | SpanElementAtOrDefault         |         5.6363 ns |      0.0101 ns |      0.0094 ns |      - |      - |         - |
| ElementAtBench                | SystemElementAt                |         8.1542 ns |      0.0250 ns |      0.0222 ns |      - |      - |         - |
| ElementAtOrDefaultBench       | SystemElementAtOrDefault       |         9.1710 ns |      0.0744 ns |      0.0696 ns |      - |      - |         - |
| DefaultIfEmptyBench           | SystemDefaultIfEmpty           |         9.1914 ns |      0.1522 ns |      0.1424 ns | 0.0038 |      - |      48 B |
| SkipBench                     | SystemSkip                     |        15.2481 ns |      0.1693 ns |      0.1583 ns | 0.0038 |      - |      48 B |
| SkipLastBench                 | SystemSkipLast                 |        30.5432 ns |      0.1212 ns |      0.1074 ns | 0.0108 |      - |     136 B |
| MinBench                      | SystemMin                      |        31.0749 ns |      0.0478 ns |      0.0423 ns |      - |      - |         - |
| MaxBench                      | SystemMax                      |        31.3130 ns |      0.1012 ns |      0.0897 ns |      - |      - |         - |
| ContainsBench                 | SpanContains                   |        47.2104 ns |      0.2871 ns |      0.2685 ns |      - |      - |         - |
| ContainsBench                 | SystemContains                 |        48.7280 ns |      0.1415 ns |      0.1323 ns |      - |      - |         - |
| ContainsBench                 | HandcraftedContains            |        51.6118 ns |      0.3134 ns |      0.2931 ns |      - |      - |         - |
| SumBench                      | SystemSum                      |        59.8201 ns |      0.2753 ns |      0.2575 ns |      - |      - |         - |
| AverageBench                  | SystemAverage                  |        77.6144 ns |      0.0706 ns |      0.0589 ns |      - |      - |         - |
| ToListBench                   | SpanToList                     |       133.3044 ns |      1.4048 ns |      1.2453 ns | 0.3307 |      - |    4152 B |
| ToListBench                   | SystemToList                   |       134.0427 ns |      1.3452 ns |      1.2583 ns | 0.3307 |      - |    4152 B |
| ToArrayBench                  | SystemToArray                  |       158.4132 ns |      1.7688 ns |      1.6545 ns | 0.3314 |      - |    4160 B |
| FirstOrDefaultBench           | SystemFirstOrDefault           |       201.5848 ns |      0.8736 ns |      0.8172 ns |      - |      - |         - |
| RangeBench                    | SpanRange                      |       201.6353 ns |      0.7508 ns |      0.7023 ns |      - |      - |         - |
| RepeatBench                   | SpanRepeat                     |       201.6920 ns |      0.6525 ns |      0.5784 ns |      - |      - |         - |
| SingleOrDefaultBench          | SystemSingleOrDefault          |       201.7537 ns |      0.2671 ns |      0.2085 ns |      - |      - |         - |
| FirstBench                    | SystemFirst                    |       202.1929 ns |      1.0632 ns |      0.9945 ns |      - |      - |         - |
| AllBench                      | SystemAll                      |       203.8615 ns |      0.2724 ns |      0.2548 ns |      - |      - |         - |
| AnyBench                      | SystemAny                      |       205.5439 ns |      0.1604 ns |      0.1339 ns |      - |      - |         - |
| SingleBench                   | SystemSingle                   |       212.9015 ns |      2.5639 ns |      2.3982 ns |      - |      - |         - |
| AggregateBench                | SystemAggregate                |       263.7590 ns |      1.2553 ns |      1.1128 ns |      - |      - |         - |
| ForEachBench                  | SpanForEach                    |       286.7086 ns |      1.3312 ns |      1.2452 ns |      - |      - |         - |
| WhereBench                    | HandcraftedWhere               |       302.4339 ns |      1.8610 ns |      1.7408 ns | 0.1650 |      - |    2072 B |
| RangeBench                    | HandcraftedRange               |       304.5505 ns |      2.7191 ns |      2.5435 ns | 0.3281 |      - |    4120 B |
| LongCountBench                | SystemLongCount                |       327.4581 ns |      1.0545 ns |      0.9864 ns | 0.0024 |      - |      32 B |
| ReverseBench                  | HandcraftedReverse             |       397.4128 ns |      3.1328 ns |      2.9304 ns | 0.3281 |      - |    4120 B |
| RangeBench                    | SystemRange                    |       420.9398 ns |      1.3013 ns |      1.1536 ns | 0.0029 |      - |      40 B |
| RepeatBench                   | SystemRepeat                   |       435.2726 ns |      3.3130 ns |      3.0990 ns | 0.0024 |      - |      32 B |
| CountBench                    | SystemCountPredicate           |       461.9095 ns |      0.5679 ns |      0.4742 ns |      - |      - |         - |
| SequenceEqualBench            | SystemSequenceEqualSequence    |       487.2647 ns |      2.3494 ns |      1.9619 ns | 0.0057 |      - |      80 B |
| PrependBench                  | SpanPrepend                    |       489.8280 ns |      5.0062 ns |      4.6828 ns |      - |      - |         - |
| TakeBench                     | SpanTake                       |       493.7533 ns |      1.4328 ns |      1.2702 ns |      - |      - |         - |
| SequenceEqualBench            | SpanSequenceEqualSequence      |       502.7118 ns |      1.3745 ns |      1.2184 ns |      - |      - |         - |
| MinByBench                    | SystemMinBy                    |       503.8157 ns |      2.9883 ns |      2.6490 ns | 0.0019 |      - |      32 B |
| SingleOrDefaultBench          | SpanSingleOrDefault            |       512.0498 ns |      5.2074 ns |      4.3484 ns |      - |      - |         - |
| ToArrayBench                  | SpanToArray                    |       516.0287 ns |      4.3198 ns |      4.0408 ns | 0.3281 |      - |    4120 B |
| AnyBench                      | SpanAny                        |       516.7499 ns |      1.6940 ns |      1.5016 ns |      - |      - |         - |
| AllBench                      | SpanAll                        |       518.0548 ns |      2.1874 ns |      1.9391 ns |      - |      - |         - |
| SingleBench                   | SpanSingle                     |       520.0386 ns |      1.5505 ns |      1.4503 ns |      - |      - |         - |
| AppendBench                   | SpanAppend                     |       532.3850 ns |      9.4246 ns |      8.8158 ns |      - |      - |         - |
| FirstOrDefaultBench           | SpanFirstOrDefault             |       536.8293 ns |      3.0228 ns |      2.8275 ns |      - |      - |         - |
| FirstBench                    | SpanFirst                      |       538.0269 ns |      4.5352 ns |      4.2422 ns |      - |      - |         - |
| LastBench                     | SpanLast                       |       540.5032 ns |      5.1719 ns |      4.8378 ns |      - |      - |         - |
| AsEnumerableBench             | SystemAsEnumerable             |       546.0603 ns |      2.0265 ns |      1.8956 ns | 0.0019 |      - |      32 B |
| MaxByBench                    | SystemMaxBy                    |       551.1732 ns |      1.2848 ns |      1.2018 ns | 0.0019 |      - |      32 B |
| LastOrDefaultBench            | SpanLastOrDefault              |       552.7688 ns |      5.2571 ns |      4.9175 ns |      - |      - |         - |
| SelectBench                   | SpanSelect                     |       596.0356 ns |      3.5300 ns |      3.3019 ns |      - |      - |         - |
| AggregateBench                | SpanAggregate                  |       619.7651 ns |      1.4326 ns |      1.3400 ns |      - |      - |         - |
| SumBench                      | SpanSum                        |       669.4016 ns |      9.2260 ns |      8.6300 ns |      - |      - |         - |
| AverageBench                  | SpanAverage                    |       669.5447 ns |      2.5918 ns |      2.2975 ns |      - |      - |         - |
| MaxBench                      | SpanMax                        |       676.7271 ns |      1.5084 ns |      1.3372 ns |      - |      - |         - |
| SelectBench                   | SystemSelect                   |       690.0395 ns |      4.4146 ns |      4.1294 ns | 0.0038 |      - |      48 B |
| ChunkBench                    | SystemChunk                    |       704.1107 ns |      2.3762 ns |      1.9843 ns | 0.5283 |      - |    6632 B |
| MinBench                      | SpanMin                        |       720.0131 ns |      2.9890 ns |      2.7959 ns |      - |      - |         - |
| CountBench                    | SpanCountPredicate             |       776.3301 ns |      3.2094 ns |      3.0021 ns |      - |      - |         - |
| LongCountBench                | SpanLongCountPredicate         |       780.7307 ns |      4.5959 ns |      4.2990 ns |      - |      - |         - |
| WhereBench                    | SystemWhere                    |       811.7876 ns |      3.1324 ns |      2.7768 ns | 0.0038 |      - |      48 B |
| ReverseBench                  | SystemReverse                  |       840.4237 ns |      6.5786 ns |      6.1537 ns | 0.3319 |      - |    4168 B |
| WhereBench                    | SpanWhere                      |       841.1094 ns |      5.1144 ns |      4.7840 ns |      - |      - |         - |
| ChunkBench                    | HandcraftedChunk               |       853.0973 ns |      7.8673 ns |      7.3591 ns | 0.5922 | 0.0019 |    7440 B |
| MinByBench                    | SpanMinBy                      |       880.3269 ns |      5.0001 ns |      4.1753 ns |      - |      - |         - |
| LongCountBench                | SystemLongCountPredicate       |       883.7892 ns |      1.7051 ns |      1.5950 ns | 0.0019 |      - |      32 B |
| SkipWhileBench                | SystemSkipWhile                |       889.5269 ns |      2.5934 ns |      2.4259 ns | 0.0076 |      - |     104 B |
| MaxByBench                    | SpanMaxBy                      |       904.5342 ns |      4.1002 ns |      3.8353 ns |      - |      - |         - |
| IndexBench                    | SpanIndex                      |       992.5626 ns |      6.4616 ns |      6.0441 ns |      - |      - |         - |
| CastBench                     | SpanCastIntToNullableInt       |     1,004.6952 ns |      2.3091 ns |      2.1599 ns |      - |      - |         - |
| OfTypeBench                   | SpanOfTypeIntToNullableInt     |     1,008.5285 ns |      4.3652 ns |      3.6452 ns |      - |      - |         - |
| SkipWhileBench                | SpanSkipWhile                  |     1,018.9567 ns |      2.9049 ns |      2.7172 ns |      - |      - |         - |
| ChunkBench                    | SpanChunk                      |     1,136.6704 ns |     12.9198 ns |     12.0852 ns | 0.5283 |      - |    6632 B |
| CastBench                     | SpanCastClass                  |     1,204.0367 ns |      2.5576 ns |      2.3924 ns |      - |      - |         - |
| TakeLastBench                 | SpanTakeLast                   |     1,234.4180 ns |     10.2318 ns |      9.0702 ns |      - |      - |         - |
| AsEnumerableBench             | SpanAsEnumerable               |     1,301.6000 ns |      9.9575 ns |      9.3143 ns | 0.0019 |      - |      32 B |
| PrependBench                  | SystemPrepend                  |     1,483.7582 ns |     11.7768 ns |     11.0161 ns | 0.0057 |      - |      88 B |
| AppendBench                   | SystemAppend                   |     1,502.3679 ns |     13.0312 ns |     12.1894 ns | 0.0057 |      - |      88 B |
| ReverseBench                  | SpanReverse                    |     1,513.4816 ns |     23.7059 ns |     22.1745 ns |      - |      - |         - |
| LastOrDefaultBench            | SystemLastOrDefault            |     1,544.6631 ns |      1.5835 ns |      1.3223 ns |      - |      - |         - |
| OfTypeBench                   | SpanOfTypeClass                |     1,546.2598 ns |     10.3828 ns |      9.7121 ns |      - |      - |         - |
| LastBench                     | SystemLast                     |     1,549.1517 ns |      9.2850 ns |      8.6852 ns |      - |      - |         - |
| ShuffleBench                  | HandcraftedShuffle             |     1,996.9715 ns |      5.5126 ns |      4.8868 ns |      - |      - |         - |
| TakeWhileBench                | SpanTakeWhile                  |     2,045.9239 ns |     18.9414 ns |     16.7910 ns |      - |      - |         - |
| TakeWhileBench                | SystemTakeWhile                |     2,327.1187 ns |     13.3748 ns |     11.8564 ns | 0.0076 |      - |     104 B |
| CastBench                     | SpanCastIntToObject            |     2,871.0990 ns |     24.2749 ns |     20.2707 ns | 1.9569 |      - |   24576 B |
| CastBench                     | SystemCastClass                |     2,945.3580 ns |      6.1851 ns |      4.8290 ns |      - |      - |      32 B |
| CountByBench                  | SystemCountBy                  |     3,026.6075 ns |     52.5966 ns |     46.6255 ns | 0.0267 |      - |     344 B |
| OrderBench                    | SystemOrder                    |     3,030.4275 ns |     57.3146 ns |     66.0035 ns | 0.3319 |      - |    4176 B |
| AggregateByBench              | SystemAggregateBy              |     3,057.8180 ns |     20.8334 ns |     19.4875 ns | 0.0267 |      - |     368 B |
| OfTypeBench                   | SpanOfTypeIntToObject          |     3,057.9873 ns |     18.0221 ns |     15.9761 ns | 1.9569 |      - |   24576 B |
| ToHashSetBench                | SpanToHashSet                  |     3,103.9075 ns |     13.1026 ns |     11.6151 ns | 1.4153 |      - |   17768 B |
| ToDictionaryBench             | SystemToDictionary             |     3,373.3929 ns |     22.4903 ns |     21.0374 ns | 1.7662 | 0.1335 |   22192 B |
| DistinctByBench               | SpanDistinctBy                 |     3,426.4758 ns |     10.6587 ns |      9.9702 ns |      - |      - |         - |
| ConcatBench                   | SystemConcat                   |     3,456.7250 ns |     18.5042 ns |     17.3088 ns | 0.0076 |      - |     120 B |
| TakeBench                     | SystemTake                     |     3,472.1362 ns |     19.6271 ns |     18.3592 ns | 0.0038 |      - |      48 B |
| DistinctByBench               | SystemDistinctBy               |     3,501.2782 ns |     17.2963 ns |     16.1789 ns | 0.0267 |      - |     360 B |
| ToDictionaryBench             | SpanToDictionary               |     3,529.4652 ns |     14.7830 ns |     13.8280 ns | 1.7662 | 0.1335 |   22192 B |
| ToHashSetBench                | SystemToHashSet                |     3,789.1108 ns |     14.6475 ns |     12.9846 ns | 1.4153 | 0.0877 |   17800 B |
| ShuffleBench                  | SpanShuffle                    |     4,411.9480 ns |     12.3245 ns |     10.9254 ns |      - |      - |         - |
| OfTypeBench                   | SystemOfTypeClass              |     4,606.9921 ns |     35.0832 ns |     32.8168 ns |      - |      - |      80 B |
| DistinctBench                 | SpanDistinct                   |     4,711.3708 ns |     26.0185 ns |     24.3377 ns |      - |      - |         - |
| IndexBench                    | SystemIndex                    |     4,984.6546 ns |     19.4658 ns |     17.2559 ns | 0.0076 |      - |      96 B |
| ZipBench                      | SystemZip                      |     5,031.0802 ns |     34.9817 ns |     32.7219 ns | 0.0076 |      - |     144 B |
| TakeLastBench                 | SystemTakeLast                 |     5,347.0905 ns |     61.0954 ns |     57.1486 ns | 0.0076 |      - |     136 B |
| GroupByBench                  | SystemGroupBy                  |     5,417.7638 ns |     40.4992 ns |     35.9015 ns | 2.2736 | 0.1221 |   28536 B |
| ZipBench                      | SpanZip                        |     5,829.9393 ns |     38.1152 ns |     33.7882 ns |      - |      - |         - |
| CountByBench                  | SpanCountBy                    |     5,955.2957 ns |     49.7902 ns |     46.5738 ns |      - |      - |         - |
| AggregateByBench              | SpanAggregateBy                |     5,989.4566 ns |     21.3168 ns |     19.9398 ns |      - |      - |         - |
| ConcatBench                   | SpanConcat                     |     6,078.0059 ns |     18.3870 ns |     17.1992 ns |      - |      - |         - |
| ExceptBench                   | SystemExcept                   |     6,760.1889 ns |     23.0700 ns |     21.5797 ns | 1.4267 | 0.0839 |   17928 B |
| GroupByBench                  | SpanGroupBy                    |     7,010.1171 ns |     36.6301 ns |     34.2638 ns | 0.6104 |      - |    7680 B |
| ExceptByBench                 | SystemExceptBy                 |     7,120.8045 ns |     30.3109 ns |     28.3528 ns | 1.4267 | 0.0839 |   17944 B |
| OrderByBench                  | SystemOrderBy                  |     7,615.4615 ns |     27.2201 ns |     24.1299 ns | 0.9918 | 0.0305 |   12568 B |
| DistinctBench                 | SystemDistinct                 |     7,984.9707 ns |     71.5405 ns |     66.9190 ns | 4.6692 | 0.7629 |   58656 B |
| OrderBench                    | SystemOrderDescending          |     8,017.2544 ns |     34.4015 ns |     30.4960 ns | 0.3204 |      - |    4176 B |
| IntersectBench                | SystemIntersect                |     8,071.1188 ns |     26.4233 ns |     23.4235 ns | 1.4191 | 0.0763 |   17928 B |
| IntersectByBench              | SystemIntersectBy              |     8,180.2696 ns |     23.7984 ns |     22.2610 ns | 1.4191 | 0.0763 |   17944 B |
| ExceptBench                   | SpanExcept                     |     9,173.2855 ns |     67.3236 ns |     59.6806 ns |      - |      - |         - |
| ExceptByBench                 | SpanExceptBy                   |     9,713.0089 ns |     43.3841 ns |     38.4589 ns |      - |      - |         - |
| UnionBench                    | SystemUnion                    |    10,866.0875 ns |     87.5037 ns |     73.0695 ns | 4.6692 | 0.7629 |   58696 B |
| UnionByBench                  | SystemUnionBy                  |    11,812.2918 ns |     91.7217 ns |     81.3089 ns | 4.6692 | 0.7629 |   58736 B |
| IntersectBench                | SpanIntersect                  |    12,262.3406 ns |     51.8240 ns |     48.4762 ns |      - |      - |         - |
| IntersectByBench              | SpanIntersectBy                |    12,323.0880 ns |     62.9273 ns |     58.8622 ns |      - |      - |         - |
| OrderByBench                  | SystemOrderByDescending        |    12,569.8716 ns |     99.9335 ns |     93.4778 ns | 0.9918 | 0.0305 |   12568 B |
| UnionBench                    | SpanUnion                      |    12,573.6170 ns |     21.2408 ns |     19.8687 ns |      - |      - |         - |
| UnionByBench                  | SpanUnionBy                    |    14,351.1039 ns |     58.7057 ns |     54.9134 ns |      - |      - |         - |
| ThenByBench                   | SystemThenByDescending         |    14,537.3040 ns |    119.0894 ns |    111.3963 ns | 1.6632 | 0.0916 |   20928 B |
| ThenByBench                   | SystemThenBy                   |    14,588.9819 ns |     82.5623 ns |     77.2288 ns | 1.6632 | 0.0916 |   20928 B |
| ToLookupBench                 | SystemToLookup                 |    15,101.9338 ns |    180.3529 ns |    140.8077 ns | 9.7961 | 2.5024 |  123040 B |
| CastBench                     | SystemCastIntToNullableInt     |    17,648.1809 ns |     49.0119 ns |     40.9271 ns | 1.9531 |      - |   24656 B |
| GroupJoinBench                | SystemGroupJoin                |    18,069.7385 ns |    353.5799 ns |    447.1654 ns | 9.7961 | 3.2349 |  123216 B |
| CastBench                     | SystemCastIntToObject          |    19,376.9764 ns |    175.7687 ns |    155.8143 ns | 1.9531 |      - |   24656 B |
| OfTypeBench                   | SystemOfTypeIntToObject        |    19,414.6761 ns |     73.7471 ns |     65.3749 ns | 1.9531 |      - |   24656 B |
| ToLookupBench                 | SpanToLookup                   |    19,453.4567 ns |    371.3411 ns |    412.7447 ns | 9.7961 | 2.4719 |  123056 B |
| JoinBench                     | SystemJoin                     |    19,863.5886 ns |    363.5899 ns |    322.3130 ns | 9.7961 | 3.2349 |  123232 B |
| OfTypeBench                   | SystemOfTypeIntToNullableInt   |    20,383.4671 ns |     86.0605 ns |     76.2904 ns | 1.9531 |      - |   24656 B |
| OrderByBench                  | SpanOrderBy                    |    29,029.4724 ns |    145.1164 ns |    135.7420 ns |      - |      - |         - |
| OrderBench                    | SpanOrder                      |    29,761.6776 ns |    150.7767 ns |    141.0367 ns |      - |      - |         - |
| OrderBench                    | SpanOrderDescending            |    31,051.3485 ns |    168.7872 ns |    157.8836 ns |      - |      - |         - |
| OrderByBench                  | SpanOrderByDescending          |    31,094.9064 ns |    168.6357 ns |    157.7419 ns |      - |      - |         - |
| ThenByBench                   | SpanThenBy                     |    47,443.0465 ns |    292.1843 ns |    273.3094 ns |      - |      - |         - |
| ThenByBench                   | SpanThenByDescending           |    48,341.7570 ns |    317.5585 ns |    297.0444 ns |      - |      - |         - |
| GroupJoinBench                | SpanGroupJoin                  |   366,121.8164 ns |  4,961.3019 ns |  4,640.8049 ns |      - |      - |       1 B |
| JoinBench                     | SpanJoin                       |   366,218.0176 ns |  3,916.5341 ns |  3,471.9054 ns |      - |      - |       1 B |
| SelectManyBench               | SystemSelectMany               | 1,677,120.1172 ns |  5,617.6069 ns |  4,979.8622 ns | 1.9531 |      - |   41057 B |
| SelectManyBench               | SpanSelectMany                 | 2,526,526.1719 ns | 15,733.4421 ns | 14,717.0715 ns |      - |      - |       3 B |
