# Paging Library

![NuGet Version](https://img.shields.io/nuget/v/Qrtix.Paging)

- [Getting Started](#getting-started)
- [Using PagedList](#using-pagedlist)
- [Benchmark](#benchmark)
- [Contributing](#contributing)

This C# library provides functionality for implementing paged lists.

Consult the online [documentation](https://q-rtix.github.io/Paging/) for more details.

## Getting Started

Using the NuGet package manager console within Visual Studio run the following command:

```
Install-Package Qrtix.Paging
```

Or using the .NET Core CLI from a terminal window:

```
dotnet add package Qrtix.Paging
```

## Using PagedList

The `PagedList` class in the Qrtix.Paging library provides a convenient way to paginate large collections of data efficiently. Here's how you can use it:

### Instantiate a PagedList:

```csharp
// Assuming you have a list of items named 'sourceList' and a page size of 10
var pagedList = new PagedList<T>(sourceList, pageNumber, pageSize);
```

### Access Paginated Data:

You can access the data in the paged list using indexers or enumeration:

```csharp
// Accessing items using indexer
var item = pagedList[index];

// Enumerating through the paged list
foreach (var item in pagedList)
{
    // Process each item
}

// Using for loop
for (int i = 0; i < pagedList.Count; i++)
{
    var item = pagedList[i];
    // Process each item
}
```

### Retrieve Pagination Information:

You can also retrieve pagination-related information such as the total number of pages, total items, etc.:

```csharp
// Total number of items
var totalItems = pagedList.TotalItemCount;

// Total number of pages
var totalPages = pagedList.PageCount;

// Current page number
var currentPage = pagedList.PageNumber;

// Page size
var pageSize = pagedList.PageSize;
```

## Benchmark

This benchmark evaluates the performance of different looping mechanisms across two scenarios:

1. **Short Collection:** This scenario involves collections with a smaller number of items.
2. **Long Collection:** This scenario includes collections with a larger number of items.

Each scenario tests the following looping mechanisms:

- `While` Loop
- `Do While` Loop
- `For` Loop
- `ForEach` Loop
- LINQ Operations

### Collection Types:

For each looping mechanism, we tested against the following collection types:

- **Array:** An array of integers.
- **List:** A list of integers.
- **Queryable:** A queryable collection of integers.
- **Enumerable:** An enumerable collection of integers.
- **PagedList:** A paginated list of integers using **Qrtix.Paging**.

### Summary

	BenchmarkDotNet v0.13.11, Windows 11 (10.0.22631.3007/23H2/2023Update/SunValley3)
	Intel Core i7-6560U CPU 2.20GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
	.NET SDK 8.0.100
	[Host]     : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2
	DefaultJob : .NET 8.0.1 (8.0.123.58001), X64 RyuJIT AVX2


**Short Collection**

| Method                  | Mean               | Error           | StdDev          | Median             | Allocated |
|------------------------ |-------------------:|----------------:|----------------:|-------------------:|----------:|
| While_ArrayShort        |          7.6639 ns |       0.1519 ns |       0.4080 ns |          7.6199 ns |         - |
| While_ListShort         |          8.4653 ns |       0.2245 ns |       0.6550 ns |          8.1672 ns |         - |
| While_QueryShort        |  3,431,964.0625 ns |  45,744.4657 ns |  40,551.2773 ns |  3,430,451.5625 ns |  129692 B |
| While_EnumerableShort   |         73.1155 ns |       1.3762 ns |       1.0745 ns |         73.0276 ns |         - |
| While_PagedListShort    |          5.5109 ns |       0.1528 ns |       0.1430 ns |          5.5412 ns |         - |

| Method                  | Mean               | Error           | StdDev          | Median             | Allocated |
|------------------------ |-------------------:|----------------:|----------------:|-------------------:|----------:|
| DoWhile_ArrayShort      |          4.3652 ns |       0.0768 ns |       0.0719 ns |          4.3687 ns |         - |
| DoWhile_ListShort       |         11.3414 ns |       0.2526 ns |       0.2363 ns |         11.3171 ns |         - |
| DoWhile_QueryShort      |  3,277,667.6339 ns |  35,518.4877 ns |  31,486.2142 ns |  3,270,392.1875 ns |  123695 B |
| DoWhile_EnumerableShort |         66.0196 ns |       1.3358 ns |       1.1841 ns |         65.5695 ns |         - |
| DoWhile_PagedListShort  |          5.5464 ns |       0.2091 ns |       0.5933 ns |          5.2521 ns |         - |

| Method                  | Mean               | Error           | StdDev          | Median             | Allocated |
|------------------------ |-------------------:|----------------:|----------------:|-------------------:|----------:|
| For_ArrayShort          |          5.1097 ns |       0.1151 ns |       0.0961 ns |          5.0841 ns |         - |
| For_ListShort           |          7.5736 ns |       0.1151 ns |       0.1077 ns |          7.5537 ns |         - |
| For_QueryShort          |  3,459,728.4375 ns |  48,145.8848 ns |  45,035.6905 ns |  3,449,319.5312 ns |  129695 B |
| For_EnumerableShort     |         78.2072 ns |       1.4956 ns |       1.3990 ns |         77.7426 ns |         - |
| For_PagedListShort      |          5.2608 ns |       0.1488 ns |       0.1528 ns |          5.2277 ns |         - |

| Method                  | Mean               | Error           | StdDev          | Median             | Allocated |
|------------------------ |-------------------:|----------------:|----------------:|-------------------:|----------:|
| ForEach_ArrayShort      |          4.0271 ns |       0.0907 ns |       0.0848 ns |          4.0092 ns |         - |
| ForEach_ListShort       |          8.2977 ns |       0.2083 ns |       0.2708 ns |          8.2323 ns |         - |
| ForEach_QueryShort      |         39.6814 ns |       0.5177 ns |       0.4843 ns |         39.5451 ns |      40 B |
| ForEach_EnumerableShort |         34.2966 ns |       0.3514 ns |       0.3287 ns |         34.2952 ns |      32 B |
| ForEach_PagedListShort  |         21.7900 ns |       0.3200 ns |       0.3143 ns |         21.7952 ns |      32 B |

| Method                  | Mean               | Error           | StdDev          | Median             | Allocated |
|------------------------ |-------------------:|----------------:|----------------:|-------------------:|----------:|
| Linq_ArrayShort         |         30.8896 ns |       0.6668 ns |       0.6237 ns |         31.0211 ns |      48 B |
| Linq_ListShort          |         33.7396 ns |       0.6790 ns |       0.6351 ns |         33.8632 ns |      72 B |
| Linq_QueryShort         |      1,348.1288 ns |      18.9453 ns |      21.0577 ns |      1,342.7159 ns |     744 B |
| Linq_EnumerableShort    |         33.2310 ns |       0.6789 ns |       0.6351 ns |         33.3771 ns |      56 B |
| Linq_PagedListShort     |          0.0278 ns |       0.0370 ns |       0.0346 ns |          0.0046 ns |         - |


**Long Collection**

| Method                  | Mean               | Error           | StdDev          | Median             | Allocated |
|------------------------ |-------------------:|----------------:|----------------:|-------------------:|----------:|
| While_ArrayLong         |         56.2922 ns |       0.4045 ns |       0.3586 ns |         56.2651 ns |         - |
| While_ListLong          |         81.7122 ns |       1.0123 ns |       0.9469 ns |         81.7052 ns |         - |
| While_QueryLong         | 22,869,968.3036 ns | 207,503.6075 ns | 183,946.5432 ns | 22,858,203.1250 ns | 1251498 B |
| While_EnumerableLong    |        912.5066 ns |      13.0414 ns |      12.1989 ns |        910.0410 ns |         - |
| While_PagedListLong     |         66.1971 ns |       1.1316 ns |       1.0031 ns |         66.0343 ns |         - |

| Method                  | Mean               | Error           | StdDev          | Median             | Allocated |
|------------------------ |-------------------:|----------------:|----------------:|-------------------:|----------:|
| DoWhile_ArrayLong       |         57.2344 ns |       1.0759 ns |       1.4363 ns |         57.1936 ns |         - |
| DoWhile_ListLong        |        120.3313 ns |       2.4316 ns |       3.4873 ns |        119.1208 ns |         - |
| DoWhile_QueryLong       | 22,660,970.4327 ns | 238,217.8882 ns | 198,922.7256 ns | 22,667,150.0000 ns | 1245457 B |
| DoWhile_EnumerableLong  |        860.3039 ns |      13.9846 ns |      13.0812 ns |        856.9570 ns |         - |
| DoWhile_PagedListLong   |         65.1459 ns |       0.6407 ns |       0.5350 ns |         65.1131 ns |         - |

| Method                  | Mean               | Error           | StdDev          | Median             | Allocated |
|------------------------ |-------------------:|----------------:|----------------:|-------------------:|----------:|
| For_ArrayLong           |         56.9101 ns |       0.9059 ns |       1.7882 ns |         56.2549 ns |         - |
| For_ListLong            |         81.8885 ns |       0.9291 ns |       0.8690 ns |         82.0507 ns |         - |
| For_QueryLong           | 22,776,829.4271 ns | 255,467.1461 ns | 199,451.9438 ns | 22,809,110.9375 ns | 1251498 B |
| For_EnumerableLong      |        861.3526 ns |      11.2557 ns |       9.9779 ns |        860.9481 ns |         - |
| For_PagedListLong       |         63.6049 ns |       0.6723 ns |       0.6289 ns |         63.5547 ns |         - |

| Method                  | Mean               | Error           | StdDev          | Median             | Allocated |
|------------------------ |-------------------:|----------------:|----------------:|-------------------:|----------:|
| ForEach_ArrayLong       |         47.0325 ns |       0.6834 ns |       0.6393 ns |         47.0002 ns |         - |
| ForEach_ListLong        |         84.5413 ns |       0.9743 ns |       0.8637 ns |         84.4462 ns |         - |
| ForEach_QueryLong       |        187.4379 ns |       1.6932 ns |       1.5838 ns |        187.5235 ns |      40 B |
| ForEach_EnumerableLong  |        242.0037 ns |       3.2134 ns |       3.0058 ns |        240.6808 ns |      40 B |
| ForEach_PagedListLong   |         12.5111 ns |       0.2759 ns |       0.3177 ns |         12.4391 ns |      32 B |

| Method                  | Mean               | Error           | StdDev          | Median             | Allocated |
|------------------------ |-------------------:|----------------:|----------------:|-------------------:|----------:|
| Linq_ArrayLong          |         31.6275 ns |       0.6781 ns |       0.6660 ns |         31.7416 ns |      48 B |
| Linq_ListLong           |         29.8407 ns |       0.6393 ns |       0.6840 ns |         29.8014 ns |      72 B |
| Linq_QueryLong          |      1,370.2819 ns |      27.2387 ns |      46.9855 ns |      1,357.7888 ns |     744 B |
| Linq_EnumerableLong     |         28.5803 ns |       0.5914 ns |       0.5532 ns |         28.4244 ns |      48 B |
| Linq_PagedListLong      |          0.0222 ns |       0.0273 ns |       0.0303 ns |          0.0096 ns |         - |



## Contributing

If you would like to get involved with this project, please first read the [Contribution Guidelines](docs/docs/contributiing.md)