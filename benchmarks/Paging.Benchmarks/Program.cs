using System.Text.Json;
using BenchmarkDotNet.Running;
using Paging.Benchmarks.Loops;
using Paging.Extensions;
using Paging.PagedCollections;
using Paging.Tests;

// BenchmarkRunner.Run<IntsBenchmark>();

var list = Lab.DataSources.IntegerLists.Items50;
var pager = Lab.DataSources.Pagers.PageNumberFirst;
var paged = list.Paginated(pager);

var json = JsonSerializer.Serialize(paged);

Console.WriteLine(JsonSerializer.Serialize(list));
Console.WriteLine(json);

var fromJson = JsonSerializer.Deserialize<PagedList<int>>(json);

Console.WriteLine(fromJson.PageCount);
Console.WriteLine(fromJson.Count);
Console.WriteLine(fromJson.PageNumber);
Console.WriteLine(fromJson.IsEmpty);
Console.WriteLine(fromJson.PageSize);
Console.WriteLine(fromJson.HasNextPage);
Console.WriteLine(fromJson.HasPreviousPage);
Console.WriteLine(fromJson.IsFirstPage);
Console.WriteLine(fromJson.IsLastPage);
Console.WriteLine(fromJson.TotalItemCount);

foreach (var item in fromJson)
{
	Console.WriteLine(item);
}