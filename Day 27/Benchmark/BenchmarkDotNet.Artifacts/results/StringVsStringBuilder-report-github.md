```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.204
  [Host]     : .NET 8.0.4 (8.0.424.16909), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.4 (8.0.424.16909), Arm64 RyuJIT AdvSIMD


```
| Method          | iterationNumber | Mean          | Error      | StdDev     | Gen0     | Gen1   | Allocated |
|---------------- |---------------- |--------------:|-----------:|-----------:|---------:|-------:|----------:|
| **MyString**        | **10**              |      **75.61 ns** |   **0.373 ns** |   **0.331 ns** |   **0.0535** |      **-** |     **336 B** |
| MyStringBuilder | 10              |      38.14 ns |   0.034 ns |   0.027 ns |   0.0242 |      - |     152 B |
| **MyString**        | **100**             |   **1,748.22 ns** |  **11.228 ns** |   **9.376 ns** |   **3.3245** |      **-** |   **20856 B** |
| MyStringBuilder | 100             |     397.57 ns |   1.600 ns |   1.418 ns |   0.2036 |      - |    1280 B |
| **MyString**        | **1000**            | **156,815.54 ns** | **380.455 ns** | **297.035 ns** | **452.6367** |      **-** | **2840456 B** |
| MyStringBuilder | 1000            |   3,737.03 ns |  12.503 ns |  11.084 ns |   2.3460 | 0.0153 |   14712 B |
