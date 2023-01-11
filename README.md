# OmniBOR.NET

[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/JamieMagee/omnibor-dotnet/build.yml?branch=main&style=for-the-badge)](https://github.com/JamieMagee/omnibor-dotnet/actions/workflows/build.yml?query=branch%3Amain)
[![MIT License](https://img.shields.io/github/license/JamieMagee/omnibor-dotnet?style=for-the-badge)](https://github.com/JamieMagee/omnibor-dotnet/blob/main/LICENSE.md)
![Stability Experimental](https://img.shields.io/badge/stability-experimental-orange.svg?style=for-the-badge)

An experimental implementation of [OmniBOR][1] in .NET. Inspired by [gitbom-rs][2] and [gitbom-go][3].

## Usage

1. `dotnet add package OmniBOR.GitOid`

2. Create a `GitOid` instance using static methods on the `GitOid` class:

```csharp
var bytes = "hello world"u8.ToArray();
var gitOid1 = GitOid.CreateFromBytes(HashAlgorithm.Sha1, ObjectType.Blob, DataBytes)
var stream = new MemoryStream(bytes);
var gitOid2 = GitOid.CreateFromBytesAsync(HashAlgorithm.Sha256, ObjectType.Blob, stream)
```

## Benchmarks

```
BenchmarkDotNet=v0.13.3, OS=ubuntu 22.04
Intel Xeon Platinum 8171M CPU 2.60GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=7.0.101
  [Host]     : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2


|                     Method |     Mean |     Error |    StdDev |   Gen0 | Allocated |
|--------------------------- |---------:|----------:|----------:|-------:|----------:|
|        Sha1GitOidFromBytes | 2.527 us | 0.0129 us | 0.0120 us | 0.0420 |     824 B |
|   Sha1GitOidFromBytesAsync | 3.033 us | 0.0154 us | 0.0144 us | 0.0648 |    1224 B |
|      Sha256GitOidFromBytes | 2.723 us | 0.0112 us | 0.0099 us | 0.0496 |     992 B |
| Sha256GitOidFromBytesAsync | 3.146 us | 0.0209 us | 0.0196 us | 0.0725 |    1392 B |
```

## License

All packages in this repository are licensed under [the MIT license](https://opensource.org/licenses/MIT).

[1]: https://omnibor.io
[2]: https://github.com/omnibor/gitbom-rs
[3]: https://github.com/fkautz/gitbom-go
