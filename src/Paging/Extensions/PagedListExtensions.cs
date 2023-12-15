using Paging.PagedCollections;
using Paging.Pagers;

namespace Paging.Extensions;

public static class PagedListExtensions
{
	public static PagedList<T> Paginated<T>(this IEnumerable<T> dataSource, int pageNumber, int pageSize) 
		=> new(dataSource, pageNumber, pageSize);
	
	public static PagedList<T> Paginated<T>(this IEnumerable<T> dataSource, IPager pager)
		=> new(dataSource, pager);
	
}