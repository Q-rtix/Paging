using Paging.Extensions;
using Paging.PagedCollections;
using Paging.Pagers;

#if DOES_NOT_SUPPORT_JSON
using Newtonsoft.Json;
#else
using System.Text.Json;
#endif

namespace Paging.ConsoleTests.Tests;

public static class JsonSerializationTests
{
	public static void Test()
	{
		var list = new List<int> {
			1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24,
			25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50
		};
		var pager = new Pager(1, 10, 50);
		var paged = list.Paginated(pager);

#if DOES_NOT_SUPPORT_JSON
		var json = JsonConvert.SerializeObject(paged);
#else
		var json = JsonSerializer.Serialize(paged);
#endif

		Console.WriteLine(json);

#if DOES_NOT_SUPPORT_JSON
		var fromJson = JsonConvert.DeserializeObject<PagedList<int>>(json);
#else
		var fromJson = JsonSerializer.Deserialize<PagedList<int>>(json);
#endif

		Console.WriteLine(fromJson!.PageCount);
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
	}
}