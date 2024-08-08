```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3880/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700F, 1 CPU, 20 logical and 12 physical cores
.NET SDK 9.0.100-preview.6.24328.19
  [Host]     : .NET 9.0.0 (9.0.24.32707), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.32707), X64 RyuJIT AVX2


```
| Type                          | Method                         | Mean              | Error          | StdDev         | Gen0   | Gen1   | Allocated |
|------------------------------ |------------------------------- |------------------:|---------------:|---------------:|-------:|-------:|----------:|
| ChunkBench                    | HandcraftedChunk               |       986.5243 ns |     15.5550 ns |     15.2770 ns | 0.5684 | 0.0019 |    7440 B |
| ContainsBench                 | HandcraftedContains            |        56.5976 ns |      0.8941 ns |      0.7926 ns |      - |      - |         - |
| RangeBench                    | HandcraftedRange               |       387.3552 ns |      5.8060 ns |      5.4310 ns | 0.3152 |      - |    4120 B |
| ReverseBench                  | HandcraftedReverse             |       522.8223 ns |     10.4429 ns |     17.7328 ns | 0.3147 |      - |    4120 B |
| ShuffleBench                  | HandcraftedShuffle             |     2,311.1016 ns |     18.1437 ns |     16.9716 ns |      - |      - |         - |
| WhereBench                    | HandcraftedWhere               |       399.2979 ns |      6.2727 ns |      5.8674 ns | 0.1583 |      - |    2072 B |
| AggregateBench                | SpanAggregate                  |       699.9725 ns |      4.8966 ns |      4.5802 ns |      - |      - |         - |
| AggregateByBench              | SpanAggregateBy                |     6,949.9902 ns |     42.9620 ns |     40.1867 ns |      - |      - |         - |
| AllBench                      | SpanAll                        |       613.9293 ns |      4.9212 ns |      4.6033 ns |      - |      - |         - |
| AnyBench                      | SpanAny                        |       614.8451 ns |      4.0036 ns |      3.7450 ns |      - |      - |         - |
| AppendBench                   | SpanAppend                     |       579.9351 ns |      2.6914 ns |      2.5175 ns |      - |      - |         - |
| AsEnumerableBench             | SpanAsEnumerable               |     1,547.8661 ns |     16.9491 ns |     15.8542 ns | 0.0019 |      - |      32 B |
| AverageBench                  | SpanAverage                    |       781.6399 ns |      4.3406 ns |      3.6246 ns |      - |      - |         - |
| CastBench                     | SpanCastClass                  |     1,617.6309 ns |     11.6509 ns |     10.3282 ns |      - |      - |         - |
| CastBench                     | SpanCastIntToNullableInt       |     1,172.4753 ns |      8.3516 ns |      7.8121 ns |      - |      - |         - |
| CastBench                     | SpanCastIntToObject            |     3,685.6677 ns |     64.3408 ns |     53.7275 ns | 1.8768 |      - |   24576 B |
| ChunkBench                    | SpanChunk                      |     1,384.7554 ns |     23.3000 ns |     20.6548 ns | 0.5074 |      - |    6632 B |
| ConcatBench                   | SpanConcat                     |     7,156.9479 ns |     55.5181 ns |     51.9317 ns |      - |      - |         - |
| ContainsBench                 | SpanContains                   |        56.9308 ns |      0.3818 ns |      0.3188 ns |      - |      - |         - |
| CountBench                    | SpanCount                      |         1.0479 ns |      0.0084 ns |      0.0078 ns |      - |      - |         - |
| CountBench                    | SpanCountPredicate             |       939.3974 ns |      9.0973 ns |      8.5096 ns |      - |      - |         - |
| CountByBench                  | SpanCountBy                    |     6,753.1801 ns |     80.0971 ns |     71.0040 ns |      - |      - |         - |
| DefaultIfEmptyBench           | SpanDefaultIfEmpty             |         2.5316 ns |      0.0758 ns |      0.1423 ns |      - |      - |         - |
| DistinctBench                 | SpanDistinct                   |     5,361.6230 ns |     48.2835 ns |     45.1645 ns |      - |      - |         - |
| DistinctByBench               | SpanDistinctBy                 |     3,968.5797 ns |     32.9306 ns |     29.1921 ns |      - |      - |         - |
| ElementAtBench                | SpanElementAt                  |         6.5507 ns |      0.0501 ns |      0.0468 ns |      - |      - |         - |
| ElementAtOrDefaultBench       | SpanElementAtOrDefault         |         6.5041 ns |      0.0543 ns |      0.0508 ns |      - |      - |         - |
| ExceptBench                   | SpanExcept                     |    10,634.8728 ns |     73.6055 ns |     68.8506 ns |      - |      - |         - |
| ExceptByBench                 | SpanExceptBy                   |    11,505.7641 ns |    131.7169 ns |    123.2081 ns |      - |      - |         - |
| FirstBench                    | SpanFirst                      |       638.8438 ns |      7.6003 ns |      7.1093 ns |      - |      - |         - |
| FirstOrDefaultBench           | SpanFirstOrDefault             |       625.2525 ns |      4.2528 ns |      3.7700 ns |      - |      - |         - |
| ForEachBench                  | SpanForEach                    |       344.8276 ns |      2.5698 ns |      2.4038 ns |      - |      - |         - |
| GroupByBench                  | SpanGroupBy                    |     8,198.6877 ns |     58.1351 ns |     48.5455 ns | 0.5798 |      - |    7680 B |
| GroupJoinBench                | SpanGroupJoin                  |   428,989.0202 ns |  3,249.5174 ns |  3,039.6006 ns |      - |      - |       1 B |
| IndexBench                    | SpanIndex                      |     1,164.9994 ns |      9.8407 ns |      8.7236 ns |      - |      - |         - |
| IntersectBench                | SpanIntersect                  |    14,047.3296 ns |    112.5371 ns |    105.2673 ns |      - |      - |         - |
| IntersectByBench              | SpanIntersectBy                |    14,166.2002 ns |    112.4214 ns |    105.1590 ns |      - |      - |         - |
| JoinBench                     | SpanJoin                       |   414,373.3008 ns |  2,513.6207 ns |  2,351.2424 ns |      - |      - |       1 B |
| LastBench                     | SpanLast                       |       671.2693 ns |      5.7405 ns |      5.3697 ns |      - |      - |         - |
| LastOrDefaultBench            | SpanLastOrDefault              |       645.2881 ns |      4.7217 ns |      4.4167 ns |      - |      - |         - |
| LongCountBench                | SpanLongCount                  |         1.2512 ns |      0.0135 ns |      0.0126 ns |      - |      - |         - |
| LongCountBench                | SpanLongCountPredicate         |       941.5909 ns |      7.0302 ns |      6.5760 ns |      - |      - |         - |
| MaxBench                      | SpanMax                        |       846.6641 ns |     15.7914 ns |     14.7713 ns |      - |      - |         - |
| MaxByBench                    | SpanMaxBy                      |     1,049.5046 ns |      7.6778 ns |      6.8061 ns |      - |      - |         - |
| MinBench                      | SpanMin                        |       814.8437 ns |      6.5566 ns |      6.1330 ns |      - |      - |         - |
| MinByBench                    | SpanMinBy                      |     1,047.9569 ns |      8.1287 ns |      7.6036 ns |      - |      - |         - |
| OfTypeBench                   | SpanOfTypeClass                |     1,823.1427 ns |     11.0783 ns |     10.3626 ns |      - |      - |         - |
| OfTypeBench                   | SpanOfTypeIntToNullableInt     |     1,173.4731 ns |     14.0145 ns |     13.1092 ns |      - |      - |         - |
| OfTypeBench                   | SpanOfTypeIntToObject          |     3,966.8917 ns |     79.2714 ns |     81.4059 ns | 1.8768 |      - |   24576 B |
| OrderBench                    | SpanOrder                      |    34,639.1455 ns |    444.1361 ns |    415.4452 ns |      - |      - |         - |
| OrderByBench                  | SpanOrderBy                    |    33,165.3229 ns |    278.5131 ns |    246.8946 ns |      - |      - |         - |
| OrderByBench                  | SpanOrderByDescending          |    35,560.9155 ns |    388.4832 ns |    363.3875 ns |      - |      - |         - |
| OrderBench                    | SpanOrderDescending            |    35,801.8372 ns |    500.8818 ns |    468.5252 ns |      - |      - |         - |
| PrependBench                  | SpanPrepend                    |       585.2983 ns |      4.1572 ns |      3.8886 ns |      - |      - |         - |
| RangeBench                    | SpanRange                      |       280.6029 ns |      2.2890 ns |      2.1412 ns |      - |      - |         - |
| RepeatBench                   | SpanRepeat                     |       239.7012 ns |      2.3441 ns |      2.1927 ns |      - |      - |         - |
| ReverseBench                  | SpanReverse                    |     1,722.1767 ns |     11.1855 ns |     10.4629 ns |      - |      - |         - |
| SelectBench                   | SpanSelect                     |       701.1561 ns |      3.9226 ns |      3.6692 ns |      - |      - |         - |
| SelectManyBench               | SpanSelectMany                 | 3,786,232.4219 ns | 23,804.4766 ns | 21,102.0485 ns |      - |      - |       2 B |
| SequenceEqualBench            | SpanSequenceEqual              |         2.1705 ns |      0.0168 ns |      0.0157 ns |      - |      - |         - |
| SequenceEqualBench            | SpanSequenceEqualSequence      |       585.6679 ns |      4.5469 ns |      4.2532 ns |      - |      - |         - |
| ShuffleBench                  | SpanShuffle                    |     5,408.0329 ns |     67.0890 ns |     62.7551 ns |      - |      - |         - |
| SingleBench                   | SpanSingle                     |       622.9921 ns |      5.7304 ns |      5.3603 ns |      - |      - |         - |
| SingleOrDefaultBench          | SpanSingleOrDefault            |       622.9509 ns |      2.8049 ns |      2.4865 ns |      - |      - |         - |
| SkipBench                     | SpanSkip                       |         5.0549 ns |      0.0416 ns |      0.0389 ns |      - |      - |         - |
| SkipLastBench                 | SpanSkipLast                   |         4.4670 ns |      0.0331 ns |      0.0310 ns |      - |      - |         - |
| SkipWhileBench                | SpanSkipWhile                  |     1,276.2734 ns |     13.7680 ns |     12.2050 ns |      - |      - |         - |
| SumBench                      | SpanSum                        |       695.4087 ns |      5.4876 ns |      4.8646 ns |      - |      - |         - |
| TakeBench                     | SpanTake                       |       575.9687 ns |      5.6646 ns |      5.2987 ns |      - |      - |         - |
| TakeLastBench                 | SpanTakeLast                   |     1,285.5743 ns |      8.4032 ns |      7.0170 ns |      - |      - |         - |
| TakeWhileBench                | SpanTakeWhile                  |     2,301.9845 ns |     12.0380 ns |     11.2603 ns |      - |      - |         - |
| ThenByBench                   | SpanThenBy                     |    55,888.7107 ns |    565.0072 ns |    500.8642 ns |      - |      - |         - |
| ThenByBench                   | SpanThenByDescending           |    57,577.2957 ns |    470.9633 ns |    440.5393 ns |      - |      - |         - |
| ToArrayBench                  | SpanToArray                    |       645.4271 ns |      7.5430 ns |      6.6867 ns | 0.3147 |      - |    4120 B |
| ToDictionaryBench             | SpanToDictionary               |     4,367.7570 ns |     85.2039 ns |     79.6997 ns | 1.6937 | 0.1297 |   22192 B |
| ToHashSetBench                | SpanToHashSet                  |     3,816.6974 ns |     70.8218 ns |     89.5670 ns | 1.3580 | 0.0839 |   17768 B |
| ToListBench                   | SpanToList                     |       168.8875 ns |      3.3910 ns |      3.4823 ns | 0.3176 | 0.0048 |    4152 B |
| ToLookupBench                 | SpanToLookup                   |    23,782.2921 ns |    301.5729 ns |    282.0915 ns | 9.3994 | 2.3499 |  123056 B |
| TryGetNonEnumeratedCountBench | SpanTryGetNonEnumeratedCount   |         0.1155 ns |      0.0073 ns |      0.0068 ns |      - |      - |         - |
| UnionBench                    | SpanUnion                      |    14,359.6325 ns |    138.8879 ns |    129.9158 ns |      - |      - |         - |
| UnionByBench                  | SpanUnionBy                    |    16,102.5240 ns |    223.6342 ns |    209.1875 ns |      - |      - |         - |
| WhereBench                    | SpanWhere                      |     1,012.4576 ns |      7.0452 ns |      5.8831 ns |      - |      - |         - |
| ZipBench                      | SpanZip                        |     6,700.5346 ns |     26.4357 ns |     24.7280 ns |      - |      - |         - |
| AggregateBench                | SystemAggregate                |       679.6662 ns |      8.0317 ns |      7.5129 ns | 0.0019 |      - |      32 B |
| AggregateByBench              | SystemAggregateBy              |     3,455.6540 ns |     30.6001 ns |     28.6233 ns | 0.0267 |      - |     368 B |
| AllBench                      | SystemAll                      |       554.9420 ns |      4.1498 ns |      3.6787 ns | 0.0019 |      - |      32 B |
| AnyBench                      | SystemAny                      |       583.8789 ns |     11.1741 ns |     10.4523 ns | 0.0019 |      - |      32 B |
| AppendBench                   | SystemAppend                   |     1,552.1068 ns |     30.7831 ns |     49.7090 ns | 0.0057 |      - |      88 B |
| AsEnumerableBench             | SystemAsEnumerable             |       554.7127 ns |      4.8911 ns |      4.5751 ns | 0.0019 |      - |      32 B |
| AverageBench                  | SystemAverage                  |        90.8496 ns |      1.7859 ns |      2.6177 ns |      - |      - |         - |
| CastBench                     | SystemCastClass                |     3,107.5920 ns |     40.6270 ns |     38.0026 ns |      - |      - |      32 B |
| CastBench                     | SystemCastIntToNullableInt     |    29,388.5033 ns |    233.7918 ns |    195.2268 ns | 1.8616 |      - |   24656 B |
| CastBench                     | SystemCastIntToObject          |    23,789.3106 ns |    213.1768 ns |    188.9757 ns | 1.8616 |      - |   24656 B |
| ChunkBench                    | SystemChunk                    |       961.6432 ns |     14.3118 ns |     12.6870 ns | 0.5074 |      - |    6632 B |
| ConcatBench                   | SystemConcat                   |     3,763.3965 ns |     46.3459 ns |     41.0844 ns | 0.0076 |      - |     120 B |
| ContainsBench                 | SystemContains                 |        59.1865 ns |      0.4965 ns |      0.4146 ns |      - |      - |         - |
| CountBench                    | SystemCount                    |         1.9249 ns |      0.0081 ns |      0.0068 ns |      - |      - |         - |
| CountBench                    | SystemCountPredicate           |       868.2571 ns |      5.6509 ns |      5.2858 ns | 0.0019 |      - |      32 B |
| CountByBench                  | SystemCountBy                  |     3,387.4643 ns |     24.1797 ns |     22.6177 ns | 0.0229 |      - |     344 B |
| DefaultIfEmptyBench           | SystemDefaultIfEmpty           |        11.9180 ns |      0.1201 ns |      0.1124 ns | 0.0037 |      - |      48 B |
| DistinctBench                 | SystemDistinct                 |    10,127.4966 ns |    200.7095 ns |    223.0881 ns | 4.4708 | 0.7324 |   58656 B |
| DistinctByBench               | SystemDistinctBy               |     4,083.9037 ns |     81.4679 ns |     83.6615 ns | 0.0229 |      - |     360 B |
| ElementAtBench                | SystemElementAt                |         9.3155 ns |      0.1000 ns |      0.0887 ns |      - |      - |         - |
| ElementAtOrDefaultBench       | SystemElementAtOrDefault       |        10.1430 ns |      0.0693 ns |      0.0614 ns |      - |      - |         - |
| ExceptBench                   | SystemExcept                   |     8,199.0748 ns |     81.3676 ns |     76.1113 ns | 1.3580 | 0.0763 |   17928 B |
| ExceptByBench                 | SystemExceptBy                 |     8,640.9007 ns |    159.3129 ns |    156.4665 ns | 1.3580 | 0.0763 |   17944 B |
| FirstBench                    | SystemFirst                    |       614.2405 ns |     12.1156 ns |     16.1739 ns | 0.0019 |      - |      32 B |
| FirstOrDefaultBench           | SystemFirstOrDefault           |       561.8169 ns |      2.9591 ns |      2.7679 ns | 0.0019 |      - |      32 B |
| GroupByBench                  | SystemGroupBy                  |     6,950.4102 ns |     64.4758 ns |     60.3107 ns | 2.1820 | 0.1221 |   28536 B |
| GroupJoinBench                | SystemGroupJoin                |    23,792.0848 ns |    398.9194 ns |    353.6317 ns | 9.3994 | 2.6550 |  123216 B |
| IndexBench                    | SystemIndex                    |     5,894.1272 ns |     25.4573 ns |     23.8127 ns |      - |      - |      96 B |
| IntersectBench                | SystemIntersect                |     9,521.9116 ns |    123.3897 ns |    115.4188 ns | 1.3580 | 0.0763 |   17928 B |
| IntersectByBench              | SystemIntersectBy              |     9,723.0809 ns |    142.2311 ns |    133.0431 ns | 1.3580 | 0.0763 |   17944 B |
| JoinBench                     | SystemJoin                     |    25,081.2330 ns |    263.8295 ns |    233.8780 ns | 9.4299 | 2.3499 |  123232 B |
| LastBench                     | SystemLast                     |     1,848.1264 ns |      8.0079 ns |      7.4906 ns |      - |      - |         - |
| LastOrDefaultBench            | SystemLastOrDefault            |     1,856.7330 ns |      2.0463 ns |      1.8140 ns |      - |      - |         - |
| LongCountBench                | SystemLongCount                |       291.7269 ns |      4.0987 ns |      3.8339 ns | 0.0024 |      - |      32 B |
| LongCountBench                | SystemLongCountPredicate       |       868.4924 ns |      6.6687 ns |      6.2379 ns | 0.0019 |      - |      32 B |
| MaxBench                      | SystemMax                      |        36.2078 ns |      0.6191 ns |      0.5791 ns |      - |      - |         - |
| MaxByBench                    | SystemMaxBy                    |       637.4495 ns |      6.0458 ns |      5.3594 ns | 0.0019 |      - |      32 B |
| MinBench                      | SystemMin                      |        36.0806 ns |      0.3305 ns |      0.2930 ns |      - |      - |         - |
| MinByBench                    | SystemMinBy                    |       594.7256 ns |      3.5955 ns |      3.3632 ns | 0.0019 |      - |      32 B |
| OfTypeBench                   | SystemOfTypeClass              |     5,332.9217 ns |     56.3115 ns |     49.9186 ns |      - |      - |      80 B |
| OfTypeBench                   | SystemOfTypeIntToNullableInt   |    28,260.5078 ns |    406.9000 ns |    380.6145 ns | 1.8616 |      - |   24656 B |
| OfTypeBench                   | SystemOfTypeIntToObject        |    24,565.1893 ns |    130.9275 ns |    116.0638 ns | 1.8616 |      - |   24656 B |
| OrderBench                    | SystemOrder                    |     3,674.4110 ns |     70.0256 ns |     68.7745 ns | 0.3166 |      - |    4176 B |
| OrderByBench                  | SystemOrderBy                  |     9,631.3508 ns |    102.1563 ns |     90.5589 ns | 0.9613 | 0.0153 |   12568 B |
| OrderByBench                  | SystemOrderByDescending        |    14,631.4315 ns |    114.3443 ns |    106.9577 ns | 0.9613 | 0.0153 |   12568 B |
| OrderBench                    | SystemOrderDescending          |     9,708.2527 ns |     67.5129 ns |     63.1516 ns | 0.3052 |      - |    4176 B |
| PrependBench                  | SystemPrepend                  |     1,489.6824 ns |     22.0070 ns |     21.6138 ns | 0.0057 |      - |      88 B |
| RangeBench                    | SystemRange                    |       464.1210 ns |      3.6208 ns |      3.2097 ns | 0.0029 |      - |      40 B |
| RepeatBench                   | SystemRepeat                   |       470.6885 ns |      2.7867 ns |      2.6066 ns | 0.0024 |      - |      32 B |
| ReverseBench                  | SystemReverse                  |     1,011.1956 ns |     20.1423 ns |     37.3351 ns | 0.3185 |      - |    4168 B |
| SelectBench                   | SystemSelect                   |       663.8566 ns |      3.8969 ns |      3.4545 ns | 0.0029 |      - |      48 B |
| SelectManyBench               | SystemSelectMany               | 1,636,864.6354 ns | 29,829.2695 ns | 27,902.3172 ns | 1.9531 |      - |   41057 B |
| SequenceEqualBench            | SystemSequenceEqual            |         1.8489 ns |      0.0273 ns |      0.0255 ns |      - |      - |         - |
| SequenceEqualBench            | SystemSequenceEqualSequence    |       549.0433 ns |      6.0798 ns |      5.3896 ns | 0.0057 |      - |      80 B |
| SingleBench                   | SystemSingle                   |       616.7725 ns |     11.2903 ns |     10.0085 ns | 0.0019 |      - |      32 B |
| SingleOrDefaultBench          | SystemSingleOrDefault          |       608.9364 ns |     10.2468 ns |      8.5565 ns | 0.0019 |      - |      32 B |
| SkipBench                     | SystemSkip                     |        17.4140 ns |      0.2070 ns |      0.1835 ns | 0.0037 |      - |      48 B |
| SkipLastBench                 | SystemSkipLast                 |        36.4592 ns |      0.3278 ns |      0.3066 ns | 0.0104 |      - |     136 B |
| SkipWhileBench                | SystemSkipWhile                |     1,033.2072 ns |      6.7684 ns |      6.3311 ns | 0.0076 |      - |     104 B |
| SumBench                      | SystemSum                      |        72.6670 ns |      0.4433 ns |      0.3930 ns |      - |      - |         - |
| TakeBench                     | SystemTake                     |     4,131.2056 ns |     16.9948 ns |     15.8970 ns |      - |      - |      48 B |
| TakeLastBench                 | SystemTakeLast                 |     5,963.2710 ns |     26.1940 ns |     24.5018 ns | 0.0076 |      - |     136 B |
| TakeWhileBench                | SystemTakeWhile                |     2,528.6637 ns |     24.5450 ns |     22.9594 ns | 0.0076 |      - |     104 B |
| ThenByBench                   | SystemThenBy                   |    18,489.5338 ns |    146.6620 ns |    130.0120 ns | 1.5869 | 0.0916 |   20928 B |
| ThenByBench                   | SystemThenByDescending         |    18,479.7923 ns |    114.0276 ns |    101.0825 ns | 1.5869 | 0.0916 |   20928 B |
| ToArrayBench                  | SystemToArray                  |       212.9494 ns |      4.2501 ns |      4.3645 ns | 0.3183 |      - |    4160 B |
| ToDictionaryBench             | SystemToDictionary             |     4,181.7262 ns |     72.0388 ns |     63.8605 ns | 1.6937 | 0.1297 |   22192 B |
| ToHashSetBench                | SystemToHashSet                |     4,549.8736 ns |     88.4042 ns |    105.2389 ns | 1.3580 | 0.0839 |   17800 B |
| ToListBench                   | SystemToList                   |       171.1692 ns |      3.4377 ns |      4.9303 ns | 0.3176 | 0.0048 |    4152 B |
| ToLookupBench                 | SystemToLookup                 |    18,906.6038 ns |    335.9899 ns |    297.8463 ns | 9.3994 | 2.3499 |  123040 B |
| TryGetNonEnumeratedCountBench | SystemTryGetNonEnumeratedCount |         3.0428 ns |      0.0205 ns |      0.0191 ns |      - |      - |         - |
| UnionBench                    | SystemUnion                    |    13,143.7314 ns |    112.2133 ns |    104.9644 ns | 4.4708 | 0.7324 |   58696 B |
| UnionByBench                  | SystemUnionBy                  |    14,389.3748 ns |    186.6081 ns |    174.5533 ns | 4.4708 | 0.7324 |   58736 B |
| WhereBench                    | SystemWhere                    |       933.3097 ns |      7.2146 ns |      6.7485 ns | 0.0029 |      - |      48 B |
| ZipBench                      | SystemZip                      |     5,984.7669 ns |     35.3700 ns |     33.0851 ns | 0.0076 |      - |     144 B |
