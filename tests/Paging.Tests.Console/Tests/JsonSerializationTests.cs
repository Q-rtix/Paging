using Paging.Extensions;
using Paging.PagedCollections;
using Paging.Pagers;

#if DOES_NOT_SUPPORT_JSON
using Newtonsoft.Json;
#else
using System.Text.Json;
#endif

namespace Paging.Tests.Console.Tests;

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
		System.Console.WriteLine("Native Json not supported");
		var json = JsonConvert.SerializeObject(paged);
#else
		System.Console.WriteLine("Native Json supported");
		var json = JsonSerializer.Serialize(paged);
#endif

		System.Console.WriteLine(json);

#if DOES_NOT_SUPPORT_JSON
		var fromJson = JsonConvert.DeserializeObject<PagedList<int>>(json);
#else
		var fromJson = JsonSerializer.Deserialize<PagedList<int>>(json);
#endif

		System.Console.WriteLine(fromJson!.PageCount);
		System.Console.WriteLine(fromJson.Count);
		System.Console.WriteLine(fromJson.PageNumber);
		System.Console.WriteLine(fromJson.IsEmpty);
		System.Console.WriteLine(fromJson.PageSize);
		System.Console.WriteLine(fromJson.HasNextPage);
		System.Console.WriteLine(fromJson.HasPreviousPage);
		System.Console.WriteLine(fromJson.IsFirstPage);
		System.Console.WriteLine(fromJson.IsLastPage);
		System.Console.WriteLine(fromJson.TotalItemCount);

		foreach (var item in fromJson)
		{
			System.Console.WriteLine(item);
		}
	}
}