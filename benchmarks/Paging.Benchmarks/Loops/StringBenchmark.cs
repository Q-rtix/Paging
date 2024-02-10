using BenchmarkDotNet.Attributes;
using Paging.Extensions;
using Paging.PagedCollections;
using Paging.Tests.UnitTests;

namespace Paging.Benchmarks.Loops;

[MemoryDiagnoser(false)]
public class StringBenchmark
{
	#region Short

	private static readonly IEnumerable<string> EnumerableShort = Enumerable.Range(1, 10).Select(x => x.ToString());
	private static readonly string[] ArrayShort = EnumerableShort.ToArray();
	private static readonly List<string> ListShort = EnumerableShort.ToList();
	private static readonly IQueryable<string> QueryShort = EnumerableShort.AsQueryable();

	private static readonly PagedList<string> PagedListShort =
		EnumerableShort.Paginated(Lab.DataSources.Pagers.PageNumberFirst);


	#region While

	[Benchmark]
	public void While_ArrayShort()
	{
		var i = 0;
		while (i < ArrayShort.Length)
		{
			var item = ArrayShort[i++];
		}
	}

	[Benchmark]
	public void While_ListShort()
	{
		var i = 0;
		while (i < ListShort.Count)
		{
			var item = ListShort[i++];
		}
	}
	
	[Benchmark]
	public void While_QueryShort()
	{
		var i = 0;
		while (i < QueryShort.Count())
		{
			var item = QueryShort.ElementAt(i++);
		}
	}

	[Benchmark]
	public void While_EnumerableShort()
	{
		var i = 0;
		while (i < EnumerableShort.Count())
		{
			var item = EnumerableShort.ElementAt(i++);
		}
	}

	[Benchmark]
	public void While_PagedListShort()
	{
		var i = 0;
		while (i < PagedListShort.Count)
		{
			var item = PagedListShort[i++];
		}
	}

	#endregion

	#region Do While

	[Benchmark]
	public void DoWhile_ArrayShort()
	{
		var i = 0;
		do
		{
			var item = ArrayShort[i++];
		} while (i < ArrayShort.Length);
	}

	[Benchmark]
	public void DoWhile_ListShort()
	{
		var i = 0;
		do
		{
			var item = ListShort[i++];
		} while (i < ListShort.Count);
	}
	
	[Benchmark]
	public void DoWhile_QueryShort()
	{
		var i = 0;
		do
		{
			var item = QueryShort.ElementAt(i++);
		} while (i < QueryShort.Count());
	}

	[Benchmark]
	public void DoWhile_EnumerableShort()
	{
		var i = 0;
		do
		{
			var item = EnumerableShort.ElementAt(i++);
		} while (i < EnumerableShort.Count());
	}

	[Benchmark]
	public void DoWhile_PagedListShort()
	{
		var i = 0;
		do
		{
			var item = PagedListShort[i++];
		} while (i < PagedListShort.Count);
	}

	#endregion
	
	#region For

	[Benchmark]
	public void For_ArrayShort()
	{
		for (int i = 0; i < ArrayShort.Length; i++)
		{
			var item = ArrayShort[i];
		}
	}

	[Benchmark]
	public void For_ListShort()
	{
		for (int i = 0; i < ListShort.Count; i++)
		{
			var item = ListShort[i];
		}
	}

	[Benchmark]
	public void For_QueryShort()
	{
		for (int i = 0; i < QueryShort.Count(); i++)
		{
			var item = QueryShort.ElementAt(i);
		}
	}

	[Benchmark]
	public void For_EnumerableShort()
	{
		for (int i = 0; i < EnumerableShort.Count(); i++)
		{
			var item = EnumerableShort.ElementAt(i);
		}
	}

	[Benchmark]
	public void For_PagedListShort()
	{
		for (int i = 0; i < PagedListShort.Count; i++)
		{
			var item = PagedListShort[i];
		}
	}

	#endregion
	
	#region For Each

	[Benchmark]
	public void ForEach_ArrayShort()
	{
		foreach (var item in ArrayShort)
		{
			var item2 = item;
		}
	}

	[Benchmark]
	public void ForEach_ListShort()
	{
		foreach (var item in ListShort)
		{
			var item2 = item;
		}
	}

	[Benchmark]
	public void ForEach_QueryShort()
	{
		foreach (var item in QueryShort)
		{
			var item2 = item;
		}
	}

	[Benchmark]
	public void ForEach_EnumerableShort()
	{
		foreach (var item in EnumerableShort)
		{
			var item2 = item;
		}
	}

	[Benchmark]
	public void ForEach_PagedListShort()
	{
		foreach (var item in PagedListShort)
		{
			var item2 = item;
		}
	}

	#endregion
	
	#region Linq

	[Benchmark]
	public void Linq_ArrayShort()
	{
		ArrayShort.Select(x => x);
	}

	[Benchmark]
	public void Linq_ListShort()
	{
		ListShort.Select(x => x);
	}

	[Benchmark]
	public void Linq_QueryShort()
	{
		QueryShort.Select(x => x);
	}

	[Benchmark]
	public void Linq_EnumerableShort()
	{
		EnumerableShort.Select(x => x);
	}

	[Benchmark]
	public void Linq_PagedListShort()
	{
		// PagedListShort.Select(x => x);
	}

	#endregion

	#endregion

	#region Long

	private static readonly IEnumerable<string> EnumerableLong = Enumerable.Range(1, 100).Select(x => x.ToString());
	private static readonly string[] ArrayLong = EnumerableLong.ToArray();
	private static readonly List<string> ListLong = EnumerableLong.ToList();
	private static readonly IQueryable<string> QueryLong = EnumerableLong.AsQueryable();
	private static readonly PagedList<string> PagedListLong = EnumerableLong.Paginated(1, 100);


	#region While

	[Benchmark]
	public void While_ArrayLong()
	{
		var i = 0;
		while (i < ArrayLong.Length)
		{
			var item = ArrayLong[i++];
		}
	}

	[Benchmark]
	public void While_ListLong()
	{
		var i = 0;
		while (i < ListLong.Count)
		{
			var item = ListLong[i++];
		}
	}
	
	[Benchmark]
	public void While_QueryLong()
	{
		var i = 0;
		while (i < QueryLong.Count())
		{
			var item = QueryLong.ElementAt(i++);
		}
	}

	[Benchmark]
	public void While_EnumerableLong()
	{
		var i = 0;
		while (i < EnumerableLong.Count())
		{
			var item = EnumerableLong.ElementAt(i++);
		}
	}

	[Benchmark]
	public void While_PagedListLong()
	{
		var i = 0;
		while (i < PagedListLong.Count)
		{
			var item = PagedListLong[i++];
		}
	}

	#endregion

	#region Do While

	[Benchmark]
	public void DoWhile_ArrayLong()
	{
		var i = 0;
		do
		{
			var item = ArrayLong[i++];
		} while (i < ArrayLong.Length);
	}

	[Benchmark]
	public void DoWhile_ListLong()
	{
		var i = 0;
		do
		{
			var item = ListLong[i++];
		} while (i < ListLong.Count);
	}
	
	[Benchmark]
	public void DoWhile_QueryLong()
	{
		var i = 0;
		do
		{
			var item = QueryLong.ElementAt(i++);
		} while (i < QueryLong.Count());
	}

	[Benchmark]
	public void DoWhile_EnumerableLong()
	{
		var i = 0;
		do
		{
			var item = EnumerableLong.ElementAt(i++);
		} while (i < EnumerableLong.Count());
	}

	[Benchmark]
	public void DoWhile_PagedListLong()
	{
		var i = 0;
		do
		{
			var item = PagedListLong[i++];
		} while (i < PagedListLong.Count);
	}

	#endregion
	
	#region For

	[Benchmark]
	public void For_ArrayLong()
	{
		for (int i = 0; i < ArrayLong.Length; i++)
		{
			var item = ArrayLong[i];
		}
	}

	[Benchmark]
	public void For_ListLong()
	{
		for (int i = 0; i < ListLong.Count; i++)
		{
			var item = ListLong[i];
		}
	}

	[Benchmark]
	public void For_QueryLong()
	{
		for (int i = 0; i < QueryLong.Count(); i++)
		{
			var item = QueryLong.ElementAt(i);
		}
	}

	[Benchmark]
	public void For_EnumerableLong()
	{
		for (int i = 0; i < EnumerableLong.Count(); i++)
		{
			var item = EnumerableLong.ElementAt(i);
		}
	}

	[Benchmark]
	public void For_PagedListLong()
	{
		for (int i = 0; i < PagedListLong.Count; i++)
		{
			var item = PagedListLong[i];
		}
	}

	#endregion
	
	#region For Each

	[Benchmark]
	public void ForEach_ArrayLong()
	{
		foreach (var item in ArrayLong)
		{
			var item2 = item;
		}
	}

	[Benchmark]
	public void ForEach_ListLong()
	{
		foreach (var item in ListLong)
		{
			var item2 = item;
		}
	}

	[Benchmark]
	public void ForEach_QueryLong()
	{
		foreach (var item in QueryLong)
		{
			var item2 = item;
		}
	}

	[Benchmark]
	public void ForEach_EnumerableLong()
	{
		foreach (var item in EnumerableLong)
		{
			var item2 = item;
		}
	}

	[Benchmark]
	public void ForEach_PagedListLong()
	{
		foreach (var item in PagedListLong)
		{
			var item2 = item;
		}
	}

	#endregion
	
	#region Linq

	[Benchmark]
	public void Linq_ArrayLong()
	{
		ArrayLong.Select(x => x);
	}

	[Benchmark]
	public void Linq_ListLong()
	{
		ListLong.Select(x => x);
	}

	[Benchmark]
	public void Linq_QueryLong()
	{
		QueryLong.Select(x => x);
	}

	[Benchmark]
	public void Linq_EnumerableLong()
	{
		EnumerableLong.Select(x => x);
	}

	[Benchmark]
	public void Linq_PagedListLong()
	{
		// PagedListLong.Select(x => x);
	}

	#endregion

	#endregion
}