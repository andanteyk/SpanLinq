```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3880/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700F, 1 CPU, 20 logical and 12 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 9.0.0 (9.0.24.32707), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.32707), X64 RyuJIT AVX2


```
| Type                          | Method                         | Mean              | Error          | StdDev        | Gen0   | Gen1   | Allocated |
|------------------------------ |------------------------------- |------------------:|---------------:|--------------:|-------:|-------:|----------:|
| ChunkBench                    | HandcraftedChunk               |     1,025.8733 ns |     20.3144 ns |    45.0152 ns | 0.5684 | 0.0019 |    7440 B |
| ContainsBench                 | HandcraftedContains            |        57.0523 ns |      0.3060 ns |     0.2712 ns |      - |      - |         - |
| RangeBench                    | HandcraftedRange               |       417.3317 ns |      7.7163 ns |     7.5785 ns | 0.3152 |      - |    4120 B |
| ReverseBench                  | HandcraftedReverse             |       531.8064 ns |     10.1574 ns |    19.8112 ns | 0.3147 |      - |    4120 B |
| ShuffleBench                  | HandcraftedShuffle             |     2,342.5542 ns |     10.0395 ns |     8.8997 ns |      - |      - |         - |
| WhereBench                    | HandcraftedWhere               |       418.3963 ns |      7.7931 ns |     7.2897 ns | 0.1583 |      - |    2072 B |
| AggregateBench                | SpanAggregate                  |       703.1531 ns |      5.0094 ns |     4.6858 ns |      - |      - |         - |
| AggregateByBench              | SpanAggregateBy                |     7,039.1711 ns |     78.1909 ns |    73.1399 ns |      - |      - |         - |
| AllBench                      | SpanAll                        |       623.2619 ns |      3.8695 ns |     3.6195 ns |      - |      - |         - |
| AnyBench                      | SpanAny                        |       621.4804 ns |      2.8776 ns |     2.4029 ns |      - |      - |         - |
| AppendBench                   | SpanAppend                     |       585.3720 ns |      4.2607 ns |     3.9855 ns |      - |      - |         - |
| AsEnumerableBench             | SpanAsEnumerable               |     1,412.4268 ns |      4.4687 ns |     4.1800 ns | 0.0019 |      - |      32 B |
| AverageBench                  | SpanAverage                    |       792.4938 ns |      8.3511 ns |     7.8116 ns |      - |      - |         - |
| CastBench                     | SpanCast                       |    13,664.8865 ns |     86.3377 ns |    80.7603 ns |      - |      - |         - |
| ChunkBench                    | SpanChunk                      |     1,485.8153 ns |     29.4941 ns |    57.5259 ns | 0.5074 |      - |    6632 B |
| ConcatBench                   | SpanConcat                     |     7,239.0393 ns |     54.9072 ns |    51.3602 ns |      - |      - |         - |
| ContainsBench                 | SpanContains                   |        57.4933 ns |      0.9691 ns |     0.8092 ns |      - |      - |         - |
| CountBench                    | SpanCount                      |         1.0495 ns |      0.0080 ns |     0.0074 ns |      - |      - |         - |
| CountBench                    | SpanCountPredicate             |       941.7050 ns |      7.1172 ns |     6.3092 ns |      - |      - |         - |
| CountByBench                  | SpanCountBy                    |     6,714.8288 ns |     39.6717 ns |    33.1277 ns |      - |      - |         - |
| DefaultIfEmptyBench           | SpanDefaultIfEmpty             |         2.2390 ns |      0.0511 ns |     0.0478 ns |      - |      - |         - |
| DistinctBench                 | SpanDistinct                   |     5,590.3677 ns |     44.3969 ns |    39.3567 ns |      - |      - |         - |
| DistinctByBench               | SpanDistinctBy                 |     3,990.4896 ns |     35.6686 ns |    33.3644 ns |      - |      - |         - |
| ElementAtBench                | SpanElementAt                  |         6.5131 ns |      0.0247 ns |     0.0219 ns |      - |      - |         - |
| ElementAtOrDefaultBench       | SpanElementAtOrDefault         |         6.7625 ns |      0.0311 ns |     0.0291 ns |      - |      - |         - |
| ExceptBench                   | SpanExcept                     |    10,886.3120 ns |    214.0385 ns |   219.8018 ns |      - |      - |         - |
| ExceptByBench                 | SpanExceptBy                   |    11,562.4712 ns |    102.2259 ns |    95.6222 ns |      - |      - |         - |
| FirstBench                    | SpanFirst                      |       631.7733 ns |      8.6569 ns |     7.2289 ns |      - |      - |         - |
| FirstOrDefaultBench           | SpanFirstOrDefault             |       625.4326 ns |      4.1760 ns |     3.9062 ns |      - |      - |         - |
| ForEachBench                  | SpanForEach                    |       343.9211 ns |      2.4617 ns |     2.3027 ns |      - |      - |         - |
| GroupByBench                  | SpanGroupBy                    |     8,400.4672 ns |     59.1141 ns |    49.3629 ns | 0.5798 |      - |    7680 B |
| GroupJoinBench                | SpanGroupJoin                  |   407,386.1642 ns |  2,032.0575 ns | 1,801.3660 ns |      - |      - |       1 B |
| IndexBench                    | SpanIndex                      |     1,166.8325 ns |      5.8378 ns |     5.4607 ns |      - |      - |         - |
| IntersectBench                | SpanIntersect                  |    13,906.8128 ns |     44.0326 ns |    36.7692 ns |      - |      - |         - |
| IntersectByBench              | SpanIntersectBy                |    14,007.1946 ns |     46.4568 ns |    41.1827 ns |      - |      - |         - |
| JoinBench                     | SpanJoin                       |   431,884.1016 ns |  1,914.2886 ns | 1,790.6267 ns |      - |      - |       1 B |
| LastBench                     | SpanLast                       |       671.2116 ns |      4.2811 ns |     3.7951 ns |      - |      - |         - |
| LastOrDefaultBench            | SpanLastOrDefault              |       642.5360 ns |      4.4410 ns |     4.1541 ns |      - |      - |         - |
| LongCountBench                | SpanLongCount                  |         1.2523 ns |      0.0042 ns |     0.0039 ns |      - |      - |         - |
| LongCountBench                | SpanLongCountPredicate         |       941.6930 ns |      4.9561 ns |     4.6360 ns |      - |      - |         - |
| MaxBench                      | SpanMax                        |       842.7348 ns |      7.6280 ns |     7.1352 ns |      - |      - |         - |
| MaxByBench                    | SpanMaxBy                      |     1,058.9672 ns |      5.5676 ns |     5.2080 ns |      - |      - |         - |
| MinBench                      | SpanMin                        |       826.2098 ns |      7.0709 ns |     6.6141 ns |      - |      - |         - |
| MinByBench                    | SpanMinBy                      |     1,053.6475 ns |      6.0614 ns |     4.7323 ns |      - |      - |         - |
| OfTypeBench                   | SpanOfType                     |     1,179.0877 ns |      9.2256 ns |     8.6296 ns |      - |      - |         - |
| OrderBench                    | SpanOrder                      |    34,368.3138 ns |    216.1625 ns |   202.1986 ns |      - |      - |         - |
| OrderByBench                  | SpanOrderBy                    |    34,185.7243 ns |    283.8743 ns |   265.5362 ns |      - |      - |         - |
| OrderByBench                  | SpanOrderByDescending          |    36,109.2586 ns |    335.1373 ns |   313.4876 ns |      - |      - |         - |
| OrderBench                    | SpanOrderDescending            |    35,868.7378 ns |    366.8827 ns |   306.3636 ns |      - |      - |         - |
| PrependBench                  | SpanPrepend                    |       591.1857 ns |      3.8304 ns |     3.3956 ns |      - |      - |         - |
| RangeBench                    | SpanRange                      |       242.5903 ns |      1.8381 ns |     1.7194 ns |      - |      - |         - |
| RepeatBench                   | SpanRepeat                     |       284.6227 ns |      1.8423 ns |     1.7233 ns |      - |      - |         - |
| ReverseBench                  | SpanReverse                    |     1,730.8057 ns |      9.9866 ns |     9.3415 ns |      - |      - |         - |
| SelectBench                   | SpanSelect                     |       707.1288 ns |      2.9962 ns |     2.8027 ns |      - |      - |         - |
| SelectManyBench               | SpanSelectMany                 | 4,120,231.8917 ns |  9,787.7124 ns | 8,676.5521 ns |      - |      - |       3 B |
| SequenceEqualBench            | SpanSequenceEqual              |         2.1860 ns |      0.0172 ns |     0.0161 ns |      - |      - |         - |
| SequenceEqualBench            | SpanSequenceEqualSequence      |       631.8163 ns |      5.2091 ns |     4.8726 ns |      - |      - |         - |
| ShuffleBench                  | SpanShuffle                    |     5,400.5957 ns |     39.5579 ns |    37.0025 ns |      - |      - |         - |
| SingleBench                   | SpanSingle                     |       632.5001 ns |      4.1461 ns |     3.8783 ns |      - |      - |         - |
| SingleOrDefaultBench          | SpanSingleOrDefault            |       620.5624 ns |      3.9251 ns |     3.4795 ns |      - |      - |         - |
| SkipBench                     | SpanSkip                       |         4.6888 ns |      0.0323 ns |     0.0303 ns |      - |      - |         - |
| SkipLastBench                 | SpanSkipLast                   |         4.7297 ns |      0.0732 ns |     0.0685 ns |      - |      - |         - |
| SkipWhileBench                | SpanSkipWhile                  |     1,286.5033 ns |     10.4907 ns |     9.8130 ns |      - |      - |         - |
| SumBench                      | SpanSum                        |       701.6002 ns |      3.3023 ns |     3.0889 ns |      - |      - |         - |
| TakeBench                     | SpanTake                       |       580.5119 ns |      1.5037 ns |     1.3330 ns |      - |      - |         - |
| TakeLastBench                 | SpanTakeLast                   |     1,296.4867 ns |      5.9846 ns |     5.3052 ns |      - |      - |         - |
| TakeWhileBench                | SpanTakeWhile                  |     2,318.1701 ns |     11.9447 ns |    10.5887 ns |      - |      - |         - |
| ThenByBench                   | SpanThenBy                     |    56,444.8691 ns |    153.8347 ns |   136.3704 ns |      - |      - |         - |
| ThenByBench                   | SpanThenByDescending           |    56,471.0844 ns |    281.0412 ns |   262.8861 ns |      - |      - |         - |
| ToDictionaryBench             | SpanToDictionary               |     4,541.3356 ns |     71.1674 ns |    66.5700 ns | 1.6937 | 0.1297 |   22192 B |
| ToHashSetBench                | SpanToHashSet                  |     4,055.0258 ns |     71.1628 ns |    69.8914 ns | 1.3580 | 0.0839 |   17768 B |
| ToListBench                   | SpanToList                     |       179.4493 ns |      3.6140 ns |     7.8566 ns | 0.3176 | 0.0048 |    4152 B |
| ToLookupBench                 | SpanToLookup                   |    24,572.7907 ns |    396.6613 ns |   371.0372 ns | 9.3994 | 2.3499 |  123056 B |
| TryGetNonEnumeratedCountBench | SpanTryGetNonEnumeratedCount   |         0.1267 ns |      0.0044 ns |     0.0041 ns |      - |      - |         - |
| UnionBench                    | SpanUnion                      |    14,385.2830 ns |     26.2765 ns |    20.5149 ns |      - |      - |         - |
| UnionByBench                  | SpanUnionBy                    |    16,276.4999 ns |    198.2176 ns |   175.7148 ns |      - |      - |         - |
| WhereBench                    | SpanWhere                      |     1,026.2970 ns |      8.0581 ns |     7.5375 ns |      - |      - |         - |
| ZipBench                      | SpanZip                        |     6,979.3469 ns |     23.1941 ns |    21.6958 ns |      - |      - |         - |
| AggregateBench                | SystemAggregate                |       701.8700 ns |     13.5480 ns |    16.1279 ns | 0.0019 |      - |      32 B |
| AggregateByBench              | SystemAggregateBy              |     3,483.4472 ns |     18.6170 ns |    16.5035 ns | 0.0267 |      - |     368 B |
| AllBench                      | SystemAll                      |       560.0166 ns |      2.1881 ns |     1.9397 ns | 0.0019 |      - |      32 B |
| AnyBench                      | SystemAny                      |       589.3681 ns |      6.4772 ns |     6.0588 ns | 0.0019 |      - |      32 B |
| AppendBench                   | SystemAppend                   |     1,633.3231 ns |     31.4620 ns |    30.8999 ns | 0.0057 |      - |      88 B |
| AsEnumerableBench             | SystemAsEnumerable             |       562.1725 ns |      3.1665 ns |     2.9619 ns | 0.0019 |      - |      32 B |
| AverageBench                  | SystemAverage                  |        91.8306 ns |      1.7956 ns |     1.4019 ns |      - |      - |         - |
| CastBench                     | SystemCast                     |    29,212.4442 ns |    144.3611 ns |   127.9724 ns | 1.8616 |      - |   24656 B |
| ChunkBench                    | SystemChunk                    |     1,050.8867 ns |     21.0018 ns |    47.4045 ns | 0.5074 |      - |    6632 B |
| ConcatBench                   | SystemConcat                   |     3,548.8239 ns |     58.4093 ns |    54.6361 ns | 0.0076 |      - |     120 B |
| ContainsBench                 | SystemContains                 |        59.9012 ns |      0.8079 ns |     0.6746 ns |      - |      - |         - |
| CountBench                    | SystemCount                    |         1.9449 ns |      0.0121 ns |     0.0113 ns |      - |      - |         - |
| CountBench                    | SystemCountPredicate           |       875.1317 ns |     11.3271 ns |    10.5953 ns | 0.0019 |      - |      32 B |
| CountByBench                  | SystemCountBy                  |     3,410.3470 ns |     38.3934 ns |    34.0347 ns | 0.0229 |      - |     344 B |
| DefaultIfEmptyBench           | SystemDefaultIfEmpty           |        12.3344 ns |      0.2382 ns |     0.2340 ns | 0.0037 |      - |      48 B |
| DistinctBench                 | SystemDistinct                 |    10,566.5647 ns |    158.8862 ns |   132.6772 ns | 4.4708 | 0.7324 |   58656 B |
| DistinctByBench               | SystemDistinctBy               |     4,091.9453 ns |     57.9900 ns |    51.4066 ns | 0.0229 |      - |     360 B |
| ElementAtBench                | SystemElementAt                |         8.8404 ns |      0.0743 ns |     0.0695 ns |      - |      - |         - |
| ElementAtOrDefaultBench       | SystemElementAtOrDefault       |        10.2277 ns |      0.1074 ns |     0.1005 ns |      - |      - |         - |
| ExceptBench                   | SystemExcept                   |     8,278.2029 ns |    116.4023 ns |   103.1876 ns | 1.3580 | 0.0763 |   17928 B |
| ExceptByBench                 | SystemExceptBy                 |     8,567.3891 ns |     94.7324 ns |    83.9778 ns | 1.3580 | 0.0763 |   17944 B |
| FirstBench                    | SystemFirst                    |       610.7371 ns |     11.0883 ns |    10.3720 ns | 0.0019 |      - |      32 B |
| FirstOrDefaultBench           | SystemFirstOrDefault           |       605.9664 ns |      6.9283 ns |     6.4808 ns | 0.0019 |      - |      32 B |
| GroupByBench                  | SystemGroupBy                  |     7,030.2276 ns |     92.1324 ns |    76.9348 ns | 2.1820 | 0.1221 |   28536 B |
| GroupJoinBench                | SystemGroupJoin                |    23,809.1370 ns |    408.3943 ns |   362.0309 ns | 9.3994 | 2.6550 |  123216 B |
| IndexBench                    | SystemIndex                    |     5,877.5114 ns |     17.3441 ns |    14.4831 ns |      - |      - |      96 B |
| IntersectBench                | SystemIntersect                |     9,521.2881 ns |     71.2410 ns |    66.6389 ns | 1.3580 | 0.0763 |   17928 B |
| IntersectByBench              | SystemIntersectBy              |     9,727.2948 ns |    134.0769 ns |   125.4156 ns | 1.3580 | 0.0763 |   17944 B |
| JoinBench                     | SystemJoin                     |    25,111.6767 ns |    413.1446 ns |   366.2419 ns | 9.4299 | 2.3499 |  123232 B |
| LastBench                     | SystemLast                     |     1,867.6312 ns |      5.0642 ns |     4.2288 ns |      - |      - |         - |
| LastOrDefaultBench            | SystemLastOrDefault            |     1,864.4722 ns |      5.9919 ns |     5.6048 ns |      - |      - |         - |
| LongCountBench                | SystemLongCount                |       292.6889 ns |      3.7504 ns |     3.5081 ns | 0.0024 |      - |      32 B |
| LongCountBench                | SystemLongCountPredicate       |       866.1913 ns |      4.4559 ns |     4.1681 ns | 0.0019 |      - |      32 B |
| MaxBench                      | SystemMax                      |        36.3290 ns |      0.7014 ns |     0.6889 ns |      - |      - |         - |
| MaxByBench                    | SystemMaxBy                    |       644.4816 ns |      5.6257 ns |     5.2623 ns | 0.0019 |      - |      32 B |
| MinBench                      | SystemMin                      |        36.2777 ns |      0.3507 ns |     0.3109 ns |      - |      - |         - |
| MinByBench                    | SystemMinBy                    |       598.3087 ns |      6.7526 ns |     6.3164 ns | 0.0019 |      - |      32 B |
| OfTypeBench                   | SystemOfType                   |       558.1400 ns |      2.1725 ns |     2.0322 ns | 0.0019 |      - |      32 B |
| OrderBench                    | SystemOrder                    |     3,908.1107 ns |     72.2211 ns |    70.9308 ns | 0.3128 |      - |    4176 B |
| OrderByBench                  | SystemOrderBy                  |     9,728.4551 ns |     45.0695 ns |    42.1581 ns | 0.9613 | 0.0153 |   12568 B |
| OrderByBench                  | SystemOrderByDescending        |    14,792.8101 ns |    143.5580 ns |   134.2843 ns | 0.9613 | 0.0153 |   12568 B |
| OrderBench                    | SystemOrderDescending          |     9,623.9661 ns |     46.5531 ns |    43.5458 ns | 0.3052 |      - |    4176 B |
| PrependBench                  | SystemPrepend                  |     1,633.7946 ns |     20.4386 ns |    19.1183 ns | 0.0057 |      - |      88 B |
| RangeBench                    | SystemRange                    |       469.3439 ns |      2.7540 ns |     2.5761 ns | 0.0029 |      - |      40 B |
| RepeatBench                   | SystemRepeat                   |       473.6578 ns |      1.4942 ns |     1.2477 ns | 0.0024 |      - |      32 B |
| ReverseBench                  | SystemReverse                  |       994.0624 ns |     10.2884 ns |     9.6238 ns | 0.3185 |      - |    4168 B |
| SelectBench                   | SystemSelect                   |       668.0574 ns |      2.4513 ns |     2.1730 ns | 0.0029 |      - |      48 B |
| SelectManyBench               | SystemSelectMany               | 1,499,215.6110 ns | 10,031.6551 ns | 8,892.8010 ns | 1.9531 |      - |   41057 B |
| SequenceEqualBench            | SystemSequenceEqual            |         1.9193 ns |      0.0110 ns |     0.0086 ns |      - |      - |         - |
| SequenceEqualBench            | SystemSequenceEqualSequence    |       554.8530 ns |      3.9535 ns |     3.6981 ns | 0.0057 |      - |      80 B |
| SingleBench                   | SystemSingle                   |       640.9832 ns |      7.5215 ns |     7.0356 ns | 0.0019 |      - |      32 B |
| SingleOrDefaultBench          | SystemSingleOrDefault          |       613.3660 ns |      8.3022 ns |     7.7659 ns | 0.0019 |      - |      32 B |
| SkipBench                     | SystemSkip                     |        18.2896 ns |      0.3369 ns |     0.3151 ns | 0.0037 |      - |      48 B |
| SkipLastBench                 | SystemSkipLast                 |        36.9188 ns |      0.4948 ns |     0.4629 ns | 0.0104 |      - |     136 B |
| SkipWhileBench                | SystemSkipWhile                |     1,052.2506 ns |      8.5918 ns |     8.0368 ns | 0.0076 |      - |     104 B |
| SumBench                      | SystemSum                      |        74.5351 ns |      0.2649 ns |     0.2212 ns |      - |      - |         - |
| TakeBench                     | SystemTake                     |     3,930.2133 ns |     14.8998 ns |    13.9373 ns |      - |      - |      48 B |
| TakeLastBench                 | SystemTakeLast                 |     6,265.3723 ns |     23.7613 ns |    22.2264 ns | 0.0076 |      - |     136 B |
| TakeWhileBench                | SystemTakeWhile                |     2,546.2089 ns |     18.7128 ns |    17.5040 ns | 0.0076 |      - |     104 B |
| ThenByBench                   | SystemThenBy                   |    18,688.0809 ns |    119.7349 ns |   112.0001 ns | 1.5869 | 0.0916 |   20928 B |
| ThenByBench                   | SystemThenByDescending         |    18,688.2876 ns |    130.0922 ns |   115.3233 ns | 1.5869 | 0.0916 |   20928 B |
| ToDictionaryBench             | SystemToDictionary             |     4,367.0843 ns |     75.9974 ns |    67.3697 ns | 1.6937 | 0.1297 |   22192 B |
| ToHashSetBench                | SystemToHashSet                |     4,777.7808 ns |     93.5584 ns |   128.0637 ns | 1.3580 | 0.0839 |   17800 B |
| ToListBench                   | SystemToList                   |       180.9148 ns |      3.6393 ns |     7.7555 ns | 0.3176 | 0.0048 |    4152 B |
| ToLookupBench                 | SystemToLookup                 |    19,771.0583 ns |    336.3901 ns |   552.6985 ns | 9.3994 | 2.3499 |  123040 B |
| TryGetNonEnumeratedCountBench | SystemTryGetNonEnumeratedCount |         3.0712 ns |      0.0103 ns |     0.0096 ns |      - |      - |         - |
| UnionBench                    | SystemUnion                    |    13,690.1597 ns |    134.3573 ns |   119.1042 ns | 4.4708 | 0.7324 |   58696 B |
| UnionByBench                  | SystemUnionBy                  |    14,831.5377 ns |    104.8527 ns |    98.0793 ns | 4.4708 | 0.7324 |   58736 B |
| WhereBench                    | SystemWhere                    |       939.1045 ns |      4.9587 ns |     4.1408 ns | 0.0029 |      - |      48 B |
| ZipBench                      | SystemZip                      |     6,015.0437 ns |     19.6605 ns |    17.4285 ns | 0.0076 |      - |     144 B |
